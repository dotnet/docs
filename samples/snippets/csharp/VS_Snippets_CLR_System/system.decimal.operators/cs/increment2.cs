// <Snippet14>
using System;

public class Example
{
   public static void Main()
   {
      Decimal number = 1079.8m;
      Console.WriteLine("Original value:    {0:N}", number);
      Console.WriteLine("Incremented value: {0:N}", Decimal.Add(number, 1)); 
   }
}
// The example displays the following output:
//       Original value:    1,079.80
//       Incremented value: 1,080.80
// </Snippet14>
