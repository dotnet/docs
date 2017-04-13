// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      Decimal number1 = 16354.0695m;
      Decimal number2 = 16354.0699m;
      Console.WriteLine("{0} <> {1}: {2}", number1, 
                        number2, number1 != number2);

      number1 = Decimal.Round(number1, 2);
      number2 = Decimal.Round(number2, 2);
      Console.WriteLine("{0} <> {1}: {2}", number1, 
                        number2, number1 != number2);
   }
}
// The example displays the following output:
//       16354.0695 = 16354.0699: True
//       16354.07 = 16354.07: False
// </Snippet2>
