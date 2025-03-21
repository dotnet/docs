// <Snippet17>
using System;
using System.Text.RegularExpressions;

public class RTL1Example
{
    public static void Main()
    {
        string pattern = @"\bb\w+\s";
        string input = "build band tab";
        foreach (Match match in Regex.Matches(input, pattern, RegexOptions.RightToLeft))
            Console.WriteLine($"'{match.Value}' found at position {match.Index}.");
    }
}
// The example displays the following output:
//       'band ' found at position 6.
//       'build ' found at position 0.
// </Snippet17>
