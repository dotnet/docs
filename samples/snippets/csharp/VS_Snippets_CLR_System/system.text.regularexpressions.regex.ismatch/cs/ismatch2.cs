// <Snippet2>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string[] partNumbers= { "1298-673-4192", "A08Z-931-468A", 
                              "_A90-123-129X", "12345-KKA-1230", 
                              "0919-2893-1256" };
      Regex rgx = new Regex(@"^[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$");
      foreach (string partNumber in partNumbers)
         Console.WriteLine("{0} {1} a valid part number.", 
                           partNumber, 
                           rgx.IsMatch(partNumber) ? "is" : "is not");
   }
}
// The example displays the following output:
//       1298-673-4192 is a valid part number.
//       A08Z-931-468A is a valid part number.
//       _A90-123-129X is not a valid part number.
//       12345-KKA-1230 is not a valid part number.
//       0919-2893-1256 is not a valid part number.
// </Snippet2>
