// <Snippet6>
using System;

public class Example
{
   public static void Main()
   {
      Decimal number = 1079.8m;
      Console.WriteLine("Original value:    {0:N}", number);
      Console.WriteLine("Decremented value: {0:N}", Decimal.Subtract(number, 1)); 
   }
}
// The example displays the following output:
//       Original value:    1,079.80
//       Decremented value: 1,078.80
// </Snippet6>
