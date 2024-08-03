// <Snippet10>
using System;
using System.Text.RegularExpressions;

public class BackTrack2Example
{
    public static void Main()
    {
        string input = "This this word Sentence name Capital";
        string pattern = @"\b\p{Lu}\w*\b";
        foreach (Match match in Regex.Matches(input, pattern))
            Console.WriteLine(match.Value);

        Console.WriteLine();

        pattern = @"\b\p{Lu}(?>\w*)\b";
        foreach (Match match in Regex.Matches(input, pattern))
            Console.WriteLine(match.Value);
    }
}
// The example displays the following output:
//       This
//       Sentence
//       Capital
//
//       This
//       Sentence
//       Capital
// </Snippet10>
