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
            Console.WriteLine("Number at end of sentence (left-to-right): {0}",
                              match.Groups[1].Value);
        else
            Console.WriteLine("{0} finds no match.", greedyPattern);

        // Match from right-to-left using greedy quantifier .+.
        match = Regex.Match(input, greedyPattern, RegexOptions.RightToLeft);
        if (match.Success)
            Console.WriteLine("Number at end of sentence (right-to-left): {0}",
                              match.Groups[1].Value);
        else
            Console.WriteLine("{0} finds no match.", greedyPattern);
    }
}
// The example displays the following output:
//       Number at end of sentence (left-to-right): 5
//       Number at end of sentence (right-to-left): 107325
// </Snippet6>
