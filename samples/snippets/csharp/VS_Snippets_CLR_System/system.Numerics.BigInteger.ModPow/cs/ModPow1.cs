// <Snippet1>
using System;
using System.Numerics;

public class Class1
{
   public static void Main()
   {
      BigInteger number = 10;
      int exponent = 3;
      BigInteger modulus = 30;
      Console.WriteLine("({0}^{1}) Mod {2} = {3}", 
                        number, exponent, modulus, 
                        BigInteger.ModPow(number, exponent, modulus));    
   }
}
// The example displays the following output:
//      (10^3) Mod 30 = 10
// </Snippet1>