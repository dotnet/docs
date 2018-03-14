//<Snippet1>
// Example of the BitConverter.GetBytes( ulong ) method.
using System;

class GetBytesUInt64Demo
{
    const string formatter = "{0,22}{1,30}";
 
    // Convert a ulong argument to a byte array and display it.
    public static void GetBytesUInt64( ulong argument )
    {
        byte[ ] byteArray = BitConverter.GetBytes( argument );
        Console.WriteLine( formatter, argument, 
            BitConverter.ToString( byteArray ) );
    }
       
    public static void Main( )
    {
        Console.WriteLine( 
            "This example of the BitConverter.GetBytes( ulong ) " +
            "\nmethod generates the following output.\n" );
        Console.WriteLine( formatter, "ulong", "byte array" );
        Console.WriteLine( formatter, "-----", "----------" );
          
        // Convert ulong values and display the results.
        GetBytesUInt64( 0xFFFFFF );
        GetBytesUInt64( 1000000000 );
        GetBytesUInt64( 0x100000000 );
        GetBytesUInt64( 0xAAAAAAAAAAAA );
        GetBytesUInt64( 1000000000000000000 );
        GetBytesUInt64( 10000000000000000000 );
        GetBytesUInt64( ulong.MinValue );
        GetBytesUInt64( long.MaxValue );
        GetBytesUInt64( ulong.MaxValue );
    }
}

/*
This example of the BitConverter.GetBytes( ulong )
method generates the following output.

                 ulong                    byte array
                 -----                    ----------
              16777215       FF-FF-FF-00-00-00-00-00
            1000000000       00-CA-9A-3B-00-00-00-00
            4294967296       00-00-00-00-01-00-00-00
       187649984473770       AA-AA-AA-AA-AA-AA-00-00
   1000000000000000000       00-00-64-A7-B3-B6-E0-0D
  10000000000000000000       00-00-E8-89-04-23-C7-8A
                     0       00-00-00-00-00-00-00-00
   9223372036854775807       FF-FF-FF-FF-FF-FF-FF-7F
  18446744073709551615       FF-FF-FF-FF-FF-FF-FF-FF
*/
//</Snippet1>
