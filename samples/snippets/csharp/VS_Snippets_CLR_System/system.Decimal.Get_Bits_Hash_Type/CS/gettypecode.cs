//<Snippet3>
// Example of the decimal.GetTypeCode method. 
using System;

class DecimalGetTypeCodeDemo
{
    public static void Main( )
    {
        Console.WriteLine( "This example of the " +
            "decimal.GetTypeCode( ) \nmethod " +
            "generates the following output.\n" );

        // Create a decimal object and get its type code.
        decimal aDecimal = new decimal( 1.0 );
        TypeCode typCode = aDecimal.GetTypeCode( );

        Console.WriteLine( "Type Code:      \"{0}\"", typCode );
        Console.WriteLine( "Numeric value:  {0}", (int)typCode );
    }
}

/*
This example of the decimal.GetTypeCode( )
method generates the following output.

Type Code:      "Decimal"
Numeric value:  15
*/
//</Snippet3>
