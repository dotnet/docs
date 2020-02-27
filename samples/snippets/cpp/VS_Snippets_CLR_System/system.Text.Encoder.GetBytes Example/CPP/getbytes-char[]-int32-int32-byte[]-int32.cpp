
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   array<Byte>^bytes;
   
   // Unicode characters.
   
   // Pi
   // Sigma
   array<Char>^chars = {L'\u03a0',L'\u03a3',L'\u03a6',L'\u03a9'};
   Encoder^ uniEncoder = Encoding::Unicode->GetEncoder();
   int byteCount = uniEncoder->GetByteCount( chars, 0, chars->Length, true );
   bytes = gcnew array<Byte>(byteCount);
   int bytesEncodedCount = uniEncoder->GetBytes( chars, 0, chars->Length, bytes, 0, true );
   Console::WriteLine( "{0} bytes used to encode characters.", bytesEncodedCount );
   Console::Write( "Encoded bytes: " );
   IEnumerator^ myEnum = bytes->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Byte b = safe_cast<Byte>(myEnum->Current);
      Console::Write( "[{0}]", b );
   }

   Console::WriteLine();
}

/* This code example produces the following output.

8 bytes used to encode characters.
Encoded bytes: [160][3][163][3][166][3][169][3]

*/

// </Snippet1>
