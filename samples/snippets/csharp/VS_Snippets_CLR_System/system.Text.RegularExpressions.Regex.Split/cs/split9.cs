// <Snippet9>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "plum-pear";
      string pattern = "(-)";

      string[] substrings = Regex.Split(input, pattern);    // Split on hyphens
      foreach (string match in substrings)
      {
         Console.WriteLine("'{0}'", match);
      }
   }
}
// The example displays the following output:
//    'plum'
//    '-'
//    'pear'      
// </Snippet9>
