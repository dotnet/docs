// <Snippet3>
using namespace System;

void main()
{
     // Define an array of 16-bit unsigned integer values.
     array<UInt16>^ values = { UInt16::MinValue, UInt16::MaxValue,     
                               0xFFF, 12345, 40000 };
     // Convert each value to a Decimal.
     for each (UInt16 value in values) {
        Decimal decValue = value;
        Console::WriteLine("{0} ({1}) --> {2} ({3})", value,
                           value.GetType()->Name, decValue,
                           decValue.GetType()->Name);         
     }
}
// The example displays the following output:
//       0 (UInt16) --> 0 (Decimal)
//       65535 (UInt16) --> 65535 (Decimal)
//       4095 (UInt16) --> 4095 (Decimal)
//       12345 (UInt16) --> 12345 (Decimal)
//       40000 (UInt16) --> 40000 (Decimal)
// </Snippet3>
