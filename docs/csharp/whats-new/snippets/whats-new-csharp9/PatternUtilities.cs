using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCsharp9
{
    public static class PatternUtilities
    {
        // <IsLetterPattern>
        public static bool IsLetter(this char c) =>
            c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';
        // </IsLetterPattern>

        // <IsLetterOrSeparatorPattern>
        public static bool IsLetterIsSeparator(this char c) =>
            c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',';
        // </IsLetterOrSeparatorPattern>

    }
}
