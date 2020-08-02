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
            Console.WriteLine("Input: {0}", input);
            match = Regex.Match(input, nonbacktrackingPattern);
            Console.WriteLine("   Pattern: {0}", nonbacktrackingPattern);
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
//          Pattern: ((?>a+))\w
//             Match failed.
//       Input: aaaaab
//          Pattern: ((?>a+))\w
//             Match: aaaaab
//             Group 1: aaaaa
// </Snippet8>
