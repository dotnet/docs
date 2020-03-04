//<Snippet3>
using namespace System;

void main()
{
     // Define an array of 16-bit integer values.
     array<Int16>^ values = { Int16::MinValue, Int16::MaxValue, 
                              0xFFF, 12345, -10000 };   
     // Convert each value to a Decimal.
     for each (Int16 value in values) {
        Decimal decValue = value;
        Console::WriteLine("{0} ({1}) --> {2} ({3})", value,
                          value.GetType()->Name, decValue,
                          decValue.GetType()->Name);         
     }
}
// The example displays the following output:
//    -32768 (Int16) --> -32768 (Decimal)
//    32767 (Int16) --> 32767 (Decimal)
//    4095 (Int16) --> 4095 (Decimal)
//    12345 (Int16) --> 12345 (Decimal)
//    -10000 (Int16) --> -10000 (Decimal)
//</Snippet3>
