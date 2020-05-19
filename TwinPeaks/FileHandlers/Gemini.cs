using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TwinPeaks.FileHandlers
{
    class Gemini
    {
        public static string Txt2RTF(string input, int size_std)
        {
            StringBuilder sb = new StringBuilder(
                @"{\rtf1\ansi " +
                @"\fs" + size_std.ToString() + " " // set default font size
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
            sb.Append("}");
            return sb.ToString();
        }

        private static string FormatHeadings(string input, int size_std)
        {
            // TODO: make user-configurable
            int size_h1 = (int)(size_std * 1.5);
            int size_h2 = (int)(size_std * 1.3);
            int size_h3 = (int)(size_std * 1.15);

            /// Format headings ///
            // h1 (#)
            input = Regex.Replace(
                input,
                @"^#\s+(.+)$",
                string.Format(@"\fs{0}\ul $1 \ul0\fs{1}", size_h1, size_std),
                RegexOptions.Multiline
            );
            // h2 (##)
            input = Regex.Replace(
                input,
                @"^##\s+(.+)$",
                string.Format(@"\fs{0}\ul $1 \ul0\fs{1}", size_h2, size_std),
                RegexOptions.Multiline
            );
            // h3 (###)
            input = Regex.Replace(
                input,
                @"^###\s+(.+)$",
                string.Format(@"\fs{0}\ul $1 \ul0\fs{1}", size_h3, size_std),
                RegexOptions.Multiline
            );

            return input;
        }

        private static string FormatLinks(string input)
        {
            input = Regex.Replace(
                input,
                @"^=>\s+(\S+)[ \t]*(.*)$",
                @"{\field{\*\fldinst HYPERLINK " + "\"$1\"" + @"}{\fldrslt{$2}}}",
                RegexOptions.Multiline
            );
            return input;
        }

        public static string Format(byte[] rawinput)
        {
            string input = Encoding.UTF8.GetString(rawinput);

            // TODO: Make user-configurable
            const int size_std = 20;

            // Do markup stuff
            input = Txt2RTF(input, size_std);
            input = FormatHeadings(input, size_std);
            //input = FormatLinks(input);

            return input;
        }
    }
}
