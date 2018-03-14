// <Snippet5>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      Random rnd = new Random();
      int[]  numbers = new int[4];
      int total = 0;
      for (int ctr = 0; ctr <= 2; ctr++) {
         int number = rnd.Next(1001);
         numbers[ctr] = number;
         total += number;
      }   
      numbers[3] = total;
      Console.WriteLine("{0} + {1} + {2} = {3}", numbers);   
   }
}
// The example displays the following output:
//    Unhandled Exception: 
//    System.FormatException: 
//       Index (zero based) must be greater than or equal to zero and less than the size of the argument list.
//       at System.Text.StringBuilder.AppendFormat(IFormatProvider provider, String format, Object[] args)
//       at System.IO.TextWriter.WriteLine(String format, Object arg0)
//       at System.IO.TextWriter.SyncTextWriter.WriteLine(String format, Object arg0)
//       at Example.Main()
// </Snippet5>
