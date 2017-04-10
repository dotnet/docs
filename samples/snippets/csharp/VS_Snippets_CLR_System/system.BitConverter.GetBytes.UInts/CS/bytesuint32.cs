//<Snippet2>
// Example of the BitConverter.GetBytes( uint ) method.
using System;

class GetBytesUInt32Demo
{
    const string formatter = "{0,16}{1,20}";
 
    // Convert a uint argument to a byte array and display it.
    public static void GetBytesUInt32( uint argument )
    {
        byte[ ] byteArray = BitConverter.GetBytes( argument );
        Console.WriteLine( formatter, argument, 
            BitConverter.ToString( byteArray ) );
    }
       
    public static void Main( )
    {
        Console.WriteLine( 
            "This example of the BitConverter.GetBytes( uint ) " +
            "\nmethod generates the following output.\n" );
        Console.WriteLine( formatter, "uint", "byte array" );
        Console.WriteLine( formatter, "----", "----------" );
          
        // Convert uint values and display the results.
        GetBytesUInt32( 15 );
        GetBytesUInt32( 1023 );
        GetBytesUInt32( 0x100000 );
        GetBytesUInt32( 1000000000 );
        GetBytesUInt32( uint.MinValue );
        GetBytesUInt32( int.MaxValue );
        GetBytesUInt32( uint.MaxValue );
    }
}

/*
This example of the BitConverter.GetBytes( uint )
method generates the following output.

            uint          byte array
            ----          ----------
              15         0F-00-00-00
            1023         FF-03-00-00
         1048576         00-00-10-00
      1000000000         00-CA-9A-3B
               0         00-00-00-00
      2147483647         FF-FF-FF-7F
      4294967295         FF-FF-FF-FF
*/
//</Snippet2>
