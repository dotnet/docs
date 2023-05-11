// <Snippet2>
using System;
using System.Text.RegularExpressions;

public class CaseExample
{
    public static void Main()
    {
        string pattern = @"\b(?i:t)he\w*\b";
        string input = "The man then told them about that event.";
        foreach (Match match in Regex.Matches(input, pattern))
            Console.WriteLine("Found {0} at index {1}.", match.Value, match.Index);

        Console.WriteLine();
        pattern = @"(?i)\bthe\w*\b";
        foreach (Match match in Regex.Matches(input, pattern,
                                              RegexOptions.IgnoreCase))
            Console.WriteLine("Found {0} at index {1}.", match.Value, match.Index);
    }
}
// The example displays the following output:
//       Found The at index 0.
//       Found then at index 8.
//       Found them at index 18.
//
//       Found The at index 0.
//       Found then at index 8.
//       Found them at index 18.
// </Snippet2>
