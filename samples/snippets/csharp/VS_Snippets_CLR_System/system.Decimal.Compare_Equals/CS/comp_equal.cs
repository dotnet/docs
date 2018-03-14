//<Snippet2>
// Example of the decimal.Compare and static decimal.Equals methods.
using System;

class DecCompareEqualsDemo
{
    const string dataFmt = "{0,-45}{1}";

    // Compare decimal parameters, and display them with the results.
    public static void CompareDecimals( decimal Left, decimal Right, 
        string RightText )
    {
        Console.WriteLine( );
        Console.WriteLine( dataFmt, "Right: "+RightText, Right );
        Console.WriteLine( dataFmt, "decimal.Equals( Left, Right )", 
            Decimal.Equals( Left, Right ) );
        Console.WriteLine( dataFmt, "decimal.Compare( Left, Right )", 
            Decimal.Compare( Left, Right ) );
    }

    public static void Main( )
    {
        Console.WriteLine( "This example of the " +
            "decimal.Equals( decimal, decimal ) and \n" +
            "decimal.Compare( decimal, decimal ) methods " +
            "generates the \nfollowing output. It creates several " +
            "different decimal \nvalues and compares them with " +
            "the following reference value.\n" );

        // Create a reference decimal value.
        decimal Left = new decimal( 123.456 );

        Console.WriteLine( dataFmt, "Left: decimal( 123.456 )", 
            Left );

        // Create decimal values to compare with the reference.
        CompareDecimals( Left, new decimal( 1.2345600E+2 ), 
            "decimal( 1.2345600E+2 )" );
        CompareDecimals( Left, 123.4561M, "123.4561M" );
        CompareDecimals( Left, 123.4559M, "123.4559M" );
        CompareDecimals( Left, 123.456000M, "123.456000M" );
        CompareDecimals( Left, 
            new decimal( 123456000, 0, 0, false, 6 ), 
            "decimal( 123456000, 0, 0, false, 6 )" );
    }
}

/*
This example of the decimal.Equals( decimal, decimal ) and
decimal.Compare( decimal, decimal ) methods generates the
following output. It creates several different decimal
values and compares them with the following reference value.

Left: decimal( 123.456 )                     123.456

Right: decimal( 1.2345600E+2 )               123.456
decimal.Equals( Left, Right )                True
decimal.Compare( Left, Right )               0

Right: 123.4561M                             123.4561
decimal.Equals( Left, Right )                False
decimal.Compare( Left, Right )               -1

Right: 123.4559M                             123.4559
decimal.Equals( Left, Right )                False
decimal.Compare( Left, Right )               1

Right: 123.456000M                           123.456000
decimal.Equals( Left, Right )                True
decimal.Compare( Left, Right )               0

Right: decimal( 123456000, 0, 0, false, 6 )  123.456000
decimal.Equals( Left, Right )                True
decimal.Compare( Left, Right )               0
*/ 
//</Snippet2>
