
//<Snippet3>
// Example of the BitConverter::GetBytes( unsigned short ) method.
using namespace System;

// Convert an unsigned short argument to a byte array and display it.
void GetBytesUInt16( unsigned short argument )
{
   array<Byte>^byteArray = BitConverter::GetBytes( argument );
   Console::WriteLine( "{0,14}{1,13}", argument, BitConverter::ToString( byteArray ) );
}

int main()
{
   Console::WriteLine( "This example of the BitConverter::GetBytes( unsigned "
   "short ) \nmethod generates the following output.\n" );
   Console::WriteLine( "{0,14}{1,13}", "unsigned short", "byte array" );
   Console::WriteLine( "{0,14}{1,13}", "--------------", "----------" );
   
   // Convert unsigned short values and display the results.
   GetBytesUInt16( 15 );
   GetBytesUInt16( 1023 );
   GetBytesUInt16( 10000 );
   GetBytesUInt16( UInt16::MinValue );
   GetBytesUInt16( Int16::MaxValue );
   GetBytesUInt16( UInt16::MaxValue );
}

/*
This example of the BitConverter::GetBytes( unsigned short )
method generates the following output.

unsigned short   byte array
--------------   ----------
            15        0F-00
          1023        FF-03
         10000        10-27
             0        00-00
         32767        FF-7F
         65535        FF-FF
*/
//</Snippet3>
