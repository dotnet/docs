using System;

namespace UtilityLibraries
{
    public static class StringLibrary
    {
        public static bool StartsWithUpper(this string str)
        {
            if (String.IsNullOrWhiteSpace(str))
                return false;

            char ch = str[0];
            return Char.IsUpper(ch);
        }
    }
}
