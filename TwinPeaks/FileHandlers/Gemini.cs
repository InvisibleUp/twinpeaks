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

        public static string Format(string input)
        {
            // TODO: Make user-configurable
            const int size_std = 20;
            const int size_h1 = (int)(size_std * 1.5);
            const int size_h2 = (int)(size_std * 1.3);
            const int size_h3 = (int)(size_std * 1.15);

            // Remove response line
            input = Regex.Replace(input, @"^(.+)", "");
            input = Txt2RTF(input, size_std);

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

            // Create hyperlinks
            const string hyperlink_out = @"{\field{\*\fldinst HYPERLINK "
                + "\"$1\"" + @"}{\fldrslt{$2}}}";
            input = Regex.Replace(
                input,
                @"^=>\s+(\S+)\s+(.+)$",
                hyperlink_out,
                RegexOptions.Multiline
            );

            return input;
        }
    }
}
