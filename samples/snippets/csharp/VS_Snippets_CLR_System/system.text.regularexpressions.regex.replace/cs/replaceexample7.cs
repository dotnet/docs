// <Snippet7>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern =  @"(\p{Sc}\s?)?(\d+\.?((?<=\.)\d+)?)(?(1)|\s?\p{Sc})?";
      string input = "$17.43  €2 16.33  £0.98  0.43   £43   12€  17";
      string replacement = "$2";
      Regex rgx = new Regex(pattern);
      string result = rgx.Replace(input, replacement);

      Console.WriteLine("Original String:    '{0}'", input);
      Console.WriteLine("Replacement String: '{0}'", result);                             
   }
}
// The example displays the following output:
//       Original String:    '$17.43  €2 16.33  £0.98  0.43   £43   12€  17'
//       Replacement String: '17.43  2 16.33  0.98  0.43   43   12  17'
// </Snippet7>
