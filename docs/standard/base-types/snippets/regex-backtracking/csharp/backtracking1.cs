// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example1
{
    public static void Run()
    {
        string input = "needing a reed";
        string pattern = @"e{2}\w\b";
        foreach (Match match in Regex.Matches(input, pattern))
            Console.WriteLine("{0} found at position {1}",
                              match.Value, match.Index);
    }
}
// The example displays the following output:
//       eed found at position 11
// </Snippet1>
