// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      string[] values = { "100", "(100)", "-123,456,789", "123.45e+6", 
                          "+500", "5e2", "3.1416", "600.", "-.123", 
                          "-Infinity", "-1E-16", Double.MaxValue.ToString(), 
                          Single.MinValue.ToString(), String.Empty };
      foreach (string value in values)
      {
         try {   
            float number = Single.Parse(value);
            Console.WriteLine("{0} -> {1}", value, number);
         }
         catch (FormatException) {
            Console.WriteLine("'{0}' is not in a valid format.", value);
         }
         catch (OverflowException) {
            Console.WriteLine("{0} is outside the range of a Single.", value);
         }
      }                                  
   }
}
// The example displays the following output:
//       100 -> 100
//       '(100)' is not in a valid format.
//       -123,456,789 -> -1.234568E+08
//       123.45e+6 -> 1.2345E+08
//       +500 -> 500
//       5e2 -> 500
//       3.1416 -> 3.1416
//       600. -> 600
//       -.123 -> -0.123
//       -Infinity -> -Infinity
//       -1E-16 -> -1E-16
//       1.79769313486232E+308 is outside the range of a Single.
//       -3.402823E+38 -> -3.402823E+38
//       '' is not in a valid format.
// </Snippet2>
