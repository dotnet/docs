// <Snippet11>
using System;
using System.Text.RegularExpressions;

public class BackTrack4Example
{
    public static void Main()
    {
        string pattern = @"^[0-9A-Z][-.\w]*(?<=[0-9A-Z])\$$";
        string[] partNos = { "A1C$", "A4", "A4$", "A1603D$", "A1603D#" };

        foreach (var input in partNos)
        {
            Match match = Regex.Match(input, pattern);
            if (match.Success)
                Console.WriteLine(match.Value);
            else
                Console.WriteLine("Match not found.");
        }
    }
}
// The example displays the following output:
//       A1C$
//       Match not found.
//       A4$
//       A1603D$
//       Match not found.
// </Snippet11>
