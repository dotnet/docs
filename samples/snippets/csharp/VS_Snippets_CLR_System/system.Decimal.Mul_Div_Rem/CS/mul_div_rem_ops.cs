//<Snippet2>
// Example of the decimal multiplication, division, and modulus 
// operators.
using System;

class DecimalMulDivRemOpsDemo
{
    const string dataFmt = "   {0,-18}{1,31}";

    // Display decimal parameters and their product, quotient, and 
    // remainder.
    public static void ShowDecimalProQuoRem( decimal Left, decimal Right )
    {
        Console.WriteLine( );
        Console.WriteLine( dataFmt, "decimal Left", Left );
        Console.WriteLine( dataFmt, "decimal Right", Right );
        Console.WriteLine( dataFmt, "Left * Right", Left * Right );
        Console.WriteLine( dataFmt, "Left / Right", Left / Right );
        Console.WriteLine( dataFmt, "Left % Right", Left % Right );
    }

    public static void Main( )
    {
        Console.WriteLine( 
            "This example of the decimal multiplication, division, " +
            "and modulus \noperators generates the following " +
            "output. It displays the product, \nquotient, and " +
            "remainder of several pairs of decimal objects." );

        // Create pairs of decimal objects.
        ShowDecimalProQuoRem( 1000M, 7M );
        ShowDecimalProQuoRem( -1000M, 7M );
        ShowDecimalProQuoRem( 
            new decimal( 1230000000, 0, 0, false, 7 ), 0.0012300M );
        ShowDecimalProQuoRem( 12345678900000000M, 
            0.0000000012345678M );
        ShowDecimalProQuoRem( 123456789.0123456789M, 
            123456789.1123456789M );
    }
}

/*
This example of the decimal multiplication, division, and modulus
operators generates the following output. It displays the product,
quotient, and remainder of several pairs of decimal objects.

   decimal Left                                 1000
   decimal Right                                   7
   Left * Right                                 7000
   Left / Right       142.85714285714285714285714286
   Left % Right                                    6

   decimal Left                                -1000
   decimal Right                                   7
   Left * Right                                -7000
   Left / Right      -142.85714285714285714285714286
   Left % Right                                   -6

   decimal Left                          123.0000000
   decimal Right                           0.0012300
   Left * Right                     0.15129000000000
   Left / Right                               100000
   Left % Right                                    0

   decimal Left                    12345678900000000
   decimal Right                  0.0000000012345678
   Left * Right            15241577.6390794200000000
   Left / Right       10000000729000059778004901.796
   Left % Right                       0.000000000983

   decimal Left                 123456789.0123456789
   decimal Right                123456789.1123456789
   Left * Right       15241578765584515.651425087878
   Left / Right       0.9999999991899999933660999449
   Left % Right                 123456789.0123456789
*/
//</Snippet2>
