
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   array<Char>^chars;
   array<Byte>^bytes = {85,0,110,0,105,0,99,0,111,0,100,0,101,0};
   UnicodeEncoding^ Unicode = gcnew UnicodeEncoding;
   int charCount = Unicode->GetCharCount( bytes, 2, 8 );
   chars = gcnew array<Char>(charCount);
   int charsDecodedCount = Unicode->GetChars( bytes, 2, 8, chars, 0 );
   Console::WriteLine( "{0} characters used to decode bytes.", charsDecodedCount );
   Console::Write( "Decoded chars: " );
   IEnumerator^ myEnum = chars->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Char c = safe_cast<Char>(myEnum->Current);
      Console::Write( "[{0}]", c.ToString() );
   }

   Console::WriteLine();
}

// </Snippet1>
