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
      long number1 = -64301728;
      long number2 = 255486129307;
      // </Snippet1>
      Console.WriteLine("{0} - {1}", number1, number2);
   }
   
   private static void InstantiateByNarrowingConversion()
   {
      // <Snippet2>
      ulong ulNumber = 163245617943825;
      try {
         long number1 = (long) ulNumber;
         Console.WriteLine(number1);
      }
      catch (OverflowException) {
         Console.WriteLine("{0} is out of range of an Int64.", ulNumber);
      }
      
      double dbl2 = 35901.997;
      try {
         long number2 = (long) dbl2;
         Console.WriteLine(number2);
      }   
      catch (OverflowException) {
         Console.WriteLine("{0} is out of range of an Int64.", dbl2);
      }
         
      BigInteger bigNumber = (BigInteger) 1.63201978555e30;
      try {
         long number3 = (long) bigNumber;
         Console.WriteLine(number3);
      }
      catch (OverflowException) {
         Console.WriteLine("{0} is out of range of an Int64.", bigNumber);
      }    
      // The example displays the following output:
      //    163245617943825
      //    35902
      //    1,632,019,785,549,999,969,612,091,883,520 is out of range of an Int64.
      // </Snippet2> 
   }

   private static void Parse()
   {
      // <Snippet3>
      string string1 = "244681903147";
      try {
         long number1 = Int64.Parse(string1);
         Console.WriteLine(number1);
      }
      catch (OverflowException) {
         Console.WriteLine("'{0}' is out of range of a 64-bit integer.", string1);
      }
      catch (FormatException) {
         Console.WriteLine("The format of '{0}' is invalid.", string1);
      }

      string string2 = "F9A3CFF0A";
      try {
         long number2 = Int64.Parse(string2,
                                    System.Globalization.NumberStyles.HexNumber);
         Console.WriteLine(number2);
      }
      catch (OverflowException) {
         Console.WriteLine("'{0}' is out of range of a 64-bit integer.", string2);
      }
      catch (FormatException) {
         Console.WriteLine("The format of '{0}' is invalid.", string2);
      }
      // The example displays the following output:
      //    244681903147
      //    67012198154
      // </Snippet3>     
   }
   
   private static void InstantiateByWideningConversion()
   {
      // <Snippet4>
      sbyte value1 = 124;
      short value2 = 1618;
      int value3 = Int32.MaxValue;
      
      long number1 = value1;
      long number2 = value2;
      long number3 = value3;
      // </Snippet4>
   }
}
