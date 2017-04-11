// The following code example demonstrates the effect of changing the PercentGroupSeparator property.

// <snippet1>
using System;
using System.Globalization;

class NumberFormatInfoSample {

   public static void Main() {

      // Gets a NumberFormatInfo associated with the en-US culture.
      NumberFormatInfo nfi = new CultureInfo( "en-US", false ).NumberFormat;

      // Displays a value with the default separator (",").
      Double myInt = 1234.5678;
      Console.WriteLine( myInt.ToString( "P", nfi ) );

      // Displays the same value with a blank as the separator.
      nfi.PercentGroupSeparator = " ";
      Console.WriteLine( myInt.ToString( "P", nfi ) );

   }
}


/* 
This code produces the following output.

123,456.78 %
123 456.78 %
*/
   
// </snippet1>
