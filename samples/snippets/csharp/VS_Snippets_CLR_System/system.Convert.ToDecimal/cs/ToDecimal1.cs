using System;

public class Class1
{
   public static void Main()
   {
      ConvertSingleToDecimal();
      ConvertDoubleToDecimal();
   }

   private static void ConvertSingleToDecimal()
   {
   // <Snippet1>
   Console.WriteLine(Convert.ToDecimal(1234567500.12F));  // Displays 1234568000
   Console.WriteLine(Convert.ToDecimal(1234568500.12F));  // Displays 1234568000
   
   Console.WriteLine(Convert.ToDecimal(10.980365F));      // Displays 10.98036 
   Console.WriteLine(Convert.ToDecimal(10.980355F));      // Displays 10.98036
   // </Snippet1>
   }

   private static void ConvertDoubleToDecimal()
   {
   // <Snippet2>
   Console.WriteLine(Convert.ToDecimal(123456789012345500.12D));  // Displays 123456789012346000
   Console.WriteLine(Convert.ToDecimal(123456789012346500.12D));  // Displays 123456789012346000
   
   Console.WriteLine(Convert.ToDecimal(10030.12345678905D));      // Displays 10030.123456789 
   Console.WriteLine(Convert.ToDecimal(10030.12345678915D));      // Displays 10030.1234567892
   // </Snippet2>
   }
}
