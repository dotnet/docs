// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\d+";
      string[] inputs = { "This sentence contains no numbers.",
                          "123 What do I see?",
                          "2468 369 48 5" };
      foreach (var input in inputs) {
         MatchCollection matches = Regex.Matches(input, pattern);
         Console.WriteLine("Input: {0}", input);
         if (matches.Count == 0)
            Console.WriteLine("   No matches");
         else
            foreach (Match m in matches)
               Console.WriteLine("   {0} at index {1}", m.Value, m.Index);

         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//       Input: This sentence contains no numbers.
//          No matches
//
//       Input: 123 What do I see?
//          123 at index 0
//
//       Input: 2468 369 48 5
//          2468 at index 0
//          369 at index 5
//          48 at index 9
//          5 at index 12
// </Snippet1>