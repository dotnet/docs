// <Snippet14>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // Create a NumberFormatInfo object and set several of its
      // properties that apply to unsigned bytes.
      NumberFormatInfo provider = new NumberFormatInfo();

      // These properties affect the conversion.
      provider.PositiveSign = "pos ";
      provider.NegativeSign = "neg ";

      // This property does not affect the conversion.
      // The input string cannot have a decimal separator.
      provider.NumberDecimalSeparator = ".";
      
      // Define an array of numeric strings.
      string[] numericStrings = { "234", "+234", "pos 234", "234.", "255", 
                                  "256", "-1" };

      foreach (string numericString in numericStrings)
      {
         Console.Write("'{0,-8}' ->   ", numericString);
         try {
            byte number = Convert.ToByte(numericString, provider);
            Console.WriteLine(number);
         }   
         catch (FormatException) {
            Console.WriteLine("Incorrect Format");
         }                             
         catch (OverflowException) {
            Console.WriteLine("Overflows a Byte");
         }   
      }
   }
}
// The example displays the following output:
//       '234     ' ->   234
//       '+234    ' ->   Incorrect Format
//       'pos 234 ' ->   234
//       '234.    ' ->   Incorrect Format
//       '255     ' ->   255
//       '256     ' ->   Overflows a Byte
//       '-1      ' ->   Incorrect Format
// </Snippet14>
