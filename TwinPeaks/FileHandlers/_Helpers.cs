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
        public static string Txt2Html(string input)
        {
            var settings = Properties.Settings.Default;
            StringBuilder sb = new StringBuilder(
                "<!DOCTYPE html>\r\n<html>\r\n" +
                "<style>\r\n" +
                "html { " +
                    "font-family: " + settings.fontContent.Name + "; " +
                    "font-size: " + settings.fontContent.SizeInPoints + "pt; " +
                    "color: " + ColorTranslator.ToHtml(settings.colorFG) + "; " +
                    "background: " + ColorTranslator.ToHtml(settings.colorBG) + "; " +
                "}\r\n" +
                "pre { " +
                    "font-family: " + settings.fontMonospace.Name + "; " +
                    "font-size: " + settings.fontMonospace.SizeInPoints + "pt; " +
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
