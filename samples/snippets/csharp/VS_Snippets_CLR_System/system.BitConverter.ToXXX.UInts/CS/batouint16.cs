//<Snippet1>
// Example of the BitConverter.ToUInt16 method.
using System;

class BytesToUInt16Demo
{
    const string formatter = "{0,5}{1,17}{2,10}";
 
    // Convert two byte array elements to a ushort and display it.
    public static void BAToUInt16( byte[ ] bytes, int index )
    {
        ushort value = BitConverter.ToUInt16( bytes, index );

        Console.WriteLine( formatter, index, 
            BitConverter.ToString( bytes, index, 2 ), value );
    }
       
    public static void Main( )
    {
        byte[] byteArray = {
            15, 0, 0, 255, 3, 16, 39, 255, 255, 127 };

        Console.WriteLine( 
            "This example of the BitConverter.ToUInt16( byte[ ], " +
            "int ) \nmethod generates the following output. It " +
            "converts elements \nof a byte array to ushort values.\n" );
        Console.WriteLine( "initial byte array" );
        Console.WriteLine( "------------------" );
        Console.WriteLine( BitConverter.ToString( byteArray ) );
        Console.WriteLine( );
        Console.WriteLine( formatter, "index", "array elements", 
            "ushort" );
        Console.WriteLine( formatter, "-----", "--------------", 
            "------" );
          
        // Convert byte array elements to ushort values.
        BAToUInt16( byteArray, 1 );
        BAToUInt16( byteArray, 0 );
        BAToUInt16( byteArray, 3 );
        BAToUInt16( byteArray, 5 );
        BAToUInt16( byteArray, 8 );
        BAToUInt16( byteArray, 7 );
    }
}

/*
This example of the BitConverter.ToUInt16( byte[ ], int )
method generates the following output. It converts elements
of a byte array to ushort values.

initial byte array
------------------
0F-00-00-FF-03-10-27-FF-FF-7F

index   array elements    ushort
-----   --------------    ------
    1            00-00         0
    0            0F-00        15
    3            FF-03      1023
    5            10-27     10000
    8            FF-7F     32767
    7            FF-FF     65535
*/
//</Snippet1>
