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
        private static string FormatLineAsHeading(string input)
        {
            int level = 0;
            string starttag = "";
            string endtag = "";

            foreach (char c in input.Take(3))
            {
               if (c == '#') { level += 1; }
               else { break; }
            }

            switch(level) {
                case 0:
                    return input;
                case 1:
                    starttag = "<span style=\"font-size: 20pt\"><u>";
                    endtag = "</u></span>";
                    break;
                case 2:
                    starttag = "<span style=\"font-size: 16pt\"><u>";
                    endtag = "</u></span>";
                    break;
                case 3:
                default:
                    starttag = "<span style=\"font-size: 14pt\"><u>";
                    endtag = "</u></span>";
                    break;
            }

            string heading = input.Substring(level).Trim();
            if (heading.EndsWith("<br/>")) {
                heading = heading.Substring(0, heading.Length - "<br/>".Length);
            }
            return starttag + heading + endtag;
        }

        private static string FormatLineAsLink(string input)
        {
            const string linkSym = "=&gt;";

            if (!input.StartsWith(linkSym)) { return input; }
            char[] whitespace = new char[] { ' ', '\t' };

            string remainder = input.Substring(linkSym.Length).Trim();
            int firstWhitespace = remainder.IndexOfAny(whitespace);
            string url;
            string label;

            // Remove newlines
            if (remainder.EndsWith("<br/>")) {
                remainder = remainder.Substring(0, remainder.Length - "<br/>".Length).Trim();
            }

            // Seperate into URL and label
            if (firstWhitespace == -1) {
                url = remainder;
                label = remainder;
            } else {
                url = remainder.Substring(0, firstWhitespace).Trim();
                label = remainder.Substring(firstWhitespace).Trim();
            }

            // Default protocol is "gemini"
            if (url.StartsWith("://")) { url = "gemini" + url; }
            else if (url.StartsWith("//")) { url = "gemini:" + url; }

            return string.Format("<div>=&gt; <a href=\"{0}\">{1}</a></div>", url, label);
        }

        public static string Format(byte[] rawinput)
        {
            // TODO: encodings other than UTF8 exist...
            string input = Encoding.UTF8.GetString(rawinput);

            // Convert to RTF
            input = _Helpers.Txt2Html(input);

            // Format each line...
            StringWriter output = new StringWriter();
            using (StringReader reader = new StringReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string lineout = line;
                    lineout = FormatLineAsHeading(lineout);
                    lineout = FormatLineAsLink(lineout);
                    output.WriteLine(lineout);
                }
            }

            string outputstr = output.ToString();
            return outputstr;
        }
    }
}
