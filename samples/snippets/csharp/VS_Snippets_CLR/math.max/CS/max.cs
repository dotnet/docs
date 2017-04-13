//<snippet1>
// This example demonstrates Math.Max()
using System;

class Sample 
{
    public static void Main() 
    {
    string str = "{0}: The greater of {1,3} and {2,3} is {3}.";
    string nl = Environment.NewLine;

    byte     xByte1    = 1,    xByte2    = 51;	
    short    xShort1   = -2,   xShort2   = 52;
    int      xInt1     = -3,   xInt2     = 53;
    long     xLong1    = -4,   xLong2    = 54;
    float    xSingle1  = 5.0f, xSingle2  = 55.0f;
    double   xDouble1  = 6.0,  xDouble2  = 56.0;
    Decimal  xDecimal1 = 7m,   xDecimal2 = 57m;

// The following types are not CLS-compliant.
    sbyte    xSbyte1   = 101, xSbyte2  = 111;
    ushort   xUshort1  = 102, xUshort2 = 112;
    uint     xUint1    = 103, xUint2   = 113;
    ulong    xUlong1   = 104, xUlong2  = 114;

    Console.WriteLine("{0}Display the greater of two values:{0}", nl);
    Console.WriteLine(str, "Byte   ", xByte1, xByte2, Math.Max(xByte1, xByte2));
    Console.WriteLine(str, "Int16  ", xShort1, xShort2, Math.Max(xShort1, xShort2));
    Console.WriteLine(str, "Int32  ", xInt1, xInt2, Math.Max(xInt1, xInt2));
    Console.WriteLine(str, "Int64  ", xLong1, xLong2, Math.Max(xLong1, xLong2));
    Console.WriteLine(str, "Single ", xSingle1, xSingle2, Math.Max(xSingle1, xSingle2));
    Console.WriteLine(str, "Double ", xDouble1, xDouble2, Math.Max(xDouble1, xDouble2));
    Console.WriteLine(str, "Decimal", xDecimal1, xDecimal2, Math.Max(xDecimal1, xDecimal2));
//
    Console.WriteLine("{0}The following types are not CLS-compliant.{0}", nl);
    Console.WriteLine(str, "SByte  ", xSbyte1, xSbyte2, Math.Max(xSbyte1, xSbyte2));
    Console.WriteLine(str, "UInt16 ", xUshort1, xUshort2, Math.Max(xUshort1, xUshort2));
    Console.WriteLine(str, "UInt32 ", xUint1, xUint2, Math.Max(xUint1, xUint2));
    Console.WriteLine(str, "UInt64 ", xUlong1, xUlong2, Math.Max(xUlong1, xUlong2));
    }
}
/*
This example produces the following results:

Display the greater of two values:

Byte   : The greater of   1 and  51 is 51.
Int16  : The greater of  -2 and  52 is 52.
Int32  : The greater of  -3 and  53 is 53.
Int64  : The greater of  -4 and  54 is 54.
Single : The greater of   5 and  55 is 55.
Double : The greater of   6 and  56 is 56.
Decimal: The greater of   7 and  57 is 57.

(The following types are not CLS-compliant.)

SByte  : The greater of 101 and 111 is 111.
UInt16 : The greater of 102 and 112 is 112.
UInt32 : The greater of 103 and 113 is 113.
UInt64 : The greater of 104 and 114 is 114.
*/
//</snippet1>