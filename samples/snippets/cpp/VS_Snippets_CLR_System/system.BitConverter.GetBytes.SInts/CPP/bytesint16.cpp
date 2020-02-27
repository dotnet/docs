//<Snippet3>
using namespace System;

void main()
{
    // Define an array of integers.
    array<Int16>^ values = { 0, 15, -15, 10000,  -10000, 
                             Int16::MinValue, Int16::MaxValue};
       
    // Convert each integer to a byte array.
    Console::WriteLine("{0,16}{1,10}{2,17}", "Integer", 
                       "Endian", "Byte Array");
    Console::WriteLine("{0,16}{1,10}{2,17}", "---", "------", 
                       "----------");
    for each (int value in values) {
      array<Byte>^ byteArray = BitConverter::GetBytes(value);
      Console::WriteLine("{0,16}{1,10}{2,17}", value, 
                        BitConverter::IsLittleEndian ? "Little" : " Big", 
                        BitConverter::ToString(byteArray));
    }
}
// This example displays output like the following:
//              Integer    Endian       Byte Array
//                  ---    ------       ----------
//                    0    Little            00-00
//                   15    Little            0F-00
//                  -15    Little            F1-FF
//                10000    Little            10-27
//               -10000    Little            F0-D8
//               -32768    Little            00-80
//                32767    Little            FF-7F
//</Snippet3>
