// <snippet0>
using System;
using System.Text.RegularExpressions;

public class Test
{
    public static void Main ()
    {
// <snippet1>
        // Define a regular expression for repeated words.
        Regex rx = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
// </snippet1>

        // Define a test string.
        string text = "The the quick brown fox  fox jumps over the lazy dog dog.";

// <snippet2>
        // Find matches.
        MatchCollection matches = rx.Matches(text);
// </snippet2>

// <snippet3>
        // Report the number of matches found.
        Console.WriteLine($"{matches.Count} matches found in:\n   {text}");
// </snippet3>

// <snippet4>
        // Report on each match.
        foreach (Match match in matches)
        {
            GroupCollection groups = match.Groups;
            Console.WriteLine($"'{groups["word"].Value}' repeated at positions {groups[0].Index} and {groups[1].Index}");
        }
// </snippet4>
    }
}

// The example produces the following output to the console:
//       3 matches found in:
//          The the quick brown fox  fox jumps over the lazy dog dog.
//       'The' repeated at positions 0 and 4
//       'fox' repeated at positions 20 and 25
//       'dog' repeated at positions 49 and 53
// </snippet0>
