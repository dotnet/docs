// <Snippet2>
using System;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string pattern = @"\b[A-Z]+\b(?=\P{P})";
        string input = "If so, what comes next?";
        foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
            Console.WriteLine(match.Value);
    }
}
// The example displays the following output:
//       If
//       what
//       comes
// </Snippet2>
