//<snippet1>
// This example demonstrates the EncoderReplacementFallback class.

using namespace System;
using namespace System::Text;

int main()
{
    // Create an encoding, which is equivalent to calling the
    // ASCIIEncoding class constructor.
    // The EncoderReplacementFallback parameter specifies that the
    // string, "(unknown)", replace characters that cannot be encoded.
    // A decoder replacement fallback is also specified, but in this
    // code example the decoding operation cannot fail.

    Encoding^ ascii = Encoding::GetEncoding("us-ascii",
        gcnew EncoderReplacementFallback("(unknown)"),
        gcnew DecoderReplacementFallback("(error)"));

    // The input string consists of the Unicode characters LEFT POINTING
    // DOUBLE ANGLE QUOTATION MARK (U+00AB), 'X' (U+0058), and RIGHT
    // POINTING DOUBLE ANGLE QUOTATION MARK (U+00BB).
    // The encoding can only encode characters in the US-ASCII range of
    // U+0000 through U+007F. Consequently, the characters bracketing the
    // 'X' character are replaced with the fallback replacement string,
    // "(unknown)".

    String^ inputString = "\u00abX\u00bb";
    String^ decodedString;
    String^ twoNewLines = Environment::NewLine + Environment::NewLine;
    array <Byte>^ encodedBytes = 
        gcnew array<Byte>(ascii->GetByteCount(inputString));
    int numberOfEncodedBytes = 0;

    // ---------------------------------------------------------------------
    Console::Clear();

    // Display the name of the encoding.
    Console::WriteLine("The name of the encoding is \"{0}\".{1}", 
        ascii->WebName, Environment::NewLine);

    // Display the input string in text.
    Console::WriteLine("Input string ({0} characters): \"{1}\"",
        inputString->Length, inputString);

    // Display the input string in hexadecimal.
    Console::Write("Input string in hexadecimal: ");
    for each (char c in inputString)
    {
        Console::Write("0x{0:X2} ", c);
    }
    Console::Write(twoNewLines);

    // ---------------------------------------------------------------------
    // Encode the input string.

    Console::WriteLine("Encode the input string...");
    numberOfEncodedBytes = ascii->GetBytes(inputString, 0, inputString->Length,
        encodedBytes, 0);

    // Display the encoded bytes.
    Console::WriteLine("Encoded bytes in hexadecimal ({0} bytes):{1}",
        numberOfEncodedBytes, Environment::NewLine);
    for(int i = 0; i < encodedBytes->Length; i++)
    {
        Console::Write("0x{0:X2} ", encodedBytes[i]);
        if(((i + 1) % 6) == 0)
        {
            Console::WriteLine();
        }
    }
    Console::Write(twoNewLines);

    // ---------------------------------------------------------------------
    // Decode the encoded bytes, yielding a reconstituted string.

    Console::WriteLine("Decode the encoded bytes...");
    decodedString = ascii->GetString(encodedBytes);

    // Display the input string and the decoded string for comparison.
    Console::WriteLine("Input string:  \"{0}\"", inputString);
    Console::WriteLine("Decoded string:\"{0}\"", decodedString);
}



/*
This code example produces the following results:

The name of the encoding is "us-ascii".

Input string (3 characters): "X"
Input string in hexadecimal: 0xAB 0x58 0xBB

Encode the input string...
Encoded bytes in hexadecimal (19 bytes):

0x28 0x75 0x6E 0x6B 0x6E 0x6F
0x77 0x6E 0x29 0x58 0x28 0x75
0x6E 0x6B 0x6E 0x6F 0x77 0x6E
0x29

Decode the encoded bytes...
Input string:  "X"
Decoded string:"(unknown)X(unknown)"

*/
//</snippet1>
