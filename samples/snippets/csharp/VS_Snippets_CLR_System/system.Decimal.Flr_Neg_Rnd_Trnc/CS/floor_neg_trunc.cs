//<Snippet1>
// Example of the decimal.Negate, decimal.Floor, and decimal.Truncate 
// methods. 
using System;

class DecimalFloorNegTruncDemo
{
    const string dataFmt = "{0,-30}{1,26}";

    // Display decimal parameters and the method results.
    public static void ShowDecimalFloorNegTrunc( decimal Argument )
    {
        Console.WriteLine( );
        Console.WriteLine( dataFmt, "decimal Argument", Argument );
        Console.WriteLine( dataFmt, "decimal.Negate( Argument )", 
            decimal.Negate( Argument ) );
        Console.WriteLine( dataFmt, "decimal.Floor( Argument )", 
            decimal.Floor( Argument ) );
        Console.WriteLine( dataFmt, "decimal.Truncate( Argument )", 
            decimal.Truncate( Argument ) );
    }

    public static void Main( )
    {
        Console.WriteLine( "This example of the \n" +
            "  decimal.Negate( decimal ), \n" +
            "  decimal.Floor( decimal ), and \n" +
            "  decimal.Truncate( decimal ) \n" +
            "methods generates the following output." );

        // Create pairs of decimal objects.
        ShowDecimalFloorNegTrunc( 0M );
        ShowDecimalFloorNegTrunc( 123.456M );
        ShowDecimalFloorNegTrunc( -123.456M );
        ShowDecimalFloorNegTrunc( 
            new decimal( 1230000000, 0, 0, true, 7 ) );
        ShowDecimalFloorNegTrunc( -9999999999.9999999999M );
    }
}

/*
This example of the
  decimal.Negate( decimal ),
  decimal.Floor( decimal ), and
  decimal.Truncate( decimal )
methods generates the following output.

decimal Argument                                       0
decimal.Negate( Argument )                             0
decimal.Floor( Argument )                              0
decimal.Truncate( Argument )                           0

decimal Argument                                 123.456
decimal.Negate( Argument )                      -123.456
decimal.Floor( Argument )                            123
decimal.Truncate( Argument )                         123

decimal Argument                                -123.456
decimal.Negate( Argument )                       123.456
decimal.Floor( Argument )                           -124
decimal.Truncate( Argument )                        -123

decimal Argument                            -123.0000000
decimal.Negate( Argument )                   123.0000000
decimal.Floor( Argument )                           -123
decimal.Truncate( Argument )                        -123

decimal Argument                  -9999999999.9999999999
decimal.Negate( Argument )         9999999999.9999999999
decimal.Floor( Argument )                   -10000000000
decimal.Truncate( Argument )                 -9999999999
*/ 
//</Snippet1>
