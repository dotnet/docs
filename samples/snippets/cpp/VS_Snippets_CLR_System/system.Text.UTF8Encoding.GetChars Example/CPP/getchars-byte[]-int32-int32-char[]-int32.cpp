
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   array<Char>^chars;
   array<Byte>^bytes = {85,84,70,56,32,69,110,99,111,100,105,110,103,32,69,120,97,109,112,108,101};
   UTF8Encoding^ utf8 = gcnew UTF8Encoding;
   int charCount = utf8->GetCharCount( bytes, 2, 13 );
   chars = gcnew array<Char>(charCount);
   int charsDecodedCount = utf8->GetChars( bytes, 2, 13, chars, 0 );
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
