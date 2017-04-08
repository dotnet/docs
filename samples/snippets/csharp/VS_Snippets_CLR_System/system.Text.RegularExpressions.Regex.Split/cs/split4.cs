// <Snippet4>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = "(-)";
      string input = "apple-apricot-plum-pear-banana";
      Regex regex = new Regex(pattern);         // Split on hyphens.
      string[] substrings = regex.Split(input, 4);
      foreach (string match in substrings)
      {
         Console.WriteLine("'{0}'", match);
      }
   }
}
// The example displays the following output:
//       'apple'
//       '-'
//       'apricot'
//       '-'
//       'plum'
//       '-'
//       'pear-banana'      
// </Snippet4>
