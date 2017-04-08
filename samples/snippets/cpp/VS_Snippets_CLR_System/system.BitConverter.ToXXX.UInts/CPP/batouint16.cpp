
//<Snippet1>
// Example of the BitConverter::ToUInt16 method.
using namespace System;

// Convert two byte array elements to an unsigned short and display it.
void BAToUInt16( array<unsigned char>^bytes, int index )
{
   unsigned short value = BitConverter::ToUInt16( bytes, index );
   Console::WriteLine( "{0,5}{1,17}{2,16}", index, BitConverter::ToString( bytes, index, 2 ), value );
}

int main()
{
   array<unsigned char>^byteArray = {15,0,0,255,3,16,39,255,255,127};
   Console::WriteLine( "This example of the BitConverter::ToUInt16( unsigned "
   "char[ ], int ) \nmethod generates the following output. It "
   "converts elements of a \nbyte array to unsigned short "
   "values.\n" );
   Console::WriteLine( "initial byte array" );
   Console::WriteLine( "------------------" );
   Console::WriteLine( BitConverter::ToString( byteArray ) );
   Console::WriteLine();
   Console::WriteLine( "{0,5}{1,17}{2,16}", "index", "array elements", "unsigned short" );
   Console::WriteLine( "{0,5}{1,17}{2,16}", "-----", "--------------", "--------------" );
   
   // Convert byte array elements to unsigned short values.
   BAToUInt16( byteArray, 1 );
   BAToUInt16( byteArray, 0 );
   BAToUInt16( byteArray, 3 );
   BAToUInt16( byteArray, 5 );
   BAToUInt16( byteArray, 8 );
   BAToUInt16( byteArray, 7 );
}

/*
This example of the BitConverter::ToUInt16( unsigned char[ ], int )
method generates the following output. It converts elements of a
byte array to unsigned short values.

initial byte array
------------------
0F-00-00-FF-03-10-27-FF-FF-7F

index   array elements  unsigned short
-----   --------------  --------------
    1            00-00               0
    0            0F-00              15
    3            FF-03            1023
    5            10-27           10000
    8            FF-7F           32767
    7            FF-FF           65535
*/
//</Snippet1>
