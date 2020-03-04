
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   array<Byte>^bytes;
   String^ chars = "Unicode Encoding Example";
   UnicodeEncoding^ Unicode = gcnew UnicodeEncoding;
   int byteCount = Unicode->GetByteCount( chars->ToCharArray(), 8, 8 );
   bytes = gcnew array<Byte>(byteCount);
   int bytesEncodedCount = Unicode->GetBytes( chars, 8, 8, bytes, 0 );
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
