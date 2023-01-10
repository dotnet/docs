// <Snippet13>
using System;
using System.Text.RegularExpressions;

public class Whitespace2Example
{
    public static void Main()
    {
        string input = "This is the first sentence. Is it the beginning " +
                       "of a literary masterpiece? I think not. Instead, " +
                       "it is a nonsensical paragraph.";
        string pattern = @"(?x)\b \(? ( (?>\w+) ,?\s? )+  [\.!?] \)? # Matches an entire sentence.";

        foreach (Match match in Regex.Matches(input, pattern))
            Console.WriteLine(match.Value);
    }
}
// The example displays the following output:
//       This is the first sentence.
//       Is it the beginning of a literary masterpiece?
//       I think not.
//       Instead, it is a nonsensical paragraph.
// </Snippet13>
