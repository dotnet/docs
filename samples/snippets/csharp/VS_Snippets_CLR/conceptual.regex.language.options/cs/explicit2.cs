// <Snippet10>
using System;
using System.Text.RegularExpressions;

public class Explicit2Example
{
    public static void Main()
    {
        string input = "This is the first sentence. Is it the beginning " +
                       "of a literary masterpiece? I think not. Instead, " +
                       "it is a nonsensical paragraph.";
        string pattern = @"(?n)\b\(?((?>\w+),?\s?)+[\.!?]\)?";

        foreach (Match match in Regex.Matches(input, pattern))
        {
            Console.WriteLine($"The match: {match.Value}");
            int groupCtr = 0;
            foreach (Group group in match.Groups)
            {
                Console.WriteLine($"   Group {groupCtr}: {group.Value}");
                groupCtr++;
                int captureCtr = 0;
                foreach (Capture capture in group.Captures)
                {
                    Console.WriteLine($"      Capture {captureCtr}: {capture.Value}");
                    captureCtr++;
                }
            }
        }
    }
}
// The example displays the following output:
//       The match: This is the first sentence.
//          Group 0: This is the first sentence.
//             Capture 0: This is the first sentence.
//       The match: Is it the beginning of a literary masterpiece?
//          Group 0: Is it the beginning of a literary masterpiece?
//             Capture 0: Is it the beginning of a literary masterpiece?
//       The match: I think not.
//          Group 0: I think not.
//             Capture 0: I think not.
//       The match: Instead, it is a nonsensical paragraph.
//          Group 0: Instead, it is a nonsensical paragraph.
//             Capture 0: Instead, it is a nonsensical paragraph.
// </Snippet10>
