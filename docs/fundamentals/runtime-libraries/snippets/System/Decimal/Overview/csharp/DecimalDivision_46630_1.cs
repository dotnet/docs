using System;

public class Class1
{
   public static void Main()
   {
      DivideWithoutRounding();
      DivideWithRounding();
   }

   private static void DivideWithoutRounding()
   {
      Console.WriteLine("DivideWithoutRounding");
      // <Snippet1>
      decimal dividend = Decimal.One;
      decimal divisor = 3;
      // The following displays 0.9999999999999999999999999999 to the console
      Console.WriteLine(dividend/divisor * divisor);
      // </Snippet1>
   }

   private static void DivideWithRounding()
   {
      Console.WriteLine("DivideWithRounding");
      // <Snippet2>
      decimal dividend = Decimal.One;
      decimal divisor = 3;
      // The following displays 1.00 to the console
      Console.WriteLine(Math.Round(dividend/divisor * divisor, 2));
      // </Snippet2>
   }
}
