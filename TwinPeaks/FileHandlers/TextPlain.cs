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
            const int size_std = 20; // TODO: Make user-configurable

            return _Helpers.Txt2RTF(input, size_std);
            return input;
        }
    }
}
