//<Snippet3>
// Example of the BitConverter.ToUInt64 method.
using System;

class BytesToUInt64Demo
{
    const string formatter = "{0,5}{1,27}{2,24}";
 
    // Convert eight byte array elements to a ulong and display it.
    public static void BAToUInt64( byte[ ] bytes, int index )
    {
        ulong value = BitConverter.ToUInt64( bytes, index );

        Console.WriteLine( formatter, index, 
            BitConverter.ToString( bytes, index, 8 ), value );
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
            255, 255, 255,   0,   0,   0,   0,   0,   0,   0, 
              0,   1,   0,   0,   0, 100, 167, 179, 182, 224, 
             13,   0, 202, 154,  59,   0,   0,   0,   0, 170, 
            170, 170, 170, 170, 170,   0,   0, 232, 137,   4, 
             35, 199, 138, 255, 255, 255, 255, 255, 255, 255, 
            255, 127 };

        Console.WriteLine( 
            "This example of the BitConverter.ToUInt64( byte[ ], " +
            "int ) \nmethod generates the following output. It " +
            "converts elements \nof a byte array to ulong values.\n" );

        WriteMultiLineByteArray( byteArray );

        Console.WriteLine( formatter, "index", "array elements", 
            "ulong" );
        Console.WriteLine( formatter, "-----", "--------------", 
            "------" );
          
        // Convert byte array elements to ulong values.
        BAToUInt64( byteArray, 3 );
        BAToUInt64( byteArray, 0 );
        BAToUInt64( byteArray, 21 );
        BAToUInt64( byteArray, 7 );
        BAToUInt64( byteArray, 29 );
        BAToUInt64( byteArray, 13 );
        BAToUInt64( byteArray, 35 );
        BAToUInt64( byteArray, 44 );
        BAToUInt64( byteArray, 43 );
    }
}

/*
This example of the BitConverter.ToUInt64( byte[ ], int )
method generates the following output. It converts elements
of a byte array to ulong values.

initial byte array
------------------
FF-FF-FF-00-00-00-00-00-00-00-00-01-00-00-00-64-A7-B3-B6-E0-
0D-00-CA-9A-3B-00-00-00-00-AA-AA-AA-AA-AA-AA-00-00-E8-89-04-
23-C7-8A-FF-FF-FF-FF-FF-FF-FF-FF-7F

index             array elements                   ulong
-----             --------------                  ------
    3    00-00-00-00-00-00-00-00                       0
    0    FF-FF-FF-00-00-00-00-00                16777215
   21    00-CA-9A-3B-00-00-00-00              1000000000
    7    00-00-00-00-01-00-00-00              4294967296
   29    AA-AA-AA-AA-AA-AA-00-00         187649984473770
   13    00-00-64-A7-B3-B6-E0-0D     1000000000000000000
   35    00-00-E8-89-04-23-C7-8A    10000000000000000000
   44    FF-FF-FF-FF-FF-FF-FF-7F     9223372036854775807
   43    FF-FF-FF-FF-FF-FF-FF-FF    18446744073709551615
*/
//</Snippet3>
