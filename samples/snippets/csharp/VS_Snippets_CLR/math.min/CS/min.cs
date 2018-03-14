//<snippet1>
// This example demonstrates Math.Min()
using System;

class Sample 
{
    public static void Main() 
    {
    string str = "{0}: The lesser of {1,3} and {2,3} is {3}.";
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

    Console.WriteLine("{0}Display the lesser of two values:{0}", nl);
    Console.WriteLine(str, "Byte   ", xByte1, xByte2, Math.Min(xByte1, xByte2));
    Console.WriteLine(str, "Int16  ", xShort1, xShort2, Math.Min(xShort1, xShort2));
    Console.WriteLine(str, "Int32  ", xInt1, xInt2, Math.Min(xInt1, xInt2));
    Console.WriteLine(str, "Int64  ", xLong1, xLong2, Math.Min(xLong1, xLong2));
    Console.WriteLine(str, "Single ", xSingle1, xSingle2, Math.Min(xSingle1, xSingle2));
    Console.WriteLine(str, "Double ", xDouble1, xDouble2, Math.Min(xDouble1, xDouble2));
    Console.WriteLine(str, "Decimal", xDecimal1, xDecimal2, Math.Min(xDecimal1, xDecimal2));
//
    Console.WriteLine("{0}The following types are not CLS-compliant:{0}", nl);
    Console.WriteLine(str, "SByte  ", xSbyte1, xSbyte2, Math.Min(xSbyte1, xSbyte2));
    Console.WriteLine(str, "UInt16 ", xUshort1, xUshort2, Math.Min(xUshort1, xUshort2));
    Console.WriteLine(str, "UInt32 ", xUint1, xUint2, Math.Min(xUint1, xUint2));
    Console.WriteLine(str, "UInt64 ", xUlong1, xUlong2, Math.Min(xUlong1, xUlong2));
    }
}
/*
This example produces the following results:

Display the lesser of two values:

Byte   : The lesser of   1 and  51 is 1.
Int16  : The lesser of  -2 and  52 is -2.
Int32  : The lesser of  -3 and  53 is -3.
Int64  : The lesser of  -4 and  54 is -4.
Single : The lesser of   5 and  55 is 5.
Double : The lesser of   6 and  56 is 6.
Decimal: The lesser of   7 and  57 is 7.

The following types are not CLS-compliant:

SByte  : The lesser of 101 and 111 is 101.
UInt16 : The lesser of 102 and 112 is 102.
UInt32 : The lesser of 103 and 113 is 103.
UInt64 : The lesser of 104 and 114 is 104.
*/
//</snippet1>