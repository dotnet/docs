//Types:System.Globalization.NumberStyles (enum) Vendor: Richter
//<snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Globalization;


int main()
{
    // Parse the string as a hex value and display the
    // value as a decimal.
    String^ numberString = "A";
    int stringValue = Int32::Parse(numberString, NumberStyles::HexNumber);
    Console::WriteLine("{0} in hex = {1} in decimal.",
        numberString, stringValue);

    // Parse the string, allowing a leading sign, and ignoring
    // leading and trailing white spaces.
    numberString = "    -45   ";
    stringValue =Int32::Parse(numberString, NumberStyles::AllowLeadingSign |
        NumberStyles::AllowLeadingWhite | NumberStyles::AllowTrailingWhite);
    Console::WriteLine("'{0}' parsed to an int is '{1}'.",
        numberString, stringValue);

    // Parse the string, allowing parentheses, and ignoring
    // leading and trailing white spaces.
    numberString = "    (37)   ";
    stringValue = Int32::Parse(numberString, NumberStyles::AllowParentheses |
        NumberStyles::AllowLeadingSign | NumberStyles::AllowLeadingWhite |
        NumberStyles::AllowTrailingWhite);

    Console::WriteLine("'{0}' parsed to an int is '{1}'.",
        numberString, stringValue);
}

// This code produces the following output.
//
// A in hex = 10 in decimal.
// '    -45   ' parsed to an int is '-45'.
// '    (37)   ' parsed to an int is '-37'.
//</snippet1>
