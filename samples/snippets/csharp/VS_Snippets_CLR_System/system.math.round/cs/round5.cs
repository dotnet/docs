// <Snippet4>
using System;

public class Example
{
   public static void Main()
   {
      double value = 11.1;
      for (int ctr = 0; ctr <= 5; ctr++)    
         value = RoundValueAndAdd(value);

      Console.WriteLine();

      value = 11.5;
      RoundValueAndAdd(value);
   }
   
   private static double RoundValueAndAdd(double value)
   {
      Console.WriteLine("{0} --> {1}", value, Math.Round(value, 
                        MidpointRounding.AwayFromZero));
      return value + .1;
   }
}
// The example displays the following output:
//       11.1 --> 11
//       11.2 --> 11
//       11.3 --> 11
//       11.4 --> 11
//       11.5 --> 11
//       11.6 --> 12
//       
//       11.5 --> 12
// </Snippet4>
