// <Snippet8>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string input = "plum--pear";
      string pattern = "-";            // Split on hyphens
      
      string[] substrings = Regex.Split(input, pattern);
      foreach (string match in substrings)
      {
         Console.WriteLine("'{0}'", match);
      }
   }
}
// The method displays the following output:
//    'plum'
//    ''
//    'pear'      
// </Snippet8>
