//<snippet1>
// This example demonstrates the EncoderReplacementFallback class.

using System;
using System.Text;

class Sample 
{
    public static void Main() 
    {

// Create an encoding, which is equivalent to calling the 
// ASCIIEncoding class constructor. 
// The EncoderReplacementFallback parameter specifies that the
// string, "(unknown)", replace characters that cannot be encoded. 
// A decoder replacement fallback is also specified, but in this 
// code example the decoding operation cannot fail.  

    Encoding ae = Encoding.GetEncoding(
                  "us-ascii",
                  new EncoderReplacementFallback("(unknown)"), 
                  new DecoderReplacementFallback("(error)"));

// The input string consists of the Unicode characters LEFT POINTING 
// DOUBLE ANGLE QUOTATION MARK (U+00AB), 'X' (U+0058), and RIGHT POINTING 
// DOUBLE ANGLE QUOTATION MARK (U+00BB). 
// The encoding can only encode characters in the US-ASCII range of U+0000 
// through U+007F. Consequently, the characters bracketing the 'X' character
// are replaced with the fallback replacement string, "(unknown)".

    string inputString = "\u00abX\u00bb";
    string decodedString;
    string twoNewLines = "\n\n";
    byte[] encodedBytes = new byte[ae.GetByteCount(inputString)];
    int numberOfEncodedBytes = 0;
    int ix = 0;

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
    ix = 0;
    foreach (byte b in encodedBytes)
        {
        Console.Write("0x{0:X2} ", (int)b);
        ix++;
        if (0 == ix % 6) Console.WriteLine();
        }
    Console.Write(twoNewLines);

// --------------------------------------------------------------------------
// Decode the encoded bytes, yielding a reconstituted string.

    Console.WriteLine("Decode the encoded bytes...");
    decodedString = ae.GetString(encodedBytes);

// Display the input string and the decoded string for comparison.
    Console.WriteLine("Input string:  \"{0}\"", inputString);
    Console.WriteLine("Decoded string:\"{0}\"", decodedString);
    }
}
/*
This code example produces the following results:

The name of the encoding is "us-ascii".

Input string (3 characters): "«X»"
Input string in hexadecimal: 0xAB 0x58 0xBB

Encode the input string...
Encoded bytes in hexadecimal (19 bytes):

0x28 0x75 0x6E 0x6B 0x6E 0x6F
0x77 0x6E 0x29 0x58 0x28 0x75
0x6E 0x6B 0x6E 0x6F 0x77 0x6E
0x29

Decode the encoded bytes...
Input string:  "«X»"
Decoded string:"(unknown)X(unknown)"

*/
//</snippet1>