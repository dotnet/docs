// <Snippet9>
using System;
using System.Text.RegularExpressions;

public class Group2Example
{
    public static void Main()
    {
        string input = "This is one sentence. This is another.";
        string pattern = @"\b(?:\w+[;,]?\s?)+[.?!]";

        foreach (Match match in Regex.Matches(input, pattern))
        {
            Console.WriteLine($"Match: '{match.Value}' at index {match.Index}.");
            int grpCtr = 0;
            foreach (Group grp in match.Groups)
            {
                Console.WriteLine($"   Group {grpCtr}: '{grp.Value}' at index {grp.Index}.");
                int capCtr = 0;
                foreach (Capture cap in grp.Captures)
                {
                    Console.WriteLine($"      Capture {capCtr}: '{cap.Value}' at {cap.Index}.");
                    capCtr++;
                }
                grpCtr++;
            }
            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//       Match: 'This is one sentence.' at index 0.
//          Group 0: 'This is one sentence.' at index 0.
//             Capture 0: 'This is one sentence.' at 0.
//
//       Match: 'This is another.' at index 22.
//          Group 0: 'This is another.' at index 22.
//             Capture 0: 'This is another.' at 22.
// </Snippet9>
