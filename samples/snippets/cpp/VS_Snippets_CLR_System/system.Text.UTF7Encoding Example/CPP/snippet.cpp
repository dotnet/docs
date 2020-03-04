
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   
   // Create a UTF-7 encoding.
   UTF7Encoding^ utf7 = gcnew UTF7Encoding;
   
   // A Unicode string with two characters outside a 7-bit code range.
   String^ unicodeString = L"This Unicode string contains two characters with codes outside a 7-bit code range, Pi (\u03a0) and Sigma (\u03a3).";
   Console::WriteLine( "Original string:" );
   Console::WriteLine( unicodeString );
   
   // Encode the string.
   array<Byte>^encodedBytes = utf7->GetBytes( unicodeString );
   Console::WriteLine();
   Console::WriteLine( "Encoded bytes:" );
   IEnumerator^ myEnum = encodedBytes->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Byte b = safe_cast<Byte>(myEnum->Current);
      Console::Write( "[{0}]", b );
   }

   Console::WriteLine();
   
   // Decode bytes back to string.
   // Notice Pi and Sigma characters are still present.
   String^ decodedString = utf7->GetString( encodedBytes );
   Console::WriteLine();
   Console::WriteLine( "Decoded bytes:" );
   Console::WriteLine( decodedString );
}

// </Snippet1>
