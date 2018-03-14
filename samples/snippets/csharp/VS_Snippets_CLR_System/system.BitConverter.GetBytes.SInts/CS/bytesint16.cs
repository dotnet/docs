//<Snippet3>
// Example of the BitConverter.GetBytes( short ) method.
using System;

class GetBytesInt16Demo
{
    const string formatter = "{0,10}{1,13}";
 
    // Convert a short argument to a byte array and display it.
    public static void GetBytesInt16( short argument )
    {
        byte[ ] byteArray = BitConverter.GetBytes( argument );
        Console.WriteLine( formatter, argument, 
            BitConverter.ToString( byteArray ) );
    }
       
    public static void Main( )
    {
        Console.WriteLine( 
            "This example of the BitConverter.GetBytes( short ) " +
            "\nmethod generates the following output.\n" );
        Console.WriteLine( formatter, "short", "byte array" );
        Console.WriteLine( formatter, "-----", "----------" );
          
        // Convert short values and display the results.
        GetBytesInt16( 0 );
        GetBytesInt16( 15 );
        GetBytesInt16( -15 );
        GetBytesInt16( 10000 );
        GetBytesInt16( -10000 );
        GetBytesInt16( short.MinValue );
        GetBytesInt16( short.MaxValue );
    }
}

/*
This example of the BitConverter.GetBytes( short )
method generates the following output.

     short   byte array
     -----   ----------
         0        00-00
        15        0F-00
       -15        F1-FF
     10000        10-27
    -10000        F0-D8
    -32768        00-80
     32767        FF-7F
*/
//</Snippet3>
