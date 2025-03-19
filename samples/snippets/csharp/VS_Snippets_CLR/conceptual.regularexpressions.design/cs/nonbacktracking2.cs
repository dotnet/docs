// <Snippet7>
using System;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string[] inputs = { "aaaaa", "aaaaab" };
        string backtrackingPattern = @"(a+)\w";
        Match match;

        foreach (string input in inputs)
        {
            Console.WriteLine($"Input: {input}");
            match = Regex.Match(input, backtrackingPattern);
            Console.WriteLine($"   Pattern: {backtrackingPattern}");
            if (match.Success)
            {
                Console.WriteLine($"      Match: {match.Value}");
                Console.WriteLine($"      Group 1: {match.Groups[1].Value}");
            }
            else
            {
                Console.WriteLine("      Match failed.");
            }
        }
        Console.WriteLine();
    }
}
// The example displays the following output:
//       Input: aaaaa
//          Pattern: (a+)\w
//             Match: aaaaa
//             Group 1: aaaa
//       Input: aaaaab
//          Pattern: (a+)\w
//             Match: aaaaab
//             Group 1: aaaaa
// </Snippet7>
