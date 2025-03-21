// <Snippet8>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(\w)\1";
      string[] words = { "trellis", "seer", "latter", "summer",
                         "hoarse", "lesser", "aardvark", "stunned" };
      foreach (string word in words)
      {
         Match match = Regex.Match(word, pattern);
         if (match.Success)
            Console.WriteLine($"'{match.Value}' found in '{word}' at position {match.Index}.");
         else
            Console.WriteLine($"No double characters in '{word}'.");
      }
   }
}
// The example displays the following output:
//       'll' found in 'trellis' at position 3.
//       'ee' found in 'seer' at position 1.
//       'tt' found in 'latter' at position 2.
//       'mm' found in 'summer' at position 2.
//       No double characters in 'hoarse'.
//       'ss' found in 'lesser' at position 2.
//       'aa' found in 'aardvark' at position 0.
//       'nn' found in 'stunned' at position 3.
// </Snippet8>
