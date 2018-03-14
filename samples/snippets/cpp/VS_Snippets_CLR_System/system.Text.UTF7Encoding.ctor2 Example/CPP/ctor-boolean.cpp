
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
void ShowArray( Array^ theArray )
{
   IEnumerator^ myEnum = theArray->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Object^ o = safe_cast<Object^>(myEnum->Current);
      Console::Write( "[{0}]", o );
   }

   Console::WriteLine();
}

int main()
{
   
   // A few optional characters.
   String^ chars = "!@#$";
   
   // The default Encoding does not allow optional characters.
   // Alternate Byte values are used.
   UTF7Encoding^ utf7 = gcnew UTF7Encoding;
   array<Byte>^bytes1 = utf7->GetBytes( chars );
   Console::WriteLine( "Default UTF7 Encoding:" );
   ShowArray( bytes1 );
   
   // Convert back to characters.
   Console::WriteLine( "Characters:" );
   ShowArray( utf7->GetChars( bytes1 ) );
   
   // Now, allow optional characters.
   // Optional characters are encoded with their normal code points.
   UTF7Encoding^ utf7AllowOptionals = gcnew UTF7Encoding( true );
   array<Byte>^bytes2 = utf7AllowOptionals->GetBytes( chars );
   Console::WriteLine( "UTF7 Encoding with optional characters allowed:" );
   ShowArray( bytes2 );
   
   // Convert back to characters.
   Console::WriteLine( "Characters:" );
   ShowArray( utf7AllowOptionals->GetChars( bytes2 ) );
}

// </Snippet1>
