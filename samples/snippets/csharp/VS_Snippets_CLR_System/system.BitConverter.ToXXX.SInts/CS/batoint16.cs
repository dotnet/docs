//<Snippet1>
// Example of the BitConverter.ToInt16 method.
using System;

class BytesToInt16Demo
{
    const string formatter = "{0,5}{1,17}{2,10}";
 
    // Convert two byte array elements to a short and display it.
    public static void BAToInt16( byte[ ] bytes, int index )
    {
        short value = BitConverter.ToInt16( bytes, index );

        Console.WriteLine( formatter, index, 
            BitConverter.ToString( bytes, index, 2 ), value );
    }
       
    public static void Main( )
    {
        byte[ ] byteArray = 
            { 15, 0, 0, 128, 16, 39, 240, 216, 241, 255, 127 };

        Console.WriteLine( 
            "This example of the BitConverter.ToInt16( byte[ ], " +
            "int ) \nmethod generates the following output. It " +
            "converts elements \nof a byte array to short values.\n" );
        Console.WriteLine( "initial byte array" );
        Console.WriteLine( "------------------" );
        Console.WriteLine( BitConverter.ToString( byteArray ) );
        Console.WriteLine( );
        Console.WriteLine( formatter, "index", "array elements", "short" );
        Console.WriteLine( formatter, "-----", "--------------", "-----" );
          
        // Convert byte array elements to short values.
        BAToInt16( byteArray, 1 );
        BAToInt16( byteArray, 0 );
        BAToInt16( byteArray, 8 );
        BAToInt16( byteArray, 4 );
        BAToInt16( byteArray, 6 );
        BAToInt16( byteArray, 9 );
        BAToInt16( byteArray, 2 );
    }
}

/*
This example of the BitConverter.ToInt16( byte[ ], int )
method generates the following output. It converts elements
of a byte array to short values.

initial byte array
------------------
0F-00-00-80-10-27-F0-D8-F1-FF-7F

index   array elements     short
-----   --------------     -----
    1            00-00         0
    0            0F-00        15
    8            F1-FF       -15
    4            10-27     10000
    6            F0-D8    -10000
    9            FF-7F     32767
    2            00-80    -32768
*/
//</Snippet1>
