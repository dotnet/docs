
//<Snippet2>
// Example of the BitConverter::ToUInt32 method.
using namespace System;

// Convert four byte array elements to an unsigned int and display it.
void BAToUInt32( array<unsigned char>^bytes, int index )
{
   unsigned int value = BitConverter::ToUInt32( bytes, index );
   Console::WriteLine( "{0,5}{1,17}{2,15}", index, BitConverter::ToString( bytes, index, 4 ), value );
}

int main()
{
   array<unsigned char>^byteArray = {15,0,0,0,0,16,0,255,3,0,0,202,154,59,255,255,255,255,127};
   Console::WriteLine( "This example of the BitConverter::ToUInt32( unsigned "
   "char[ ], int ) \nmethod generates the following output. It "
   "converts elements of a \nbyte array to unsigned int "
   "values.\n" );
   Console::WriteLine( "initial byte array" );
   Console::WriteLine( "------------------" );
   Console::WriteLine( BitConverter::ToString( byteArray ) );
   Console::WriteLine();
   Console::WriteLine( "{0,5}{1,17}{2,15}", "index", "array elements", "unsigned int" );
   Console::WriteLine( "{0,5}{1,17}{2,15}", "-----", "--------------", "------------" );
   
   // Convert byte array elements to unsigned int values.
   BAToUInt32( byteArray, 1 );
   BAToUInt32( byteArray, 0 );
   BAToUInt32( byteArray, 7 );
   BAToUInt32( byteArray, 3 );
   BAToUInt32( byteArray, 10 );
   BAToUInt32( byteArray, 15 );
   BAToUInt32( byteArray, 14 );
}

/*
This example of the BitConverter::ToUInt32( unsigned char[ ], int )
method generates the following output. It converts elements of a
byte array to unsigned int values.

initial byte array
------------------
0F-00-00-00-00-10-00-FF-03-00-00-CA-9A-3B-FF-FF-FF-FF-7F

index   array elements   unsigned int
-----   --------------   ------------
    1      00-00-00-00              0
    0      0F-00-00-00             15
    7      FF-03-00-00           1023
    3      00-00-10-00        1048576
   10      00-CA-9A-3B     1000000000
   15      FF-FF-FF-7F     2147483647
   14      FF-FF-FF-FF     4294967295
*/
//</Snippet2>
