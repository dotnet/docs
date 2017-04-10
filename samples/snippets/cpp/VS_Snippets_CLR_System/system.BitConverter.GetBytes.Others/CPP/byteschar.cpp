
//<Snippet2>
// Example of the BitConverter::GetBytes( __wchar_t ) method.
using namespace System;

// Convert a __wchar_t argument to a byte array and display it.
void GetBytesChar( __wchar_t argument )
{
   array<Byte>^byteArray = BitConverter::GetBytes( argument );
   Console::WriteLine( "{0,10}{1,16}", argument, BitConverter::ToString( byteArray ) );
}

int main()
{
   Console::WriteLine( "This example of the BitConverter::GetBytes( __wchar_t ) "
   "\nmethod generates the following output.\n" );
   Console::WriteLine( "{0,10}{1,16}", "__wchar_t", "byte array" );
   Console::WriteLine( "{0,10}{1,16}", "---------", "----------" );
   
   // Convert __wchar_t values and display the results.
   GetBytesChar( L'\0' );
   GetBytesChar( L' ' );
   GetBytesChar( L'*' );
   GetBytesChar( L'3' );
   GetBytesChar( L'A' );
   GetBytesChar( L'[' );
   GetBytesChar( L'a' );
   GetBytesChar( L'{' );
}

/*
This example of the BitConverter::GetBytes( __wchar_t )
method generates the following output.

 __wchar_t      byte array
 ---------      ----------
                     00-00
                     20-00
         *           2A-00
         3           33-00
         A           41-00
         [           5B-00
         a           61-00
         {           7B-00
*/
//</Snippet2>
