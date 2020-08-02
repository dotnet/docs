// <Snippet3>
using System;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string pattern = @"\b(?!non)\w+\b";
        string input = "Nonsense is not always non-functional.";
        foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
            Console.WriteLine(match.Value);
    }
}
// The example displays the following output:
//       is
//       not
//       always
//       functional
// </Snippet3>
