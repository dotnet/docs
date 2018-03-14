
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   array<Char>^chars;
   array<Byte>^bytes = {99,43,65,119,67,103,111,65,45};
   Decoder^ utf7Decoder = Encoding::UTF7->GetDecoder();
   int charCount = utf7Decoder->GetCharCount( bytes, 0, bytes->Length );
   chars = gcnew array<Char>(charCount);
   int charsDecodedCount = utf7Decoder->GetChars( bytes, 0, bytes->Length, chars, 0 );
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
