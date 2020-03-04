
// <Snippet1>
using namespace System;
using namespace System::Text;

int main()
{
   String^ unicodeString = "This string contains the unicode character Pi (\u03a0)";
   
   // Create two different encodings.
   Encoding^ ascii = Encoding::ASCII;
   Encoding^ unicode = Encoding::Unicode;
   
   // Convert the string into a byte array.
   array<Byte>^unicodeBytes = unicode->GetBytes( unicodeString );
   
   // Perform the conversion from one encoding to the other.
   array<Byte>^asciiBytes = Encoding::Convert( unicode, ascii, unicodeBytes );
   
   // Convert the new Byte into[] a char and[] then into a string.
   array<Char>^asciiChars = gcnew array<Char>(ascii->GetCharCount( asciiBytes, 0, asciiBytes->Length ));
   ascii->GetChars( asciiBytes, 0, asciiBytes->Length, asciiChars, 0 );
   String^ asciiString = gcnew String( asciiChars );
   
   // Display the strings created before and after the conversion.
   Console::WriteLine( "Original String*: {0}", unicodeString );
   Console::WriteLine( "Ascii converted String*: {0}", asciiString );
}
// The example displays the following output:
//    Original string: This string contains the unicode character Pi (Π)
//    Ascii converted string: This string contains the unicode character Pi (?)
// </Snippet1>
