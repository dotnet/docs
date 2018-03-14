//<Snippet4>
// Example of the BitConverter.ToSingle method.
using System;

class BytesToSingleDemo
{
    const string formatter = "{0,5}{1,17}{2,18:E7}";
 
    // Convert four byte array elements to a float and display it.
    public static void BAToSingle( byte[ ] bytes, int index )
    {
        float value = BitConverter.ToSingle( bytes, index );

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
              0,   0,   0,   0, 128,  63,   0,   0, 112,  65, 
              0, 255, 127,  71,   0,   0, 128,  59,   0,   0, 
            128,  47,  73,  70, 131,   5,  75,   6, 158,  63, 
             77,   6, 158,  63,  80,   6, 158,  63,  30,  55, 
            190, 121, 255, 255, 127, 255, 255, 127, 127,   1, 
              0,   0,   0, 192, 255,   0,   0, 128, 255,   0, 
              0, 128, 127 };

        Console.WriteLine(
            "This example of the BitConverter.ToSingle( byte( ), " +
            "int ) \nmethod generates the following output. It " +
            "converts elements \nof a byte array to float values.\n" );

        WriteMultiLineByteArray( byteArray );

        Console.WriteLine( formatter, "index", "array elements", 
            "float" );
        Console.WriteLine( formatter, "-----", "--------------", 
            "-----" );
          
        // Convert byte array elements to float values.
        BAToSingle( byteArray, 0 );
        BAToSingle( byteArray, 2 );
        BAToSingle( byteArray, 6 );
        BAToSingle( byteArray, 10 );
        BAToSingle( byteArray, 14 );
        BAToSingle( byteArray, 18 );
        BAToSingle( byteArray, 22 );
        BAToSingle( byteArray, 26 );
        BAToSingle( byteArray, 30 );
        BAToSingle( byteArray, 34 );
        BAToSingle( byteArray, 38 );
        BAToSingle( byteArray, 42 );
        BAToSingle( byteArray, 45 );
        BAToSingle( byteArray, 49 );
        BAToSingle( byteArray, 51 );
        BAToSingle( byteArray, 55 );
        BAToSingle( byteArray, 59 );
    }
}

/*
This example of the BitConverter.ToSingle( byte( ), int )
method generates the following output. It converts elements
of a byte array to float values.

initial byte array
------------------
00-00-00-00-80-3F-00-00-70-41-00-FF-7F-47-00-00-80-3B-00-00-
80-2F-49-46-83-05-4B-06-9E-3F-4D-06-9E-3F-50-06-9E-3F-1E-37-
BE-79-FF-FF-7F-FF-FF-7F-7F-01-00-00-00-C0-FF-00-00-80-FF-00-
00-80-7F

index   array elements             float
-----   --------------             -----
    0      00-00-00-00    0.0000000E+000
    2      00-00-80-3F    1.0000000E+000
    6      00-00-70-41    1.5000000E+001
   10      00-FF-7F-47    6.5535000E+004
   14      00-00-80-3B    3.9062500E-003
   18      00-00-80-2F    2.3283064E-010
   22      49-46-83-05    1.2345000E-035
   26      4B-06-9E-3F    1.2345671E+000
   30      4D-06-9E-3F    1.2345673E+000
   34      50-06-9E-3F    1.2345676E+000
   38      1E-37-BE-79    1.2345679E+035
   42      FF-FF-7F-FF   -3.4028235E+038
   45      FF-FF-7F-7F    3.4028235E+038
   49      01-00-00-00    1.4012985E-045
   51      00-00-C0-FF               NaN
   55      00-00-80-FF         -Infinity
   59      00-00-80-7F          Infinity
*/
//</Snippet4>
