using System;
using System.Text.RegularExpressions;

public class Test
{

    public static void Main ()
    {

        // Define a regular expression for repeated words.
        Regex rx = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Define a test string.        
        string text = "The the quick brown fox  fox jumped over the lazy dog dog.";
        
        // Find matches.
        MatchCollection matches = rx.Matches(text);

        // Report the number of matches found.
        Console.WriteLine("{0} matches found in:\n   {1}", 
                          matches.Count, 
                          text);

        // Report on each match.
        foreach (Match match in matches)
        {
            GroupCollection groups = match.Groups;
            Console.WriteLine("'{0}' repeated at positions {1} and {2}",  
                              groups["word"].Value, 
                              groups[0].Index, 
                              groups[1].Index);
        }
        
    }
	
}
// The example produces the following output to the console:
//       3 matches found in:
//          The the quick brown fox  fox jumped over the lazy dog dog.
//       'The' repeated at positions 0 and 4
//       'fox' repeated at positions 20 and 25
//       'dog' repeated at positions 50 and 54