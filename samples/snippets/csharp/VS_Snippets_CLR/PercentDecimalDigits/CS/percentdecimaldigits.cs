// The following code example demonstrates the effect of changing the PercentDecimalDigits property.

// <snippet1>
using System;
using System.Globalization;

class NumberFormatInfoSample {

   public static void Main() {

      // Gets a NumberFormatInfo associated with the en-US culture.
      NumberFormatInfo nfi = new CultureInfo( "en-US", false ).NumberFormat;

      // Displays a negative value with the default number of decimal digits (2).
      Double myInt = 0.1234;
      Console.WriteLine( myInt.ToString( "P", nfi ) );

      // Displays the same value with four decimal digits.
      nfi.PercentDecimalDigits = 4;
      Console.WriteLine( myInt.ToString( "P", nfi ) );

   }
}


/* 
This code produces the following output.

12.34 %
12.3400 %
*/
   
// </snippet1>
