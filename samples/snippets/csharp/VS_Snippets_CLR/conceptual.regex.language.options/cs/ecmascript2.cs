// <Snippet21>
using System;
using System.Text.RegularExpressions;

public class EcmaScript2Example
{
    static string pattern;

    public static void Main()
    {
        string input = "aa aaaa aaaaaa ";
        pattern = @"((a+)(\1) ?)+";

        // Match input using canonical matching.
        AnalyzeMatch(Regex.Match(input, pattern));

        // Match input using ECMAScript.
        AnalyzeMatch(Regex.Match(input, pattern, RegexOptions.ECMAScript));
    }

    private static void AnalyzeMatch(Match m)
    {
        if (m.Success)
        {
            Console.WriteLine($"'{pattern}' matches {m.Value} at position {m.Index}.");
            int grpCtr = 0;
            foreach (Group grp in m.Groups)
            {
                Console.WriteLine($"   {grpCtr}: '{grp.Value}'");
                grpCtr++;
                int capCtr = 0;
                foreach (Capture cap in grp.Captures)
                {
                    Console.WriteLine($"      {capCtr}: '{cap.Value}'");
                    capCtr++;
                }
            }
        }
        else
        {
            Console.WriteLine("No match found.");
        }
        Console.WriteLine();
    }
}
// The example displays the following output:
//    No match found.
//
//    '((a+)(\1) ?)+' matches aa aaaa aaaaaa  at position 0.
//       0: 'aa aaaa aaaaaa '
//          0: 'aa aaaa aaaaaa '
//       1: 'aaaaaa '
//          0: 'aa '
//          1: 'aaaa '
//          2: 'aaaaaa '
//       2: 'aa'
//          0: 'aa'
//          1: 'aa'
//          2: 'aa'
//       3: 'aaaa '
//          0: ''
//          1: 'aa '
//          2: 'aaaa '
// </Snippet21>
