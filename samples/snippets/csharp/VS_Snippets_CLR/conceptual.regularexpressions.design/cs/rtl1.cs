// <Snippet6>
using System;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string greedyPattern = @".+(\d+)\.";
        string input = "This sentence ends with the number 107325.";
        Match match;

        // Match from left-to-right using lazy quantifier .+?.
        match = Regex.Match(input, greedyPattern);
        if (match.Success)
            Console.WriteLine($"Number at end of sentence (left-to-right): {match.Groups[1].Value}");
        else
            Console.WriteLine($"{greedyPattern} finds no match.");

        // Match from right-to-left using greedy quantifier .+.
        match = Regex.Match(input, greedyPattern, RegexOptions.RightToLeft);
        if (match.Success)
            Console.WriteLine($"Number at end of sentence (right-to-left): {match.Groups[1].Value}");
        else
            Console.WriteLine($"{greedyPattern} finds no match.");
    }
}
// The example displays the following output:
//       Number at end of sentence (left-to-right): 5
//       Number at end of sentence (right-to-left): 107325
// </Snippet6>
