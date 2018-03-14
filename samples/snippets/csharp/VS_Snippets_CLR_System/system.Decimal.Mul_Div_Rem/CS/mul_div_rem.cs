//<Snippet1>
// Example of the decimal.Multiply, decimal.Divide, and 
// decimal.Remainder methods. 
using System;
using Microsoft.VisualBasic;

class DecimalMulDivRemDemo
{
    const string dataFmt = "{0,-35}{1,31}";

    // Display decimal parameters and their product, quotient, and 
    // remainder.
    public static void ShowDecimalProQuoRem( decimal Left, decimal Right )
    {
        Console.WriteLine( );
        Console.WriteLine( dataFmt, "decimal Left", Left );
        Console.WriteLine( dataFmt, "decimal Right", Right );
        Console.WriteLine( dataFmt, "decimal.Multiply( Left, Right )", 
            decimal.Multiply( Left, Right ) );
        Console.WriteLine( dataFmt, "decimal.Divide( Left, Right )", 
            decimal.Divide( Left, Right ) );
        Console.WriteLine( dataFmt, "decimal.Remainder( Left, Right )", 
            decimal.Remainder( Left, Right ) );
    }

    public static void Main( )
    {
        Console.WriteLine( "This example of the \n" +
            "  decimal.Multiply( decimal, decimal ), \n" +
            "  decimal.Divide( decimal, decimal ), and \n" +
            "  decimal.Remainder( decimal, decimal ) \n" +
            "methods generates the following output. It displays " +
            "the product, \nquotient, and remainder of several " +
            "pairs of decimal objects." );

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
This example of the
  decimal.Multiply( decimal, decimal ),
  decimal.Divide( decimal, decimal ), and
  decimal.Remainder( decimal, decimal )
methods generates the following output. It displays the product,
quotient, and remainder of several pairs of decimal objects.

decimal Left                                                  1000
decimal Right                                                    7
decimal.Multiply( Left, Right )                               7000
decimal.Divide( Left, Right )       142.85714285714285714285714286
decimal.Remainder( Left, Right )                                 6

decimal Left                                                 -1000
decimal Right                                                    7
decimal.Multiply( Left, Right )                              -7000
decimal.Divide( Left, Right )      -142.85714285714285714285714286
decimal.Remainder( Left, Right )                                -6

decimal Left                                           123.0000000
decimal Right                                            0.0012300
decimal.Multiply( Left, Right )                   0.15129000000000
decimal.Divide( Left, Right )                               100000
decimal.Remainder( Left, Right )                                 0

decimal Left                                     12345678900000000
decimal Right                                   0.0000000012345678
decimal.Multiply( Left, Right )          15241577.6390794200000000
decimal.Divide( Left, Right )       10000000729000059778004901.796
decimal.Remainder( Left, Right )                    0.000000000983

decimal Left                                  123456789.0123456789
decimal Right                                 123456789.1123456789
decimal.Multiply( Left, Right )     15241578765584515.651425087878
decimal.Divide( Left, Right )       0.9999999991899999933660999449
decimal.Remainder( Left, Right )              123456789.0123456789
*/
//</Snippet1>
