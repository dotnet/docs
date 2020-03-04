
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   array<Byte>^bytes;
   String^ chars = "UTF8 Encoding Example";
   UTF8Encoding^ utf8 = gcnew UTF8Encoding;
   int byteCount = utf8->GetByteCount( chars->ToCharArray(), 0, 13 );
   bytes = gcnew array<Byte>(byteCount);
   int bytesEncodedCount = utf8->GetBytes( chars, 0, 13, bytes, 0 );
   Console::WriteLine( "{0} bytes used to encode string.", bytesEncodedCount );
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
