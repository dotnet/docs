using System;
using System.Globalization;
using System.Numerics;

public class TestToString
{
   public static void Main()
   {
      TestToString test = new TestToString();
      test.CallToString1();
      Console.WriteLine();
      test.CallToString2();
      Console.WriteLine();
      test.CallToString3();
   }

   private void CallToString1()
   {
      // <Snippet1>
      BigInteger number = 9867857831128;
      number = BigInteger.Pow(number, 3) * BigInteger.MinusOne;
      
      NumberFormatInfo bigIntegerProvider = new NumberFormatInfo();
      bigIntegerProvider.NegativeSign = "~";
      
      Console.WriteLine(number.ToString(bigIntegerProvider));
      // </Snippet1>
   }
   
   private void CallToString2()
   {
      // <Snippet2>
      BigInteger number = 9867857831128;
      Console.WriteLine(number.ToString("G"));          // Displays 9867857831128
      Console.WriteLine(number.ToString("D"));          // Displays 9867857831128
      Console.WriteLine("0x{0}", number.ToString("X")); // Displays 0x8F98A2924D8
      // </Snippet2>
   }

   private void CallToString3()
   {
      // <Snippet3>
      NumberFormatInfo bigIntegerFormat = new NumberFormatInfo();
      bigIntegerFormat.NegativeSign = "~";
      
      BigInteger number = new BigInteger(-9867857831128);

      Console.WriteLine(number.ToString("G"));          // Displays 9867857831128
      Console.WriteLine(number.ToString("D"));          // Displays 9867857831128
      Console.WriteLine(number.ToString("X"));          // Displays 8F98A2924D8
      // </Snippet3>
   }
}
