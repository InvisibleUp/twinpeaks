using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Serilog;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;

namespace TwinPeaks.Protocols
{
    struct GeminiResponse : IResponse
    {
        public char codeMajor;
        public char codeMinor;
        public string meta;
        public List<byte> pyld { get; set; }
        public string mime { get; set; }
        public string encoding { get; set; }

        public GeminiResponse(List<byte> buffer, int bytes)
        {
            this.codeMajor = (char)buffer[0];
            this.codeMinor = (char)buffer[1];

            int metaStart = 2;
            int metaEnd = buffer.IndexOf((byte)'\n') - 1;
            int pyldStart = metaEnd + 2;
            int pyldLen = bytes - pyldStart;

            byte[] metaraw = buffer.Skip(metaStart).Take(metaEnd).ToArray();
            this.meta = Encoding.UTF8.GetString(metaraw.ToArray()).TrimStart();
            this.pyld = buffer.Skip(metaEnd).Take(pyldLen).ToList();

            this.mime = "text/gemini";
            this.encoding = "UTF-8";
        }

        public override string ToString()
        {
            return string.Format(
                "{0}{1}: {2}",
                codeMajor, codeMinor, meta 
            );
        }
    }

    // Significant portions of this code taken from
    // https://docs.microsoft.com/en-us/dotnet/api/system.net.security.sslstream
    class Gemini
    {
        private static Hashtable certificateErrors = new Hashtable();
        const int DefaultPort = 1965;

        // The following method is invoked by the RemoteCertificateValidationDelegate.
        // Checks if the server's certificate is valid
        public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors
        ) {
            if (sslPolicyErrors == SslPolicyErrors.None) { return true; }
            // Give a warning on self-signed certs, I guess
            if (sslPolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors) {
                Log.Warning("Remote server is using self-signed certificate");
                return true;
            }

            // Do not allow this client to communicate with unauthenticated servers.
            Log.Error("Certificate error: {0}", sslPolicyErrors);
            return false;
        }

        static async Task<GeminiResponse> ReadMessage(SslStream sslStream)
        {
            // Read the  message sent by the server.
            // The end of the message is signaled using the
            // "<EOF>" marker.
            byte[] buffer = new byte[2048];
            int bytes = -1;

            bytes = await sslStream.ReadAsync(buffer, 0, buffer.Length);
            GeminiResponse resp = new GeminiResponse(buffer.ToList(), bytes);

            while (bytes != 0) {
                bytes = await sslStream.ReadAsync(buffer, 0, buffer.Length);
                resp.pyld.AddRange(buffer.Take(bytes));
            }

            return resp;
        }

        public async static Task<IResponse> Fetch(Uri hostURL)
        {
            int refetchCount = 0;
        Refetch:
            // Stop unbounded redirects
            if (refetchCount >= 5) {
                return new GeminiResponse {
                    codeMajor = '3',
                    codeMinor = '9',
                    meta = "",
                    pyld = Encoding.UTF8.GetBytes("Too many redirects!").ToList(),
                    mime = "text/plain",
                    encoding = "UTF-8"
                };
            }
            refetchCount += 1;

            // Set remote port
            int port = hostURL.Port;
            if (port == -1) { port = DefaultPort; }

            // Create a TCP/IP client socket.
            // machineName is the host running the server application.
            TcpClient client;
            try {
                client = new TcpClient(hostURL.Host, port);
            } catch (Exception e) {
                Log.Error(e, "Connection failure");
                throw e;
            }

            // Create an SSL stream that will close the client's stream.
            SslStream sslStream = new SslStream(
                client.GetStream(),
                false,
                new RemoteCertificateValidationCallback(ValidateServerCertificate),
                null
            );

            // The server name must match the name on the server certificate.
            try {
                await sslStream.AuthenticateAsClientAsync(hostURL.Host);
            } catch (AuthenticationException e) {
                Log.Error(e, "Authentication failure");
                client.Close();
                throw e;
            }

            // Gemini request format: URI\r\n
            byte[] messsage = Encoding.UTF8.GetBytes(hostURL.ToString() + "\r\n");
            await sslStream.WriteAsync(messsage, 0, messsage.Count());
            await sslStream.FlushAsync();
            // Read message from the server.
            GeminiResponse resp = await ReadMessage(sslStream);
            // Close the client connection.
            client.Close();

            // Determine what to do w/ that
            switch (resp.codeMajor) {
                //case '1': // Text input
                    // TODO
                    //break;
                case '2': // OK
                    break;
                case '3': // Redirect
                    hostURL = new Uri(resp.meta);
                    goto Refetch;

                case '4': // Temporary failure
                case '5': // Permanent failure
                case '6': // Client cert required
                    Log.Error(resp.ToString());
                    resp.pyld = Encoding.UTF8.GetBytes(resp.ToString()).ToList();
                    break;

                default:
                    throw new Exception(
                        string.Format("Invalid response code {0}", resp.codeMajor)
                    );
            }

            return resp;
        }
    }
}
