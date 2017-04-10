// <Snippet21>
using System;

public class Example
{
   public static void Main()
   {
      Decimal number1 = 120.07m;
      Decimal number2 = 163.19m;
      Decimal number3 = number1 - number2;
      Console.WriteLine("{0} - {1} = {2}", 
                        number1, number2, number3);
   }
}
// The example displays the following output:
//        120.07 - 163.19 = -43.12
// </Snippet21>
