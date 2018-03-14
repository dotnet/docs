
// The following code example gets two instances of the same encoding (one by codepage and another by name), and checks their equality.
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   
   // Get a UTF-32 encoding by codepage.
   Encoding^ e1 = Encoding::GetEncoding( 12000 );
   
   // Get a UTF-32 encoding by name.
   Encoding^ e2 = Encoding::GetEncoding( "utf-32" );
   
   // Check their equality.
   Console::WriteLine( "e1 equals e2? {0}", e1->Equals( e2 ) );
}

/* 
This code produces the following output.

e1 equals e2? True

*/
// </Snippet1>
