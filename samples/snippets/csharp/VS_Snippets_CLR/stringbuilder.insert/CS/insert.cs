// This example demonstrates StringBuilder.Insert()
//<snippet1>
using System;
using System.Text;

class Sample 
{
//                         index: 012345
    static string initialValue = "--[]--";
    static StringBuilder sb;

    public static void Main() 
    {
    string      xyz       = "xyz";
    char[]      abc       = {'a', 'b', 'c'};
    char        star      = '*';
    Object 	obj       = 0;

    bool        xBool     = true;
    byte        xByte     = 1;
    short       xInt16    = 2;
    int         xInt32    = 3;
    long        xInt64    = 4;
    Decimal     xDecimal  = 5;
    float       xSingle   = 6.6F;
    double      xDouble   = 7.7;

// The following types are not CLS-compliant.
    ushort      xUInt16   = 8;
    uint        xUInt32   = 9;
    ulong       xUInt64   = 10;
    sbyte       xSByte    = -11;
//
    Console.WriteLine("StringBuilder.Insert method");
    sb = new StringBuilder(initialValue);

    sb.Insert(3, xyz, 2);
    Show(1, sb);

    sb.Insert(3, xyz);
    Show(2, sb);

    sb.Insert(3, star);
    Show(3, sb);

    sb.Insert(3, abc);
    Show(4, sb);

    sb.Insert(3, abc, 1, 2);
    Show(5, sb);

    sb.Insert(3, xBool);     // True
    Show(6, sb);

    sb.Insert(3, obj);       // 0
    Show(7, sb);

    sb.Insert(3, xByte);     // 1
    Show(8, sb);

    sb.Insert(3, xInt16);    // 2
    Show(9, sb);

    sb.Insert(3, xInt32);    // 3
    Show(10, sb);

    sb.Insert(3, xInt64);    // 4
    Show(11, sb);

    sb.Insert(3, xDecimal);  // 5
    Show(12, sb);

    sb.Insert(3, xSingle);   // 6.6
    Show(13, sb);

    sb.Insert(3, xDouble);   // 7.7
    Show(14, sb);

// The following Insert methods are not CLS-compliant.
    sb.Insert(3, xUInt16);   // 8
    Show(15, sb);

    sb.Insert(3, xUInt32);   // 9
    Show(16, sb);

    sb.Insert(3, xUInt64);   // 10
    Show(17, sb);

    sb.Insert(3, xSByte);    // -11
    Show(18, sb);
//
    }

    public static void Show(int overloadNumber, StringBuilder sbs)
    {
    Console.WriteLine("{0,2:G} = {1}", overloadNumber, sbs.ToString());
    sb = new StringBuilder(initialValue);
    }
}
/*
This example produces the following results:

StringBuilder.Insert method
 1 = --[xyzxyz]--
 2 = --[xyz]--
 3 = --[*]--
 4 = --[abc]--
 5 = --[bc]--
 6 = --[True]--
 7 = --[0]--
 8 = --[1]--
 9 = --[2]--
10 = --[3]--
11 = --[4]--
12 = --[5]--
13 = --[6.6]--
14 = --[7.7]--
15 = --[8]--
16 = --[9]--
17 = --[10]--
18 = --[-11]--

*/
//</snippet1>