
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   array<Char>^chars;
   array<Byte>^bytes = {99,204,128,234,130,160};
   Decoder^ utf8Decoder = Encoding::UTF8->GetDecoder();
   int charCount = utf8Decoder->GetCharCount( bytes, 0, bytes->Length );
   chars = gcnew array<Char>(charCount);
   int charsDecodedCount = utf8Decoder->GetChars( bytes, 0, bytes->Length, chars, 0 );
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
