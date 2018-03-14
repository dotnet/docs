// <Snippet7>
using System;

public class Example
{
   public static void Main()
   {
      Console.WriteLine("{0,5} {1,20:R}  {2,12} {3,15}\n", 
                        "Value", "Full Precision", "ToEven",
                        "AwayFromZero");
      double value = 11.1;
      for (int ctr = 0; ctr <= 5; ctr++)    
         value = RoundValueAndAdd(value);

      Console.WriteLine();

      value = 11.5;
      RoundValueAndAdd(value);
   }
   
   private static double RoundValueAndAdd(double value)
   {
      Console.WriteLine("{0,5:N1} {0,20:R}  {1,12} {2,15}", 
                        value, Math.Round(value, MidpointRounding.ToEven),
                        Math.Round(value, MidpointRounding.AwayFromZero));
      return value + .1;
   }
}
// The example displays the following output:
//       Value       Full Precision        ToEven    AwayFromZero
//       
//        11.1                 11.1            11              11
//        11.2                 11.2            11              11
//        11.3   11.299999999999999            11              11
//        11.4   11.399999999999999            11              11
//        11.5   11.499999999999998            11              11
//        11.6   11.599999999999998            12              12
//       
//        11.5                 11.5            12              12
// </Snippet7>
