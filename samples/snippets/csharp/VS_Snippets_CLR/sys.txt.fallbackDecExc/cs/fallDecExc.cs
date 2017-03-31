//<snippet1>
// This example demonstrates the DecoderExceptionFallback class.

using System;
using System.Text;

class Sample 
{
    public static void Main() 
    {

// Create an encoding, which is equivalent to calling the 
// ASCIIEncoding class constructor. 
// The DecoderExceptionFallback parameter specifies that an exception
// is thrown if a character cannot be encoded. 
// An encoder exception fallback is also specified, but in this code
// example the encoding operation cannot fail.  

    Encoding ae = Encoding.GetEncoding(
                  "us-ascii",
                  new EncoderExceptionFallback(), 
                  new DecoderExceptionFallback());
    string inputString = "XYZ";
    string decodedString;
    string twoNewLines = "\n\n";
    byte[] encodedBytes = new byte[ae.GetByteCount(inputString)];
    int numberOfEncodedBytes = 0;

// --------------------------------------------------------------------------
    Console.Clear();

// Display the name of the encoding.
    Console.WriteLine("The name of the encoding is \"{0}\".\n", ae.WebName);

// Display the input string in text.
    Console.WriteLine("Input string ({0} characters): \"{1}\"", 
                       inputString.Length, inputString);

// Display the input string in hexadecimal.
    Console.Write("Input string in hexadecimal: ");
    foreach (char c in inputString.ToCharArray()) 
        {
        Console.Write("0x{0:X2} ", (int)c);
        }
    Console.Write(twoNewLines);

// --------------------------------------------------------------------------
// Encode the input string. 

    Console.WriteLine("Encode the input string...");
    numberOfEncodedBytes = ae.GetBytes(inputString, 0, inputString.Length, 
                                       encodedBytes, 0);
// Display the encoded bytes.
    Console.WriteLine("Encoded bytes in hexadecimal ({0} bytes):\n", 
                       numberOfEncodedBytes);
    foreach (byte b in encodedBytes)
        {
        Console.Write("0x{0:X2} ", (int)b);
        }
    Console.Write(twoNewLines);

// --------------------------------------------------------------------------

// Replace the encoded byte sequences for the characters 'X' and 'Z' with the 
// value 0xFF, which is outside the valid range of 0x00 to 0x7F for 
// ASCIIEncoding. The resulting byte sequence is actually the beginning of 
// this code example because it is the input to the decoder operation, and 
// is equivalent to a corrupted or improperly encoded byte sequence. 

    encodedBytes[0] = 0xFF;
    encodedBytes[2] = 0xFF;

    Console.WriteLine("Display the corrupted byte sequence...");
    Console.WriteLine("Encoded bytes in hexadecimal ({0} bytes):\n", 
                       numberOfEncodedBytes);
    foreach (byte b in encodedBytes)
        {
        Console.Write("0x{0:X2} ", (int)b);
        }
    Console.Write(twoNewLines);

// --------------------------------------------------------------------------
// Attempt to decode the encoded bytes. However, an exception is thrown 
// before the byte sequence can be decoded.

    Console.WriteLine("Compare the decoded bytes to the input string...");

    try {
        decodedString = ae.GetString(encodedBytes);
        }
    catch (DecoderFallbackException dfe)
        {
        Console.WriteLine(dfe);
        Console.WriteLine("\n*** THE CODE EXAMPLE TERMINATES HERE AS INTENDED. ***");
        return;
        }

// This statement is never executed.
    Console.WriteLine("This statement is never executed.");
    }
}
/*
This code example produces the following results:

The name of the encoding is "us-ascii".

Input string (3 characters): "XYZ"
Input string in hexadecimal: 0x58 0x59 0x5A

Encode the input string...
Encoded bytes in hexadecimal (3 bytes):

0x58 0x59 0x5A

Display the corrupted byte sequence...
Encoded bytes in hexadecimal (3 bytes):

0xFF 0x59 0xFF

Compare the decoded bytes to the input string...
System.Text.DecoderFallbackException: Unable to translate bytes [FF] at index 0 from speci
fied code page to Unicode.
   at System.Text.DecoderExceptionFallbackBuffer.Throw(Byte[] bytesUnknown, Int32 index)
   at System.Text.DecoderExceptionFallbackBuffer.Fallback(Byte[] bytesUnknown, Int32 index
)
   at System.Text.DecoderFallbackBuffer.InternalFallback(Byte[] bytes, Byte* pBytes)
   at System.Text.ASCIIEncoding.GetCharCount(Byte* bytes, Int32 count, DecoderNLS decoder)

   at System.String.CreateStringFromEncoding(Byte* bytes, Int32 byteLength, Encoding encod
ing)
   at System.Text.ASCIIEncoding.GetString(Byte[] bytes, Int32 byteIndex, Int32 byteCount)
   at System.Text.Encoding.GetString(Byte[] bytes)
   at Sample.Main()

*** THE CODE EXAMPLE TERMINATES HERE AS INTENDED. ***

*/
//</snippet1>