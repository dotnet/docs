// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      int[] baseValues = { 2, 8, 10, 16 };
      short value = Int16.MaxValue;
      foreach (var baseValue in baseValues) {
         String s = Convert.ToString(value, baseValue);
         short value2 = Convert.ToInt16(s, baseValue);

         Console.WriteLine($"{value} --> {s} (base {baseValue}) --> {value2}");
      }
   }
}
// The example displays the following output:
//     32767 --> 111111111111111 (base 2) --> 32767
//     32767 --> 77777 (base 8) --> 32767
//     32767 --> 32767 (base 10) --> 32767
//     32767 --> 7fff (base 16) --> 32767
// </Snippet2>
