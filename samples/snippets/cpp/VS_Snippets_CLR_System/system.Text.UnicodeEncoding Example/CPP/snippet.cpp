
// <Snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Collections;
int main()
{
   
   // The encoding.
   UnicodeEncoding^ unicode = gcnew UnicodeEncoding;
   
   // Create a String* that contains Unicode characters.
   String^ unicodeString = L"This Unicode string contains two characters with codes outside the traditional ASCII code range, Pi (\u03a0) and Sigma (\u03a3).";
   Console::WriteLine( "Original string:" );
   Console::WriteLine( unicodeString );
   
   // Encode the String*.
   array<Byte>^encodedBytes = unicode->GetBytes( unicodeString );
   Console::WriteLine();
   Console::WriteLine( "Encoded bytes:" );
   IEnumerator^ myEnum = encodedBytes->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Byte b = safe_cast<Byte>(myEnum->Current);
      Console::Write( "[{0}]", b );
   }

   Console::WriteLine();
   
   // Decode bytes back to String*.
   // Notice Pi and Sigma characters are still present.
   String^ decodedString = unicode->GetString( encodedBytes );
   Console::WriteLine();
   Console::WriteLine( "Decoded bytes:" );
   Console::WriteLine( decodedString );
}

// </Snippet1>
