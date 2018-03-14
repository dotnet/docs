//<Snippet1>
// Example of the decimal.CompareTo and decimal.Equals instance 
// methods.
using System;

class DecCompToEqualsObjDemo
{
    // Get the exception type name; remove the namespace prefix.
    public static string GetExceptionType( Exception ex )
    {
        string exceptionType = ex.GetType( ).ToString( );
        return exceptionType.Substring( 
            exceptionType.LastIndexOf( '.' ) + 1 );
    }

    // Compare the decimal to the object parameters, 
    // and display the object parameters with the results.
    public static void CompDecimalToObject( decimal Left, 
        object Right, string RightText )
    {

        Console.WriteLine( "{0,-46}{1}", "object: "+RightText, 
            Right );
        Console.WriteLine( "{0,-46}{1}", "Left.Equals( object )", 
            Left.Equals( Right ) );
        Console.Write( "{0,-46}", "Left.CompareTo( object )" );

        try
        {
            // Catch the exception if CompareTo( ) throws one.
            Console.WriteLine( "{0}\n", Left.CompareTo( Right ) );
        }
        catch( Exception ex )
        {
            Console.WriteLine( "{0}\n", GetExceptionType( ex ) );
        }
    }

    public static void Main( )
    {
        Console.WriteLine( 
            "This example of the decimal.Equals( object ) and \n" +
            "decimal.CompareTo( object ) methods generates the \n" +
            "following output. It creates several different " +
            "decimal \nvalues and compares them with the following " +
            "reference value.\n" );

        // Create a reference decimal value.
        decimal Left = new decimal( 987.654 );

        Console.WriteLine( "{0,-46}{1}\n", 
            "Left: decimal( 987.654 )", Left );

        // Create objects to compare with the reference.
        CompDecimalToObject( Left, new decimal( 9.8765400E+2 ), 
            "decimal( 9.8765400E+2 )" );
        CompDecimalToObject( Left, 987.6541M, "987.6541D" );
        CompDecimalToObject( Left, 987.6539M, "987.6539D" );
        CompDecimalToObject( Left, 
            new decimal( 987654000, 0, 0, false, 6 ), 
            "decimal( 987654000, 0, 0, false, 6 )" );
        CompDecimalToObject( Left, 9.8765400E+2, 
            "Double 9.8765400E+2" );
        CompDecimalToObject( Left, "987.654", "String \"987.654\"" );
    }
}

/*
This example of the decimal.Equals( object ) and
decimal.CompareTo( object ) methods generates the
following output. It creates several different decimal
values and compares them with the following reference value.

Left: decimal( 987.654 )                      987.654

object: decimal( 9.8765400E+2 )               987.654
Left.Equals( object )                         True
Left.CompareTo( object )                      0

object: 987.6541D                             987.6541
Left.Equals( object )                         False
Left.CompareTo( object )                      -1

object: 987.6539D                             987.6539
Left.Equals( object )                         False
Left.CompareTo( object )                      1

object: decimal( 987654000, 0, 0, false, 6 )  987.654000
Left.Equals( object )                         True
Left.CompareTo( object )                      0

object: Double 9.8765400E+2                   987.654
Left.Equals( object )                         False
Left.CompareTo( object )                      ArgumentException

object: String "987.654"                      987.654
Left.Equals( object )                         False
Left.CompareTo( object )                      ArgumentException
*/ 
//</Snippet1>
