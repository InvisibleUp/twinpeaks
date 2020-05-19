using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinPeaks.FileHandlers
{
    class _Helpers
    {
        public static string Txt2RTF(string input, int size_std)
        {
            StringBuilder sb = new StringBuilder(
                @"{\rtf1\ansi " // RTF header
                + @"\fs" + size_std.ToString() + " " // set default font size
                + "\r\n"
            );
            foreach (char c in input)
            {
                if (c <= 0x7f) {
                    // escaping rtf characters
                    switch (c) {
                    case '\\':
                    case '{':
                    case '}':
                        sb.Append('\\');
                        break;
                    case '\r':
                        continue;
                    case '\n':
                        sb.Append("\\par");
                        break;
                    }

                    sb.Append(c);
                }
                // converting special characters
                else {
                    sb.Append("\\u" + Convert.ToUInt32(c) + "?");
                }
            }
            sb.Append("\r\n}");
            return sb.ToString();
        }
    }
}
