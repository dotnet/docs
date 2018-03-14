//<snippet1>
// This example demonstrates the Char.IsLowSurrogate() method
//                                    IsHighSurrogate() method
//                                    IsSurrogatePair() method
using System;

class Sample 
{
    public static void Main() 
    {
    char cHigh = '\uD800';
    char cLow  = '\uDC00';
    string s1  = new String(new char[] {'a', '\uD800', '\uDC00', 'z'});
    string divider = String.Concat( Environment.NewLine, new String('-', 70), 
                                    Environment.NewLine);

    Console.WriteLine();
    Console.WriteLine("Hexadecimal code point of the character, cHigh: {0:X4}", (int)cHigh);
    Console.WriteLine("Hexadecimal code point of the character, cLow:  {0:X4}", (int)cLow);
    Console.WriteLine();
    Console.WriteLine("Characters in string, s1: 'a', high surrogate, low surrogate, 'z'");
    Console.WriteLine("Hexadecimal code points of the characters in string, s1: ");
    for(int i = 0; i < s1.Length; i++)
        {
        Console.WriteLine("s1[{0}] = {1:X4} ", i, (int)s1[i]);
        }
    Console.WriteLine(divider);

    Console.WriteLine("Is each of the following characters a high surrogate?");
    Console.WriteLine("A1) cLow?  - {0}", Char.IsHighSurrogate(cLow));
    Console.WriteLine("A2) cHigh? - {0}", Char.IsHighSurrogate(cHigh));
    Console.WriteLine("A3) s1[0]? - {0}", Char.IsHighSurrogate(s1, 0));
    Console.WriteLine("A4) s1[1]? - {0}", Char.IsHighSurrogate(s1, 1));
    Console.WriteLine(divider);

    Console.WriteLine("Is each of the following characters a low surrogate?");
    Console.WriteLine("B1) cLow?  - {0}", Char.IsLowSurrogate(cLow));
    Console.WriteLine("B2) cHigh? - {0}", Char.IsLowSurrogate(cHigh));
    Console.WriteLine("B3) s1[0]? - {0}", Char.IsLowSurrogate(s1, 0));
    Console.WriteLine("B4) s1[2]? - {0}", Char.IsLowSurrogate(s1, 2));
    Console.WriteLine(divider);

    Console.WriteLine("Is each of the following pairs of characters a surrogate pair?");
    Console.WriteLine("C1) cHigh and cLow?  - {0}", Char.IsSurrogatePair(cHigh, cLow));
    Console.WriteLine("C2) s1[0] and s1[1]? - {0}", Char.IsSurrogatePair(s1, 0));
    Console.WriteLine("C3) s1[1] and s1[2]? - {0}", Char.IsSurrogatePair(s1, 1));
    Console.WriteLine("C4) s1[2] and s1[3]? - {0}", Char.IsSurrogatePair(s1, 2));
    Console.WriteLine(divider);
    }
}
/*
This example produces the following results:

Hexadecimal code point of the character, cHigh: D800
Hexadecimal code point of the character, cLow:  DC00

Characters in string, s1: 'a', high surrogate, low surrogate, 'z'
Hexadecimal code points of the characters in string, s1:
s1[0] = 0061
s1[1] = D800
s1[2] = DC00
s1[3] = 007A

----------------------------------------------------------------------

Is each of the following characters a high surrogate?
A1) cLow?  - False
A2) cHigh? - True
A3) s1[0]? - False
A4) s1[1]? - True

----------------------------------------------------------------------

Is each of the following characters a low surrogate?
B1) cLow?  - True
B2) cHigh? - False
B3) s1[0]? - False
B4) s1[2]? - True

----------------------------------------------------------------------

Is each of the following pairs of characters a surrogate pair?
C1) cHigh and cLow?  - True
C2) s1[0] and s1[1]? - False
C3) s1[1] and s1[2]? - True
C4) s1[2] and s1[3]? - False

----------------------------------------------------------------------

*/
//</snippet1>