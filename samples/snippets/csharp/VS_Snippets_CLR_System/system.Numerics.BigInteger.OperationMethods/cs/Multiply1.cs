using System;
using System.Numerics;

public class Class1
{
   public static void Main()
   {
      Multiply();
      Add();
      Subtract();
      Negate();
   }
   
   private static void Multiply()
   {
      // <Snippet1>
      // The statement
      //    BigInteger number = Int64.MaxValue * 3;
      // produces compiler error CS0220: The operation overflows at compile time in checked mode.
      // The alternative:
      BigInteger number = BigInteger.Multiply(Int64.MaxValue, 3);
      // </Snippet1>
   }

   private static void Add()
   {
      // <Snippet2>
      // The statement:
      //    BigInteger number = Int64.MaxValue + Int32.MaxValue;
      // produces compiler error CS0220: The operation overflows at compile time in checked mode.
      // The alternative:
      BigInteger number = BigInteger.Add(Int64.MaxValue, Int32.MaxValue);
      // </Snippet2>
   }

   private static void Subtract()
   {
      // <Snippet3>
      // The statement
      //    BigInteger number = Int64.MinValue - Int64.MaxValue;
      // produces compiler error CS0220: The operation overflows at compile time in checked mode.
      // The alternative:
      BigInteger number = BigInteger.Subtract(Int64.MinValue, Int64.MaxValue);     
      // </Snippet3>
   }

   private static void Negate()
   {
      // <Snippet4>
      // The statement
      //    BigInteger number = -Int64.MinValue;
      // produces compiler error CS0220: The operation overflows at compile time in checked mode.
      // The alternative:
      BigInteger number = BigInteger.Negate(Int64.MinValue);     
      // </Snippet4>
   }
}
 