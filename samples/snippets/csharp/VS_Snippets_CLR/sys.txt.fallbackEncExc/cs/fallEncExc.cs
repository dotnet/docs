//<snippet1>
// This example demonstrates the EncoderExceptionFallback class.

using System;
using System.Text;

class Sample 
{
    public static void Main() 
    {

// Create an encoding, which is equivalent to calling the 
// ASCIIEncoding class constructor. 
// The EncoderExceptionFallback parameter causes an exception to
// be thrown when a character cannot be encoded. 
// A decoder exception fallback is also specified, but it is not 
// used because this example terminates during the encoding operation.  

    Encoding ae = Encoding.GetEncoding(
                  "us-ascii",
                  new EncoderExceptionFallback(), 
                  new DecoderExceptionFallback());

// The input string consists of the Unicode characters LEFT POINTING 
// DOUBLE ANGLE QUOTATION MARK (U+00AB), 'X' (U+0058), and RIGHT POINTING 
// DOUBLE ANGLE QUOTATION MARK (U+00BB). 
// The encoding can only encode characters in the US-ASCII range of U+0000 
// through U+007F. Consequently, the characters bracketing the 'X' character
// cause an exception.
    string inputString = "\u00abX\u00bb";

    string twoNewLines = "\n\n";
    byte[] encodedBytes = new byte[ae.GetMaxByteCount(inputString.Length)];
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
    foreach (char c in inputString.ToCharArray()) {
        Console.Write("0x{0:X2} ", (int)c);}
    Console.Write(twoNewLines);

// --------------------------------------------------------------------------
// Attempt to encode the input string. However, an exception is thrown before
// the input string can be encoded.

    Console.WriteLine("Encode the input string...");

// The code example terminates during the call to the GetBytes() method.
    try {
        numberOfEncodedBytes = ae.GetBytes(inputString, 0, inputString.Length, 
                                           encodedBytes, 0);
        }
    catch (EncoderFallbackException e)
        {
        Console.WriteLine(e);
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

Input string (3 characters): "«X»"
Input string in hexadecimal: 0xAB 0x58 0xBB

Encode the input string...
System.Text.EncoderFallbackException: Unable to translate Unicode character \u00AB at inde
x 0 to specified code page.
   at System.Text.EncoderExceptionFallbackBuffer.Fallback(Char charUnknown, Int32 index)
   at System.Text.EncoderFallbackBuffer.InternalFallback(Char ch, Char*& chars)
   at System.Text.ASCIIEncoding.GetBytes(Char* chars, Int32 charCount, Byte* bytes, Int32
byteCount, EncoderNLS encoder)
   at System.Text.ASCIIEncoding.GetBytes(String chars, Int32 charIndex, Int32 charCount, B
yte[] bytes, Int32 byteIndex)
   at Sample.Main()

*** THE CODE EXAMPLE TERMINATES HERE AS INTENDED. ***

*/
//</snippet1>