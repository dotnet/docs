//<snippet1>
// This code example demonstrates the System.Byte.Equals(Object) and
// System.Byte.Equals(Byte) methods.

using System;

class Sample 
{
    public static void Main() 
    {
    byte   byteVal1 = 0x7f;
    byte   byteVal2 = 127;
    object objectVal3 = byteVal2;
//
    Console.WriteLine("byteVal1 = {0}, byteVal2 = {1}, objectVal3 = {2}\n",
                       byteVal1, byteVal2, objectVal3);
    Console.WriteLine("byteVal1 equals byteVal2?: {0}", byteVal1.Equals(byteVal2));
    Console.WriteLine("byteVal1 equals objectVal3?: {0}", byteVal1.Equals(objectVal3));
    }
}

/*
This code example produces the following results:

byteVal1 = 127, byteVal2 = 127, objectVal3 = 127

byteVal1 equals byteVal2?: True
byteVal1 equals objectVal3?: True

*/
//</snippet1>