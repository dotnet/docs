//<snippet1>
// This example demonstrates the DecoderReplacementFallback class.

using System;
using System.Text;

class Sample 
{
    public static void Main() 
    {

// Create an encoding, which is equivalent to calling the 
// ASCIIEncoding class constructor. 
// The DecoderReplacementFallback parameter specifies that the 
// string "(error)" is to replace characters that cannot be decoded. 
// An encoder replacement fallback is also specified, but in this code
// example the encoding operation cannot fail.  

    Encoding ae = Encoding.GetEncoding(
                  "us-ascii",
                  new EncoderReplacementFallback("(unknown)"), 
                  new DecoderReplacementFallback("(error)"));
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
// Decode the encoded bytes.

    Console.WriteLine("Compare the decoded bytes to the input string...");
    decodedString = ae.GetString(encodedBytes);

// Display the input string and the decoded string for comparison.
    Console.WriteLine("Input string:  \"{0}\"", inputString);
    Console.WriteLine("Decoded string:\"{0}\"", decodedString);
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
Input string:  "XYZ"
Decoded string:"(error)Y(error)"

*/
//</snippet1>