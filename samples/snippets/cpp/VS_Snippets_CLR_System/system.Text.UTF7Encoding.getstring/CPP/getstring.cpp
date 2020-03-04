
// The following code example encodes a string into an array of bytes, and then decodes the bytes back into a string.
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   
   // Create an instance of UTF7Encoding.
   UTF7Encoding^ u7 = gcnew UTF7Encoding( true );
   
   // Create byte arrays from the same string containing the following characters:
   //    Latin Small Letter Z (U+007A)
   //    Latin Small Letter A (U+0061)
   //    Combining Breve (U+0306)
   //    Latin Small Letter AE With Acute (U+01FD)
   //    Greek Small Letter Beta (U+03B2)
   String^ myStr = "za\u0306\u01FD\u03B2";
   
   // Encode the string.
   array<Byte>^myBArr = gcnew array<Byte>(u7->GetByteCount( myStr ));
   u7->GetBytes( myStr, 0, myStr->Length, myBArr, 0 );
   
   // Decode the byte array.
   Console::WriteLine( "The new string is: {0}", u7->GetString( myBArr, 0, myBArr->Length ) );
}

/*
This code produces the following output.  The question marks take the place of characters that cannot be displayed at the console.

The new string is: za??

*/
// </Snippet1>
