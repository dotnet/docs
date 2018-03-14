
// The following code example demonstrates the behavior of UTF32Encoding with error detection enabled and without.
// <Snippet1>
using namespace System;
using namespace System::Text;
void PrintDecodedString( array<Byte>^bytes, Encoding^ enc );
int main()
{
   
   // Create an instance of UTF32Encoding using little-endian byte order.
   // This will be used for encoding.
   UTF32Encoding^ u32LE = gcnew UTF32Encoding( false,true );
   
   // Create two instances of UTF32Encoding using big-endian byte order: one with error detection and one without.
   // These will be used for decoding.
   UTF32Encoding^ u32withED = gcnew UTF32Encoding( true,true,true );
   UTF32Encoding^ u32noED = gcnew UTF32Encoding( true,true,false );
   
   // Create byte arrays from the same string containing the following characters:
   //    Latin Small Letter Z (U+007A)
   //    Latin Small Letter A (U+0061)
   //    Combining Breve (U+0306)
   //    Latin Small Letter AE With Acute (U+01FD)
   //    Greek Small Letter Beta (U+03B2)
   String^ myStr = L"za\u0306\u01FD\u03B2\xD8FF\xDCFF";
   
   // Encode the string using little-endian byte order.
   array<Byte>^myBytes = gcnew array<Byte>(u32LE->GetByteCount( myStr ));
   u32LE->GetBytes( myStr, 0, myStr->Length, myBytes, 0 );
   
   // Decode the byte array with error detection.
   Console::WriteLine( "Decoding with error detection:" );
   PrintDecodedString( myBytes, u32withED );
   
   // Decode the byte array without error detection.
   Console::WriteLine( "Decoding without error detection:" );
   PrintDecodedString( myBytes, u32noED );
}


// Decode the bytes and display the string.
void PrintDecodedString( array<Byte>^bytes, Encoding^ enc )
{
   try
   {
      Console::WriteLine( "   Decoded string: {0}", enc->GetString( bytes, 0, bytes->Length ) );
   }
   catch ( System::ArgumentException^ e ) 
   {
      Console::WriteLine( e );
   }

   Console::WriteLine();
}

// </Snippet1>
/* 
This code produces the following output.

Decoding with error detection:
System.ArgumentException: Invalid byte was found at byte index 3.
   at System.Text.UTF32Encoding.GetCharCount(Byte* bytes, Int32 count, DecoderNLS baseDecoder)
   at System.String.CreateStringFromEncoding(Byte* bytes, Int32 byteLength, Encoding encoding)
   at System.Text.UTF32Encoding.GetString(Byte[] bytes, Int32 index, Int32 count)
   at SamplesUTF32Encoding.PrintDecodedString(Byte[] bytes, Encoding enc)

Decoding without error detection:
   Decoded string:

*/
