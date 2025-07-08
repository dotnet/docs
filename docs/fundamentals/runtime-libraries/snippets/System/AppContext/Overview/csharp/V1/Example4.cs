// <Snippet4>
using System;
using System.Reflection;

[assembly: AssemblyVersion("1.0.0.0")]

public static class StringLibrary1
{
    public static int SubstringStartsAt(string fullString, string substr)
    {
        return fullString.IndexOf(substr, StringComparison.Ordinal);
    }
}
// </Snippet4>

namespace App
{
    // <Snippet5>
    using System;

    public class Example1
    {
        public static void Main()
        {
            string value = "The archaeologist";
            string substring = "archæ";
            int position = StringLibrary1.SubstringStartsAt(value, substring);
            if (position >= 0)
                Console.WriteLine($"'{substring}' found in '{value}' starting at position {position}");
            else
                Console.WriteLine($"'{substring}' not found in '{value}'");
        }
    }
    // The example displays the following output:
    //       'archæ' not found in 'The archaeologist'
    // </Snippet5>
}
