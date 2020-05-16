using System;
using System.Collections;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Serilog;

namespace TwinPeaks
{
    // Significant portions of this code taken from
    // https://docs.microsoft.com/en-us/dotnet/api/system.net.security.sslstream
    class GeminiClient
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

        static string ReadMessage(SslStream sslStream)
        {
            // Read the  message sent by the server.
            // The end of the message is signaled using the
            // "<EOF>" marker.
            byte[] buffer = new byte[2048];
            StringBuilder messageData = new StringBuilder();
            int bytes = -1;

            do {
                bytes = sslStream.Read(buffer, 0, buffer.Length);

                // Use Decoder class to convert from bytes to UTF8
                // in case a character spans two buffers.
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                messageData.Append(chars);

                // Check for EOF.
                if (messageData.ToString().IndexOf("<EOF>") != -1) {
                    break;
                }
            } while (bytes != 0);

            return messageData.ToString();
        }

        public static string Fetch(Uri hostURL)
        {
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
                sslStream.AuthenticateAsClient(hostURL.Host);
            } catch (AuthenticationException e) {
                Log.Error(e, "Authentication failure");
                client.Close();
                throw e;
            }

            // Gemini request format: URI\r\n
            byte[] messsage = Encoding.UTF8.GetBytes(hostURL.ToString() + "\r\n");
            sslStream.Write(messsage);
            sslStream.Flush();

            // Read message from the server.
            string serverMessage = ReadMessage(sslStream);

            // Close the client connection.
            client.Close();
            //Log.Debug("Connection to server closed");
            return serverMessage;
        }
    }
}
