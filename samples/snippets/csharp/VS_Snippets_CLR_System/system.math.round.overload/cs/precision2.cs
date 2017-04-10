// <Snippet8>
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
      const double tolerance = 8e-14;

      Console.WriteLine("{0,5:N1} {0,20:R}  {1,12} {2,15}", 
                        value, 
                        RoundApproximate(value, 0, tolerance, MidpointRounding.ToEven),
                        RoundApproximate(value, 0, tolerance, MidpointRounding.AwayFromZero));
      return value + .1;
   }

   private static double RoundApproximate(double dbl, int digits, double margin, 
                                     MidpointRounding mode)
   {                                      
      double fraction = dbl * Math.Pow(10, digits);
      double value = Math.Truncate(fraction); 
      fraction = fraction - value;   
      if (fraction == 0)
         return dbl;
      
      double tolerance = margin * dbl;
      // Determine whether this is a midpoint value.
      if ((fraction >= .5 - tolerance) & (fraction <= .5 + tolerance)) {
         if (mode == MidpointRounding.AwayFromZero)
            return (value + 1)/Math.Pow(10, digits);
         else
            if (value % 2 != 0)
               return (value + 1)/Math.Pow(10, digits);
            else
               return value/Math.Pow(10, digits);
      }
      // Any remaining fractional value greater than .5 is not a midpoint value.
      if (fraction > .5)
         return (value + 1)/Math.Pow(10, digits);
      else
         return value/Math.Pow(10, digits);
   }
}
// The example displays the following output:
//       Value       Full Precision        ToEven    AwayFromZero
//       
//        11.1                 11.1            11              11
//        11.2                 11.2            11              11
//        11.3   11.299999999999999            11              11
//        11.4   11.399999999999999            11              11
//        11.5   11.499999999999998            12              12
//        11.6   11.599999999999998            12              12
//       
//        11.5                 11.5            12              12
// </Snippet8>
