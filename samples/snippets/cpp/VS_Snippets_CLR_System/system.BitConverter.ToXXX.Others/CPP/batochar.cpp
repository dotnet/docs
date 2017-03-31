
//<Snippet2>
// Example of the BitConverter::ToChar method.
using namespace System;

// Convert two byte array elements to a __wchar_t and display it.
void BAToChar( array<unsigned char>^bytes, int index )
{
   __wchar_t value = BitConverter::ToChar( bytes, index );
   Console::WriteLine( "{0,5}{1,17}{2,11}", index, BitConverter::ToString( bytes, index, 2 ), value );
}

int main()
{
   array<unsigned char>^byteArray = {32,0,0,42,0,65,0,125,0,197,0,168,3,41,4,172,32};
   Console::WriteLine( "This example of the BitConverter::ToChar( unsigned "
   "char[ ], int ) \nmethod generates the following output. It "
   "converts elements of a \nbyte array to __wchar_t values.\n" );
   Console::WriteLine( "initial unsigned char array" );
   Console::WriteLine( "---------------------------" );
   Console::WriteLine( BitConverter::ToString( byteArray ) );
   Console::WriteLine();
   Console::WriteLine( "{0,5}{1,17}{2,11}", "index", "array elements", "__wchar_t" );
   Console::WriteLine( "{0,5}{1,17}{2,11}", "-----", "--------------", "---------" );
   
   // Convert byte array elements to __wchar_t values.
   BAToChar( byteArray, 0 );
   BAToChar( byteArray, 1 );
   BAToChar( byteArray, 3 );
   BAToChar( byteArray, 5 );
   BAToChar( byteArray, 7 );
   BAToChar( byteArray, 9 );
   BAToChar( byteArray, 11 );
   BAToChar( byteArray, 13 );
   BAToChar( byteArray, 15 );
}

/*
This example of the BitConverter::ToChar( unsigned char[ ], int )
method generates the following output. It converts elements of a
byte array to __wchar_t values.

initial unsigned char array
---------------------------
20-00-00-2A-00-41-00-7D-00-C5-00-A8-03-29-04-AC-20

index   array elements  __wchar_t
-----   --------------  ---------
    0            20-00
    1            00-00
    3            2A-00          *
    5            41-00          A
    7            7D-00          }
    9            C5-00          Å
   11            A8-03          ?
   13            29-04          ?
   15            AC-20          ?
*/
//</Snippet2>
