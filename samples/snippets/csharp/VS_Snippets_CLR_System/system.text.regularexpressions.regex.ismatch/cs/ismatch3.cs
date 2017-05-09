// <Snippet3>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string[] partNumbers= { "Part Number: 1298-673-4192", "Part No: A08Z-931-468A", 
                              "_A90-123-129X", "123K-000-1230", 
                              "SKU: 0919-2893-1256" };
      Regex rgx = new Regex(@"[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$");
      foreach (string partNumber in partNumbers)
      {
         int start = partNumber.IndexOf(':');
         if (start >= 0)
         {
            Console.WriteLine("{0} {1} a valid part number.", 
                              partNumber, 
                              rgx.IsMatch(partNumber, start) ? "is" : "is not");
         }
         else
         {
            Console.WriteLine("Cannot find starting position in {0}.", partNumber);
         }
      }
   }
}
// The example displays the following output:
//       Part Number: 1298-673-4192 is a valid part number.
//       Part No: A08Z-931-468A is a valid part number.
//       Cannot find starting position in _A90-123-129X.
//       Cannot find starting position in 123K-000-1230.
//       SKU: 0919-2893-1256 is not a valid part number.
// </Snippet3>
