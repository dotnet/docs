// <Snippet15>
using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      // Create a NumberFormatInfo object and set several of its
      // properties that apply to numbers.
      NumberFormatInfo provider = new NumberFormatInfo(); 
      provider.PositiveSign = "pos ";
      provider.NegativeSign = "neg ";

      // Define an array of numeric strings.
      string[] values = { "123456789", "+123456789", "pos 123456789", 
                          "123456789.", "123,456,789",  "4294967295", 
                          "4294967296", "-1", "neg 1" };

      foreach (string value in values)
      {
         Console.Write("{0,-20} -->", value);
         try {
            Console.WriteLine("{0,20}", Convert.ToUInt32(value, provider));
         }   
         catch (FormatException) {
            Console.WriteLine("{0,20}", "Bad Format");
         }
         catch (OverflowException) {
            Console.WriteLine("{0,20}", "Numeric Overflow");
         }   
      }
   }
}
// The example displays the following output:
//       123456789            -->           123456789
//       +123456789           -->          Bad Format
//       pos 123456789        -->           123456789
//       123456789.           -->          Bad Format
//       123,456,789          -->          Bad Format
//       4294967295           -->          4294967295
//       4294967296           -->    Numeric Overflow
//       -1                   -->          Bad Format
//       neg 1                -->    Numeric Overflow
// </Snippet15>
