//<Snippet4>
using namespace System;

void main()
{
     // Define an array of 8-bit signed integer values.
     array<SByte>^ values = { SByte::MinValue, SByte::MaxValue,     
                              0x3F, 123, -100 };
     // Convert each value to a Decimal.
     for each (SByte value in values) {
        Decimal decValue = value;
        Console::WriteLine("{0} ({1}) --> {2} ({3})", value,
                          value.GetType()->Name, decValue,
                          decValue.GetType()->Name);         
     }
}
// The example displays the following output:
//       -128 (SByte) --> -128 (Decimal)
//       127 (SByte) --> 127 (Decimal)
//       63 (SByte) --> 63 (Decimal)
//       123 (SByte) --> 123 (Decimal)
//       -100 (SByte) --> -100 (Decimal)
// </Snippet4>
