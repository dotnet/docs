//<snippet1>
// This example demonstrates the Convert.ToBase64CharArray() and
//                               Convert.FromBase64CharArray methods

using System;

class Sample 
{
    public static void Main() 
    {
    byte[] byteArray1 = new byte[256];
    byte[] byteArray2 = new byte[256];
    char[] charArray  = new char[352];
    int charArrayLength;
    string nl = Environment.NewLine;

    string ruler1a = "         1         2         3         4";
    string ruler2a = "1234567890123456789012345678901234567890";
    string ruler3a = "----+----+----+----+----+----+----+----+";
    string ruler1b = "         5         6         7      ";
    string ruler2b = "123456789012345678901234567890123456";
    string ruler3b = "----+----+----+----+----+----+----+-";
    string ruler   = String.Concat(ruler1a, ruler1b, nl, 
                                   ruler2a, ruler2b, nl,
                                   ruler3a, ruler3b);

// 1) Initialize and display a Byte array of arbitrary data.
    Console.WriteLine("1) Input: A Byte array of arbitrary data.{0}", nl);
    for (int x = 0; x < byteArray1.Length; x++)
    {
    byteArray1[x] = (byte)x;
    Console.Write("{0:X2} ", byteArray1[x]);
    if (((x+1)%20) == 0) Console.WriteLine();
    }
    Console.Write("{0}{0}", nl);

// 2) Convert the input Byte array to a Char array, with newlines inserted.
    charArrayLength = 
        Convert.ToBase64CharArray(byteArray1, 0, byteArray1.Length, 
                                   charArray, 0, Base64FormattingOptions.InsertLineBreaks);
    Console.WriteLine("2) Convert the input Byte array to a Char array with newlines.");
    Console.Write("   Output: A Char array (length = {0}). ", charArrayLength);
    Console.WriteLine("The elements of the array are:{0}", nl);
    Console.WriteLine(ruler);
    Console.WriteLine(new String(charArray));
    Console.WriteLine();

// 3) Convert the Char array back to a Byte array.
    Console.WriteLine("3) Convert the Char array to an output Byte array.");
    byteArray2 = Convert.FromBase64CharArray(charArray, 0, charArrayLength);

// 4) Are the input and output Byte arrays equivalent?
    Console.WriteLine("4) The output Byte array is equal to the input Byte array: {0}", 
                      ArraysAreEqual(byteArray1, byteArray2));
    }

    public static bool ArraysAreEqual(byte[] a1, byte[] a2)
    {
    if (a1.Length != a2.Length) return false;
    for (int i = 0; i < a1.Length; i++)
        if (a1[i] != a2[i]) return false;
    return true;
    }
}
/*
This example produces the following results:

1) Input: A Byte array of arbitrary data.

00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 11 12 13
14 15 16 17 18 19 1A 1B 1C 1D 1E 1F 20 21 22 23 24 25 26 27
28 29 2A 2B 2C 2D 2E 2F 30 31 32 33 34 35 36 37 38 39 3A 3B
3C 3D 3E 3F 40 41 42 43 44 45 46 47 48 49 4A 4B 4C 4D 4E 4F
50 51 52 53 54 55 56 57 58 59 5A 5B 5C 5D 5E 5F 60 61 62 63
64 65 66 67 68 69 6A 6B 6C 6D 6E 6F 70 71 72 73 74 75 76 77
78 79 7A 7B 7C 7D 7E 7F 80 81 82 83 84 85 86 87 88 89 8A 8B
8C 8D 8E 8F 90 91 92 93 94 95 96 97 98 99 9A 9B 9C 9D 9E 9F
A0 A1 A2 A3 A4 A5 A6 A7 A8 A9 AA AB AC AD AE AF B0 B1 B2 B3
B4 B5 B6 B7 B8 B9 BA BB BC BD BE BF C0 C1 C2 C3 C4 C5 C6 C7
C8 C9 CA CB CC CD CE CF D0 D1 D2 D3 D4 D5 D6 D7 D8 D9 DA DB
DC DD DE DF E0 E1 E2 E3 E4 E5 E6 E7 E8 E9 EA EB EC ED EE EF
F0 F1 F2 F3 F4 F5 F6 F7 F8 F9 FA FB FC FD FE FF

2) Convert the input Byte array to a Char array with newlines.
   Output: A Char array (length = 352). The elements of the array are:

         1         2         3         4         5         6         7
1234567890123456789012345678901234567890123456789012345678901234567890123456
----+----+----+----+----+----+----+----+----+----+----+----+----+----+----+-
AAECAwQFBgcICQoLDA0ODxAREhMUFRYXGBkaGxwdHh8gISIjJCUmJygpKissLS4vMDEyMzQ1Njc4
OTo7PD0+P0BBQkNERUZHSElKS0xNTk9QUVJTVFVWV1hZWltcXV5fYGFiY2RlZmdoaWprbG1ub3Bx
cnN0dXZ3eHl6e3x9fn+AgYKDhIWGh4iJiouMjY6PkJGSk5SVlpeYmZqbnJ2en6ChoqOkpaanqKmq
q6ytrq+wsbKztLW2t7i5uru8vb6/wMHCw8TFxsfIycrLzM3Oz9DR0tPU1dbX2Nna29zd3t/g4eLj
5OXm5+jp6uvs7e7v8PHy8/T19vf4+fr7/P3+/w==

3) Convert the Char array to an output Byte array.
4) The output Byte array is equal to the input Byte array: True

*/
//</snippet1>
