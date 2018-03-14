// <Snippet18>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // Create a NumberFormatInfo object and set several of its
      // properties that apply to numbers.
      NumberFormatInfo provider = new NumberFormatInfo();
      provider.PositiveSign = "pos ";
      provider.NegativeSign = "neg ";

      // Define an array of strings to convert to UInt16 values.
      string[] values= { "34567", "+34567", "pos 34567", "34567.", 
                         "34567.", "65535", "65535", "65535" };         

      foreach (string value in values)
      {
         Console.Write("{0,-12:}  -->  ", value);
         try {
            Console.WriteLine("{0,17}", Convert.ToUInt16(value, provider));
         }
         catch (FormatException e) {       
            Console.WriteLine("{0,17}", e.GetType().Name);
         }     
      }
   }
}
// The example displays the following output:
//       34567         -->              34567
//       +34567        -->    FormatException
//       pos 34567     -->              34567
//       34567.        -->    FormatException
//       34567.        -->    FormatException
//       65535         -->              65535
//       65535         -->              65535
//       65535         -->              65535
// </Snippet18>
