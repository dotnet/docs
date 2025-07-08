using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      InstantiateByAssignment();
      Console.WriteLine("----");
      InstantiateByNarrowingConversion();
      Console.WriteLine("----");
      Parse();
      Console.WriteLine("----");
      InstantiateByWideningConversion();
   }

   private static void InstantiateByAssignment()
   {
      // <Snippet1>
      int number1 = 64301;
      int number2 = 25548612;
      // </Snippet1>
      Console.WriteLine($"{number1} - {number2}");
   }

   private static void InstantiateByNarrowingConversion()
   {
      // <Snippet2>
      long lNumber = 163245617;
      try {
         int number1 = (int) lNumber;
         Console.WriteLine(number1);
      }
      catch (OverflowException) {
         Console.WriteLine($"{lNumber} is out of range of an Int32.");
      }

      double dbl2 = 35901.997;
      try {
         int number2 = (int) dbl2;
         Console.WriteLine(number2);
      }
      catch (OverflowException) {
         Console.WriteLine($"{dbl2} is out of range of an Int32.");
      }

      BigInteger bigNumber = 132451;
      try {
         int number3 = (int) bigNumber;
         Console.WriteLine(number3);
      }
      catch (OverflowException) {
         Console.WriteLine($"{bigNumber} is out of range of an Int32.");
      }
      // The example displays the following output:
      //       163245617
      //       35902
      //       132451
      // </Snippet2>
   }

   private static void Parse()
   {
      // <Snippet3>
      string string1 = "244681";
      try {
         int number1 = Int32.Parse(string1);
         Console.WriteLine(number1);
      }
      catch (OverflowException) {
         Console.WriteLine($"'{string1}' is out of range of a 32-bit integer.");
      }
      catch (FormatException) {
         Console.WriteLine($"The format of '{string1}' is invalid.");
      }

      string string2 = "F9A3C";
      try {
         int number2 = Int32.Parse(string2,
                                  System.Globalization.NumberStyles.HexNumber);
         Console.WriteLine(number2);
      }
      catch (OverflowException) {
         Console.WriteLine($"'{string2}' is out of range of a 32-bit integer.");
      }
      catch (FormatException) {
         Console.WriteLine($"The format of '{string2}' is invalid.");
      }
      // The example displays the following output:
      //       244681
      //       1022524
      // </Snippet3>
   }

   private static void InstantiateByWideningConversion()
   {
      // <Snippet4>
      sbyte value1 = 124;
      short value2 = 1618;

      int number1 = value1;
      int number2 = value2;
      // </Snippet4>
   }
}
