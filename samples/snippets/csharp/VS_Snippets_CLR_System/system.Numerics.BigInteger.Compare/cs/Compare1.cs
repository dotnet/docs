using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      BigInteger number1 = BigInteger.Pow(Int64.MaxValue, 100);
      BigInteger number2 = number1 + 1;
      string relation = "";
      switch (BigInteger.Compare(number1, number2))
      {
         case -1:
            relation = "<";
            break;
         case 0:
            relation = "=";
            break;
         case 1:
            relation = ">";
            break;
      }
      Console.WriteLine("{0} {1} {2}", number1, relation, number2);
      // The example displays the following output:
      //    3.0829940252776347122742186219E+1896 < 3.0829940252776347122742186219E+1896
      // </Snippet1>
   }
}
