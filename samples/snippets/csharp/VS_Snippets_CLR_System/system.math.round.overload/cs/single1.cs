// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      Single value = 16.325f;
      Console.WriteLine("Widening Conversion of {0:R} (type {1}) to {2:R} (type {3}): ", 
                        value, value.GetType().Name, (double) value, 
                        ((double) (value)).GetType().Name);
      Console.WriteLine(Math.Round(value, 2));
      Console.WriteLine(Math.Round(value, 2, MidpointRounding.AwayFromZero));
      Console.WriteLine();
      
      Decimal decValue = (decimal) value;
      Console.WriteLine("Cast of {0:R} (type {1}) to {2} (type {3}): ", 
                        value, value.GetType().Name, decValue, 
                        decValue.GetType().Name);
      Console.WriteLine(Math.Round(decValue, 2));
      Console.WriteLine(Math.Round(decValue, 2, MidpointRounding.AwayFromZero));
   }
}
// The example displays the following output:
//    Widening Conversion of 16.325 (type Single) to 16.325000762939453 (type Double):
//    16.33
//    16.33
//    
//    Cast of 16.325 (type Single) to 16.325 (type Decimal):
//    16.32
//    16.33
// </Snippet1>
