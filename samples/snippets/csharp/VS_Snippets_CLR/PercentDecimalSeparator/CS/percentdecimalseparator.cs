// The following code example demonstrates the effect of changing the PercentDecimalSeparator property.

// <snippet1>
using System;
using System.Globalization;

class NumberFormatInfoSample {

   public static void Main() {

      // Gets a NumberFormatInfo associated with the en-US culture.
      NumberFormatInfo nfi = new CultureInfo( "en-US", false ).NumberFormat;

      // Displays a value with the default separator (".").
      Double myInt = 0.1234;
      Console.WriteLine( myInt.ToString( "P", nfi ) );

      // Displays the same value with a blank as the separator.
      nfi.PercentDecimalSeparator = " ";
      Console.WriteLine( myInt.ToString( "P", nfi ) );

   }
}


/* 
This code produces the following output.

12.34 %
12 34 %
*/
   
// </snippet1>
