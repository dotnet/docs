
//<Snippet2>
// Example of the BitConverter::GetBytes( unsigned int ) method.
using namespace System;

// Convert an unsigned int argument to a byte array and display it.
void GetBytesUInt32( unsigned int argument )
{
   array<Byte>^byteArray = BitConverter::GetBytes( argument );
   Console::WriteLine( "{0,16}{1,20}", argument, BitConverter::ToString( byteArray ) );
}

int main()
{
   Console::WriteLine( "This example of the BitConverter::GetBytes( unsigned "
   "int ) \nmethod generates the following output.\n" );
   Console::WriteLine( "{0,16}{1,20}", "unsigned int", "byte array" );
   Console::WriteLine( "{0,16}{1,20}", "------------", "----------" );
   
   // Convert unsigned int values and display the results.
   GetBytesUInt32( 15 );
   GetBytesUInt32( 1023 );
   GetBytesUInt32( 0x100000 );
   GetBytesUInt32( 1000000000 );
   GetBytesUInt32( UInt32::MinValue );
   GetBytesUInt32( Int32::MaxValue );
   GetBytesUInt32( UInt32::MaxValue );
}

/*
This example of the BitConverter::GetBytes( unsigned int )
method generates the following output.

    unsigned int          byte array
    ------------          ----------
              15         0F-00-00-00
            1023         FF-03-00-00
         1048576         00-00-10-00
      1000000000         00-CA-9A-3B
               0         00-00-00-00
      2147483647         FF-FF-FF-7F
      4294967295         FF-FF-FF-FF
*/
//</Snippet2>
