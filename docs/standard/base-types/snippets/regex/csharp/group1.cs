// <Snippet8>
using System;
using System.Text.RegularExpressions;

public class Group1Example
{
    public static void Main()
    {
        string input = "This is one sentence. This is another.";
        string pattern = @"\b(\w+[;,]?\s?)+[.?!]";

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
//          Group 1: 'sentence' at index 12.
//             Capture 0: 'This ' at 0.
//             Capture 1: 'is ' at 5.
//             Capture 2: 'one ' at 8.
//             Capture 3: 'sentence' at 12.
//
//       Match: 'This is another.' at index 22.
//          Group 0: 'This is another.' at index 22.
//             Capture 0: 'This is another.' at 22.
//          Group 1: 'another' at index 30.
//             Capture 0: 'This ' at 22.
//             Capture 1: 'is ' at 27.
//             Capture 2: 'another' at 30.
// </Snippet8>
