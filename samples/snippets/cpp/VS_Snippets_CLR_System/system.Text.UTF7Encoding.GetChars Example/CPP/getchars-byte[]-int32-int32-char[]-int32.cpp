
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   array<Char>^chars;
   array<Byte>^bytes = {85,84,70,55,32,69,110,99,111,100,105,110,103,32,69,120,97,109,112,108,101};
   UTF7Encoding^ utf7 = gcnew UTF7Encoding;
   int charCount = utf7->GetCharCount( bytes, 2, 8 );
   chars = gcnew array<Char>(charCount);
   int charsDecodedCount = utf7->GetChars( bytes, 2, 8, chars, 0 );
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
