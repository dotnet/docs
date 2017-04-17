
//<Snippet1>
// Example of the BitConverter::GetBytes( unsigned __int64 ) method.
using namespace System;

// Convert an unsigned __int64 argument to a byte array and display it.
void GetBytesUInt64( unsigned __int64 argument )
{
   array<Byte>^byteArray = BitConverter::GetBytes( argument );
   Console::WriteLine( "{0,22}{1,30}", argument, BitConverter::ToString( byteArray ) );
}

int main()
{
   Console::WriteLine( "This example of the BitConverter::GetBytes( unsigned "
   "__int64 ) \nmethod generates the following output.\n" );
   Console::WriteLine( "{0,22}{1,30}", "unsigned __int64", "byte array" );
   Console::WriteLine( "{0,22}{1,30}", "----------------", "----------" );
   
   // Convert unsigned __int64 values and display the results.
   GetBytesUInt64( 0xFFFFFF );
   GetBytesUInt64( 1000000000 );
   GetBytesUInt64( 0x100000000 );
   GetBytesUInt64( 0xAAAAAAAAAAAA );
   GetBytesUInt64( 1000000000000000000 );
   GetBytesUInt64( 10000000000000000000 );
   GetBytesUInt64( UInt64::MinValue );
   GetBytesUInt64( Int64::MaxValue );
   GetBytesUInt64( UInt64::MaxValue );
}

/*
This example of the BitConverter::GetBytes( unsigned __int64 )
method generates the following output.

      unsigned __int64                    byte array
      ----------------                    ----------
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
