//<Snippet2>
// Example of the BitConverter.ToInt32 method.
using System;

class BytesToInt32Demo
{
    const string formatter = "{0,5}{1,17}{2,15}";
 
    // Convert four byte array elements to an int and display it.
    public static void BAToInt32( byte[ ] bytes, int index )
    {
        int value = BitConverter.ToInt32( bytes, index );

        Console.WriteLine( formatter, index, 
            BitConverter.ToString( bytes, index, 4 ), value );
    }

    // Display a byte array, using multiple lines if necessary.
    public static void WriteMultiLineByteArray( byte[ ] bytes )
    {
        const int rowSize = 20;
        int iter;

        Console.WriteLine( "initial byte array" );
        Console.WriteLine( "------------------" );

        for( iter = 0; iter < bytes.Length - rowSize; iter += rowSize )
        {
            Console.Write( 
                BitConverter.ToString( bytes, iter, rowSize ) );
            Console.WriteLine( "-" );
        }

        Console.WriteLine( BitConverter.ToString( bytes, iter ) );
        Console.WriteLine( );
    }

    public static void Main( )
    {
        byte[ ] byteArray = {
             15,   0,   0,   0,   0, 128,   0,   0,  16,   0, 
              0, 240, 255,   0, 202, 154,  59,   0,  54, 101, 
            196, 241, 255, 255, 255, 127 };

        Console.WriteLine( 
            "This example of the BitConverter.ToInt32( byte[ ], " +
            "int ) \nmethod generates the following output. It " +
            "converts elements \nof a byte array to int values.\n" );

        WriteMultiLineByteArray( byteArray );

        Console.WriteLine( formatter, "index", "array elements", 
            "int" );
        Console.WriteLine( formatter, "-----", "--------------", 
            "---" );
          
        // Convert byte array elements to int values.
        BAToInt32( byteArray, 1 );
        BAToInt32( byteArray, 0 );
        BAToInt32( byteArray, 21 );
        BAToInt32( byteArray, 6 );
        BAToInt32( byteArray, 9 );
        BAToInt32( byteArray, 13 );
        BAToInt32( byteArray, 17 );
        BAToInt32( byteArray, 22 );
        BAToInt32( byteArray, 2 );
    }
}

/*
This example of the BitConverter.ToInt32( byte[ ], int )
method generates the following output. It converts elements
of a byte array to int values.

initial byte array
------------------
0F-00-00-00-00-80-00-00-10-00-00-F0-FF-00-CA-9A-3B-00-36-65-
C4-F1-FF-FF-FF-7F

index   array elements            int
-----   --------------            ---
    1      00-00-00-00              0
    0      0F-00-00-00             15
   21      F1-FF-FF-FF            -15
    6      00-00-10-00        1048576
    9      00-00-F0-FF       -1048576
   13      00-CA-9A-3B     1000000000
   17      00-36-65-C4    -1000000000
   22      FF-FF-FF-7F     2147483647
    2      00-00-00-80    -2147483648
*/
//</Snippet2>
