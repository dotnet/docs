//<Snippet3>
// Example of the BitConverter.GetBytes( ushort ) method.
using System;

class GetBytesUInt16Demo
{
    const string formatter = "{0,10}{1,13}";
 
    // Convert a ushort argument to a byte array and display it.
    public static void GetBytesUInt16( ushort argument )
    {
        byte[ ] byteArray = BitConverter.GetBytes( argument );
        Console.WriteLine( formatter, argument, 
            BitConverter.ToString( byteArray ) );
    }
       
    public static void Main( )
    {
        Console.WriteLine( 
            "This example of the BitConverter.GetBytes( ushort ) " +
            "\nmethod generates the following output.\n" );
        Console.WriteLine( formatter, "ushort", "byte array" );
        Console.WriteLine( formatter, "------", "----------" );
          
        // Convert ushort values and display the results.
        GetBytesUInt16( 15 );
        GetBytesUInt16( 1023 );
        GetBytesUInt16( 10000 );
        GetBytesUInt16( ushort.MinValue );
        GetBytesUInt16( (ushort)short.MaxValue );
        GetBytesUInt16( ushort.MaxValue );
    }
}

/*
This example of the BitConverter.GetBytes( ushort )
method generates the following output.

    ushort   byte array
    ------   ----------
        15        0F-00
      1023        FF-03
     10000        10-27
         0        00-00
     32767        FF-7F
     65535        FF-FF
*/
//</Snippet3>
