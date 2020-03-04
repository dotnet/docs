//<Snippet2>
using namespace System;

void main()
{
    // Define an array of integers.
    array<int>^ values = { 0, 15, -15, 0x100000,  -0x100000, 1000000000,
                          -1000000000, Int32::MinValue, Int32::MaxValue };
       
    // Convert each integer to a byte array.
    Console::WriteLine("{0,16}{1,10}{2,17}", "Integer", 
                       "Endian", "Byte Array");
    Console::WriteLine("{0,16}{1,10}{2,17}", "---", "------", 
                       "----------" );
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
//                    0    Little      00-00-00-00
//                   15    Little      0F-00-00-00
//                  -15    Little      F1-FF-FF-FF
//              1048576    Little      00-00-10-00
//             -1048576    Little      00-00-F0-FF
//           1000000000    Little      00-CA-9A-3B
//          -1000000000    Little      00-36-65-C4
//          -2147483648    Little      00-00-00-80
//           2147483647    Little      FF-FF-FF-7F
//</Snippet2>
