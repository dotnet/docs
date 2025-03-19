// <Snippet6>
using System;
using System.Reflection;

[assembly: AssemblyVersion("2.0.0.0")]

public static class StringLibrary2
{
    public static int SubstringStartsAt(string fullString, string substr)
    {
        return fullString.IndexOf(substr, StringComparison.CurrentCulture);
    }
}
// </Snippet6>

namespace App
{
    // <Snippet7>
    using System;

    public class Example2
    {
        public static void Main()
        {
            string value = "The archaeologist";
            string substring = "archæ";
            int position = StringLibrary2.SubstringStartsAt(value, substring);
            if (position >= 0)
                Console.WriteLine($"'{substring}' found in '{value}' starting at position {position}");
            else
                Console.WriteLine($"'{substring}' not found in '{value}'");
        }
    }
    // The example displays the following output:
    //       'archæ' found in 'The archaeologist' starting at position 4
    // </Snippet7>
}
