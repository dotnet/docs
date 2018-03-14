//<Snippet2>
// Example of the decimal.Round method. 
using System;

class DecimalRoundDemo
{
    const string dataFmt = "{0,26}{1,8}{2,26}";

    // Display decimal.Round parameters and the result.
    public static void ShowDecimalRound( decimal Argument, int Digits )
    {
        decimal rounded = decimal.Round( Argument, Digits );

        Console.WriteLine( dataFmt, Argument, Digits, rounded );
    }

    public static void Main( )
    {
        Console.WriteLine( "This example of the " +
            "decimal.Round( decimal, Integer ) \n" +
            "method generates the following output.\n" );
        Console.WriteLine( dataFmt, "Argument", "Digits", "Result" );
        Console.WriteLine( dataFmt, "--------", "------", "------" );

        // Create pairs of decimal objects.
        ShowDecimalRound( 1.45M, 1 );
        ShowDecimalRound( 1.55M, 1 );
        ShowDecimalRound( 123.456789M, 4 );
        ShowDecimalRound( 123.456789M, 6 );
        ShowDecimalRound( 123.456789M, 8 );
        ShowDecimalRound( -123.456M, 0 );
        ShowDecimalRound( 
            new decimal( 1230000000, 0, 0, true, 7 ), 3 );
        ShowDecimalRound( 
            new decimal( 1230000000, 0, 0, true, 7 ), 11 );
        ShowDecimalRound( -9999999999.9999999999M, 9 );
        ShowDecimalRound( -9999999999.9999999999M, 10 );
    }
}

/*
This example of the decimal.Round( decimal, Integer )
method generates the following output.

                  Argument  Digits                    Result
                  --------  ------                    ------
                      1.45       1                       1.4
                      1.55       1                       1.6
                123.456789       4                  123.4568
                123.456789       6                123.456789
                123.456789       8                123.456789
                  -123.456       0                      -123
              -123.0000000       3                  -123.000
              -123.0000000      11              -123.0000000
    -9999999999.9999999999       9    -10000000000.000000000
    -9999999999.9999999999      10    -9999999999.9999999999
*/
//</Snippet2>
