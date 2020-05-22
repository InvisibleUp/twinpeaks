using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinPeaks.FileHandlers
{
    class _Helpers
    {
        private static String HexColor(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static string Txt2Html(string input)
        {
            var settings = Properties.Settings.Default;
            StringBuilder sb = new StringBuilder(
                "<!DOCTYPE html>\r\n<html>\r\n" +
                "<style>\r\n" +
                "html { " +
                    "font-family: " + settings.fontContent.Name + "; " +
                    "font-size: " + settings.fontContent.SizeInPoints + "pt; " +
                    "color: " + HexColor(settings.colorFG) + "; " +
                    "background-color: " + HexColor(settings.colorBG) + "; " +
                    "padding: 6pt;" +
                "}\r\n" +
                "pre { " +
                    "font-family: " + settings.fontMonospace.Name + "; " +
                    "font-size: " + settings.fontMonospace.SizeInPoints + "pt; " +
                "}\r\n" +
                "a { " +
                    "color: " + HexColor(settings.colorLink) + "; " +
                "}\r\n" +
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
