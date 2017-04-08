// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      decimal[] values = { 1.15m, 1.25m, 1.35m, 1.45m, 1.55m, 1.65m };
      decimal sum = 0;
      
      // Calculate true mean.
      foreach (var value in values)
         sum += value;

      Console.WriteLine("True mean:     {0:N2}", sum/values.Length);
      
      // Calculate mean with rounding away from zero.
      sum = 0;
      foreach (var value in values)
         sum += Math.Round(value, 1, MidpointRounding.AwayFromZero);

      Console.WriteLine("AwayFromZero:  {0:N2}", sum/values.Length);
      
      // Calculate mean with rounding to nearest.
      sum = 0;
      foreach (var value in values)
         sum += Math.Round(value, 1, MidpointRounding.ToEven);

      Console.WriteLine("ToEven:        {0:N2}", sum/values.Length);
   }
}
// The example displays the following output:
//       True mean:     1.40
//       AwayFromZero:  1.45
//       ToEven:        1.40
// </Snippet2>
