// <Snippet1>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"(\d{3})-(\d{3}-\d{4})";
      string input = "212-555-6666 906-932-1111 415-222-3333 425-888-9999";
      MatchCollection matches = Regex.Matches(input, pattern);
      
      foreach (Match match in matches)
      {
         Console.WriteLine("Area Code:        {0}", match.Groups[1].Value);
         Console.WriteLine("Telephone number: {0}", match.Groups[2].Value);
         Console.WriteLine();
      }
      Console.WriteLine();
   }
}
// The example displays the following output:
//       Area Code:        212
//       Telephone number: 555-6666
//       
//       Area Code:        906
//       Telephone number: 932-1111
//       
//       Area Code:        415
//       Telephone number: 222-3333
//       
//       Area Code:        425
//       Telephone number: 888-9999
// </Snippet1>
