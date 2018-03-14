//<Snippet2>
// Example of the BitConverter.ToChar method.
using System;

class BytesToCharDemo
{
    const string formatter = "{0,5}{1,17}{2,8}";
 
    // Convert two byte array elements to a char and display it.
    public static void BAToChar( byte[] bytes, int index )
    {
        char value = BitConverter.ToChar( bytes, index );

        Console.WriteLine( formatter, index, 
            BitConverter.ToString( bytes, index, 2 ), value );
    }
       
    public static void Main( )
    {
        byte[] byteArray = {
             32,   0,   0,  42,   0,  65,   0, 125,   0, 
            197,   0, 168,   3,  41,   4, 172,  32 };

        Console.WriteLine( 
            "This example of the BitConverter.ToChar( byte[ ], " +
            "int ) \nmethod generates the following output. It " +
            "converts \nelements of a byte array to char values.\n" );
        Console.WriteLine( "initial byte array" );
        Console.WriteLine( "------------------" );
        Console.WriteLine( BitConverter.ToString( byteArray ) );
        Console.WriteLine( );
        Console.WriteLine( formatter, "index", "array elements", "char" );
        Console.WriteLine( formatter, "-----", "--------------", "----" );
          
        // Convert byte array elements to char values.
        BAToChar( byteArray, 0 );
        BAToChar( byteArray, 1 );
        BAToChar( byteArray, 3 );
        BAToChar( byteArray, 5 );
        BAToChar( byteArray, 7 );
        BAToChar( byteArray, 9 );
        BAToChar( byteArray, 11 );
        BAToChar( byteArray, 13 );
        BAToChar( byteArray, 15 );
    }
}

/*
This example of the BitConverter.ToChar( byte[ ], int )
method generates the following output. It converts
elements of a byte array to char values.

initial byte array
------------------
20-00-00-2A-00-41-00-7D-00-C5-00-A8-03-29-04-AC-20

index   array elements    char
-----   --------------    ----
    0            20-00
    1            00-00
    3            2A-00       *
    5            41-00       A
    7            7D-00       }
    9            C5-00       Å
   11            A8-03       ?
   13            29-04       ?
   15            AC-20       ?
*/
//</Snippet2>
