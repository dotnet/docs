
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   array<Char>^chars;
   array<Byte>^bytes = {85,0,110,0,105,0,99,0,111,0,100,0,101,0};
   Decoder^ uniDecoder = Encoding::Unicode->GetDecoder();
   int charCount = uniDecoder->GetCharCount( bytes, 0, bytes->Length );
   chars = gcnew array<Char>(charCount);
   int charsDecodedCount = uniDecoder->GetChars( bytes, 0, bytes->Length, chars, 0 );
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

/* This code example produces the following output.

7 characters used to decode bytes.
Decoded chars: [U][n][i][c][o][d][e]

*/

// </Snippet1>
