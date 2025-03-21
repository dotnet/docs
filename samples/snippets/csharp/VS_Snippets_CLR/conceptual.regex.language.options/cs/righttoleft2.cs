// <Snippet18>
using System;
using System.Text.RegularExpressions;

public class RTL2Example
{
    public static void Main()
    {
        string[] inputs = { "1 May, 1917", "June 16, 2003" };
        string pattern = @"(?<=\d{1,2}\s)\w+,\s\d{4}";

        foreach (string input in inputs)
        {
            Match match = Regex.Match(input, pattern, RegexOptions.RightToLeft);
            if (match.Success)
                Console.WriteLine($"The date occurs in {match.Value}.");
            else
                Console.WriteLine($"{input} does not match.");
        }
    }
}

// The example displays the following output:
//       The date occurs in May, 1917.
//       June 16, 2003 does not match.
// </Snippet18>
