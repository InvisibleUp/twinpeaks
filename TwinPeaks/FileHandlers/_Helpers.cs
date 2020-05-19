using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinPeaks.FileHandlers
{
    class _Helpers
    {
        public static string Txt2Html(string input)
        {
            StringBuilder sb = new StringBuilder(
                "<!DOCTYPE html>\r\n<html>\r\n" +
                "<style>\r\n" +
                "html { font-family: Consolas, monospace; }\r\n" +
                "</style>\r\n"
            );
            foreach (char c in input) {
                switch (c) {
                case '<':
                    sb.Append("&lt;");
                    continue;
                case '>':
                    sb.Append("&gt;");
                    continue;
                case '\r':
                    continue;
                case '\n':
                    sb.Append("<br/>");
                    break;
                }

                sb.Append(c);
            }
            sb.Append("\r\n</html>");
            return sb.ToString();
        }
    }
}
