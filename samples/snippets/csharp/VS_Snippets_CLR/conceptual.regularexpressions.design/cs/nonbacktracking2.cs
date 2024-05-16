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
            Console.WriteLine("Input: {0}", input);
            match = Regex.Match(input, backtrackingPattern);
            Console.WriteLine("   Pattern: {0}", backtrackingPattern);
            if (match.Success)
            {
                Console.WriteLine("      Match: {0}", match.Value);
                Console.WriteLine("      Group 1: {0}", match.Groups[1].Value);
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
