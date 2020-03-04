
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   array<Byte>^byteOrderMark;
   byteOrderMark = Encoding::Unicode->GetPreamble();
   Console::WriteLine( "Default (little-endian) Unicode Preamble:" );
   IEnumerator^ myEnum = byteOrderMark->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Byte b = safe_cast<Byte>(myEnum->Current);
      Console::Write( "[{0}]", b );
   }

   Console::WriteLine( "\n" );
   UnicodeEncoding^ bigEndianUnicode = gcnew UnicodeEncoding( true,true );
   byteOrderMark = bigEndianUnicode->GetPreamble();
   Console::WriteLine( "Big-endian Unicode Preamble:" );
   myEnum = byteOrderMark->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Byte b = safe_cast<Byte>(myEnum->Current);
      Console::Write( "[{0}]", b );
   }
}

// </Snippet1>
