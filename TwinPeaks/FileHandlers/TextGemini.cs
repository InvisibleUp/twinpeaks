using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace TwinPeaks.FileHandlers
{
    class TextGemini
    {
        private static string FormatLineAsHeading(string input, int size_std)
        {
            // TODO: make user-configurable
            int size_h1 = (int)(size_std * 1.5);
            int size_h2 = (int)(size_std * 1.3);
            int size_h3 = (int)(size_std * 1.15);

            int level = 0;
            int size;

            foreach (char c in input.Take(3))
            {
               if (c == '#') { level += 1; }
               else { break; }
            }

            switch(level) {
                case 0:
                    return input;
                case 1:
                    size = size_h1;
                    break;
                case 2:
                    size = size_h2;
                    break;
                case 3:
                default:
                    size = size_h3;
                    break;

            }

            string heading = input.Substring(level).Trim();
            return string.Format("\\fs{0}\\ul {2} \\ul0\\fs{1}", size, size_std, heading);
        }

        private static string FormatLineAsLink(string input)
        {
            const string linkSym = "=>";

            if (!input.StartsWith(linkSym)) { return input; }
            char[] whitespace = new char[] { ' ', '\t' };

            string remainder = input.Substring(linkSym.Length).Trim();
            int firstWhitespace = remainder.IndexOfAny(whitespace);
            string url;
            string label;

            if (firstWhitespace == -1) {
                label = url = remainder;
            } else {
                url = remainder.Substring(0, firstWhitespace).Trim();
                label = remainder.Substring(firstWhitespace).Trim();
            }

            string output = (
                @"{\field{\*\fldinst HYPERLINK "
                + '"' + url + '"'
                + @" }{\fldrslt{" + label + @"}}}"
            );
            return output;
        }

        public static string Format(byte[] rawinput)
        {
            // TODO: encodings other than UTF8 exist...
            string input = Encoding.UTF8.GetString(rawinput);
            // TODO: Make user-configurable
            const int size_std = 20; 

            // Convert to RTF
            input = _Helpers.Txt2RTF(input, size_std);

            // Format each line...
            StringWriter output = new StringWriter();
            using (StringReader reader = new StringReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string lineout = line;
                    lineout = FormatLineAsHeading(lineout, size_std);
                    lineout = FormatLineAsLink(lineout);
                    output.WriteLine(lineout);
                }
            }

            return output.ToString();
        }
    }
}
