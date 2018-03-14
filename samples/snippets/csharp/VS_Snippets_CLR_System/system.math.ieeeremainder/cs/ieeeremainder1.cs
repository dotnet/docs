// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      Console.WriteLine("{0,35} {1,20}", "IEEERemainder", "Modulus");
      ShowRemainders(3, 2);
      ShowRemainders(4, 2);
      ShowRemainders(10, 3);
      ShowRemainders(11, 3);
      ShowRemainders(27, 4);
      ShowRemainders(28, 5);
      ShowRemainders(17.8, 4);
      ShowRemainders(17.8, 4.1);
      ShowRemainders(-16.3, 4.1);
      ShowRemainders(17.8, -4.1);
      ShowRemainders(-17.8, -4.1);
   }

   private static void ShowRemainders(double number1, double number2)
   {
      string formula = String.Format("{0} / {1} = ", number1, number2);
      Console.WriteLine("{0,-16} {1,18} {2,20}", 
                       formula, 
                       Math.IEEERemainder(number1, number2), 
                       number1 % number2);  
   }
}
// The example displays the following output:
//       
//                             IEEERemainder              Modulus
//       3 / 2 =                          -1                    1
//       4 / 2 =                           0                    0
//       10 / 3 =                          1                    1
//       11 / 3 =                         -1                    2
//       27 / 4 =                         -1                    3
//       28 / 5 =                         -2                    3
//       17.8 / 4 =                      1.8                  1.8
//       17.8 / 4.1 =                    1.4                  1.4
//       -16.3 / 4.1 =    0.0999999999999979                   -4
//       17.8 / -4.1 =                   1.4                  1.4
//       -17.8 / -4.1 =                 -1.4                 -1.4
// </Snippet1>
