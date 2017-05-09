// The following code example demonstrates the effect of changing the CurrencyGroupSizes property.

// <snippet1>
using System;
using System.Globalization;

class NumberFormatInfoSample {

   public static void Main() {

      // Gets a NumberFormatInfo associated with the en-US culture.
      NumberFormatInfo nfi = new CultureInfo( "en-US", false ).NumberFormat;

      // Displays a value with the default separator (".").
      Int64 myInt = 123456789012345;
      Console.WriteLine( myInt.ToString( "C", nfi ) );

      // Displays the same value with different groupings.
      int[] mySizes1 = {2,3,4};
      int[] mySizes2 = {2,3,0};
      nfi.CurrencyGroupSizes = mySizes1;
      Console.WriteLine( myInt.ToString( "C", nfi ) );
      nfi.CurrencyGroupSizes = mySizes2;
      Console.WriteLine( myInt.ToString( "C", nfi ) );

   }
}


/* 
This code produces the following output.

$123,456,789,012,345.00
$12,3456,7890,123,45.00
$1234567890,123,45.00
*/
   
// </snippet1>
