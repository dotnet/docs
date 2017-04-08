// The following code example demonstrates the effect of changing the NumberGroupSeparator property.

// <snippet1>
using System;
using System.Globalization;

class NumberFormatInfoSample {

   public static void Main() {

      // Gets a NumberFormatInfo associated with the en-US culture.
      NumberFormatInfo nfi = new CultureInfo( "en-US", false ).NumberFormat;

      // Displays a value with the default separator (",").
      Int64 myInt = 123456789;
      Console.WriteLine( myInt.ToString( "N", nfi ) );

      // Displays the same value with a blank as the separator.
      nfi.NumberGroupSeparator = " ";
      Console.WriteLine( myInt.ToString( "N", nfi ) );

   }
}


/* 
This code produces the following output.

123,456,789.00
123 456 789.00
*/
   
// </snippet1>
