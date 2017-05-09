//Types:System.Globalization.NumberStyles (enum) Vendor: Richter
//<snippet1>
using System;
using System.Text;
using System.Globalization;

public sealed class App 
{
    static void Main() 
    {
        // Parse the string as a hex value and display the value as a decimal.
        String num = "A";
        int val = int.Parse(num, NumberStyles.HexNumber);
        Console.WriteLine("{0} in hex = {1} in decimal.", num, val);

        // Parse the string, allowing a leading sign, and ignoring leading and trailing white spaces.
        num = "    -45   ";
        val = int.Parse(num, NumberStyles.AllowLeadingSign | 
            NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite);
        Console.WriteLine("'{0}' parsed to an int is '{1}'.", num, val);

        // Parse the string, allowing parentheses, and ignoring leading and trailing white spaces.
        num = "    (37)   ";
        val = int.Parse(num, NumberStyles.AllowParentheses | NumberStyles.AllowLeadingSign |                         NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite);
        Console.WriteLine("'{0}' parsed to an int is '{1}'.", num, val);
    }
}

// This code produces the following output.
//
// A in hex = 10 in decimal.
// '    -45   ' parsed to an int is '-45'.
// '    (37)   ' parsed to an int is '-37'.
//</snippet1>