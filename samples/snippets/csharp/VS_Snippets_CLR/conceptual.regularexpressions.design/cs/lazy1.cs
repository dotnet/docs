// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string greedyPattern = @".+(\d+)\.";
        string lazyPattern = @".+?(\d+)\.";
        string input = "This sentence ends with the number 107325.";
        Match match;

        // Match using greedy quantifier .+.
        match = Regex.Match(input, greedyPattern);
        if (match.Success)
            Console.WriteLine("Number at end of sentence (greedy): {0}",
                              match.Groups[1].Value);
        else
            Console.WriteLine($"{greedyPattern} finds no match.");

        // Match using lazy quantifier .+?.
        match = Regex.Match(input, lazyPattern);
        if (match.Success)
            Console.WriteLine("Number at end of sentence (lazy): {0}",
                              match.Groups[1].Value);
        else
            Console.WriteLine($"{lazyPattern} finds no match.");
    }
}
// The example displays the following output:
//       Number at end of sentence (greedy): 5
//       Number at end of sentence (lazy): 107325
// </Snippet1>
