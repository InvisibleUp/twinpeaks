using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinPeaks.FileHandlers
{
    class TextPlain
    {
        public static string Format(byte[] rawinput)
        {
            string input = Encoding.UTF8.GetString(rawinput);
            return _Helpers.Txt2Html(input);
        }
    }
}
