// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      string[] values = { "+13230", "-0", "1,390,146", "$190,235,421,127",
                          "0xFA1B", "163042", "-10", "007", "2147483647", 
                          "2147483648", "16e07", "134985.0", "-12034",
                          "-2147483648", "-2147483649" };
      foreach (string value in values)
      {
         try {
            int number = Int32.Parse(value); 
            Console.WriteLine("{0} --> {1}", value, number);
         }
         catch (FormatException) {
            Console.WriteLine("{0}: Bad Format", value);
         }   
         catch (OverflowException) {
            Console.WriteLine("{0}: Overflow", value);   
         }  
      }
   }
}
// The example displays the following output:
//       +13230 --> 13230
//       -0 --> 0
//       1,390,146: Bad Format
//       $190,235,421,127: Bad Format
//       0xFA1B: Bad Format
//       163042 --> 163042
//       -10 --> -10
//       007 --> 7
//       2147483647 --> 2147483647
//       2147483648: Overflow
//       16e07: Bad Format
//       134985.0: Bad Format
//       -12034 --> -12034
//       -2147483648 --> -2147483648
//       -2147483649: Overflow      
// </Snippet1>
