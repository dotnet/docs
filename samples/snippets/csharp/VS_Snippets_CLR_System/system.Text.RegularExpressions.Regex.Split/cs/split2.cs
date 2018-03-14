// <Snippet2>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      Regex regex = new Regex("(-)");         // Split on hyphens.
      string[] substrings = regex.Split("plum-pear");
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
// </Snippet2>
