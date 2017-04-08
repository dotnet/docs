// <Snippet2>
using CustomRegexes;
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      var rgx = new DuplicateChars(TimeSpan.FromSeconds(.5));
      
      string[] values = { "Greeeeeat", "seed", "deed", "beam", 
                          "loop", "Aardvark" };
      // Display regex information.
      Console.WriteLine("Regular Expression Pattern: {0}", rgx);
      Console.WriteLine("Regex timeout value: {0} seconds\n", 
                        rgx.MatchTimeout.TotalSeconds);
      
      // Display matching information.
      foreach (var value in values) {
         Match m = rgx.Match(value);
         if (m.Success)
            Console.WriteLine("'{0}' found in '{1}' at positions {2}-{3}",
                              m.Value, value, m.Index, m.Index + m.Length - 1);
         else
            Console.WriteLine("No match found in '{0}'", value);
      }                                                         
   }
}
// The example displays the following output:
//       Regular Expression Pattern: (\w)\1+
//       Regex timeout value: 0.5 seconds
//       
//       //eeeee// found in //Greeeeeat// at positions 2-6
//       //ee// found in //seed// at positions 1-2
//       //ee// found in //deed// at positions 1-2
//       No match found in //beam//
//       //oo// found in //loop// at positions 1-2
//       //Aa// found in //Aardvark// at positions 0-1
// </Snippet2>
