
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   array<Char>^chars;
   array<Byte>^bytes = {65,83,67,73,73,32,69,110,99,111,100,105,110,103,32,69,120,97,109,112,108,101};
   ASCIIEncoding^ ascii = gcnew ASCIIEncoding;
   int charCount = ascii->GetCharCount( bytes, 6, 8 );
   chars = gcnew array<Char>(charCount);
   int charsDecodedCount = ascii->GetChars( bytes, 6, 8, chars, 0 );
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
