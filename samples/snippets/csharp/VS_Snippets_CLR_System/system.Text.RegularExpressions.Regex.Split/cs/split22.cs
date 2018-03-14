// <Snippet22>
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string pattern = @"\d+";
      string input = "123ABCDE456FGHIJKL789MNOPQ012";
      string[] result = Regex.Split(input, pattern);
      for (int ctr = 0; ctr < result.Length; ctr++) {
         Console.Write("'{0}'", result[ctr]);
         if (ctr < result.Length - 1) 
            Console.Write(", ");
      }
      Console.WriteLine();
   }
}
// The example displays the following output:
//       '', 'ABCDE', 'FGHIJKL', 'MNOPQ', ''
// </Snippet22>
