// Byte.Equals.cpp : main project file.

// <Snippet1>
using namespace System;

void main()
{
    Byte   byteVal1 = 0x7f;
    Byte   byteVal2 = 127;
    Object^ objectVal3 = byteVal2;

    Console::WriteLine("byteVal1 = {0}, byteVal2 = {1}, objectVal3 = {2}\n",
                       byteVal1, byteVal2, objectVal3);
    Console::WriteLine("byteVal1 equals byteVal2?: {0}", byteVal1.Equals(byteVal2));
    Console::WriteLine("byteVal1 equals objectVal3?: {0}", byteVal1.Equals(objectVal3));
}
/*
This example displays the following output:
      byteVal1 = 127, byteVal2 = 127, objectVal3 = 127

      byteVal1 equals byteVal2?: True
      byteVal1 equals objectVal3?: True
*/
// </Snippet1>
