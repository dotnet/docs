// <Snippet8>
using System;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string[] inputs = { "aaaaa", "aaaaab" };
        string nonbacktrackingPattern = @"((?>a+))\w";
        Match match;

        foreach (string input in inputs)
        {
            Console.WriteLine($"Input: {input}");
            match = Regex.Match(input, nonbacktrackingPattern);
            Console.WriteLine($"   Pattern: {nonbacktrackingPattern}");
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
//          Pattern: ((?>a+))\w
//             Match failed.
//       Input: aaaaab
//          Pattern: ((?>a+))\w
//             Match: aaaaab
//             Group 1: aaaaa
// </Snippet8>
