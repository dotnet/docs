// <Snippet26>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\d+";
      Regex rgx = new Regex(pattern);
      string input = "123ABCDE456FGHIJ789KLMNO012PQRST";
      Match m = rgx.Match(input);
      if (m.Success) { 
         int startAt = m.Index;
         string[] result = rgx.Split(input, 3, startAt);
         for (int ctr = 0; ctr < result.Length; ctr++) {
            Console.Write("'{0}'", result[ctr]);
            if (ctr < result.Length - 1)
               Console.Write(", ");
         }
         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//       '', 'ABCDE', 'FGHIJKL789MNOPQ012'
// </Snippet26>
