using System;

public class Class1
{
   public static void Main()
   {
      // <Snippet1>
      double floatNumber;
      
      floatNumber = 32.7865;
      // Displays 32      
      Console.WriteLine(Math.Truncate(floatNumber));
      
      floatNumber = -32.9012;
      // Displays -32       
      Console.WriteLine(Math.Truncate(floatNumber));
      // </Snippet1>
      
      // <Snippet2>
      decimal decimalNumber;
      
      decimalNumber = 32.7865m;
      // Displays 32
      Console.WriteLine(Math.Truncate(decimalNumber));
      
      decimalNumber = -32.9012m;
      // Displays -32         
      Console.WriteLine(Math.Truncate(decimalNumber));
      // </Snippet2>
   }
}
