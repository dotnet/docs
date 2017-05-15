
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   array<Char>^chars = {'a','b','c',L'\u0300',L'\ua0a0'};
   array<Byte>^bytes;
   Encoder^ utf7Encoder = Encoding::UTF7->GetEncoder();
   int byteCount = utf7Encoder->GetByteCount( chars, 2, 3, true );
   bytes = gcnew array<Byte>(byteCount);
   int bytesEncodedCount = utf7Encoder->GetBytes( chars, 2, 3, bytes, 0, true );
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

// </Snippet1>
