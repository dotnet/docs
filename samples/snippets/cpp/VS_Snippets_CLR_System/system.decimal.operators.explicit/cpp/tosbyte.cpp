// <Snippet1>
using namespace System;

void main()
{
   // Define an array of decimal values.
   array<Decimal>^ values = { Decimal::Parse("78"), 
                              Decimal(78000,0,0,false,3), 
                              Decimal::Parse("78.999"),
                              Decimal::Parse("255.999"),
                              Decimal::Parse("256"),
                              Decimal::Parse("127.999"),
                              Decimal::Parse("128"),
                              Decimal::Parse("-0.999"),
                              Decimal::Parse("-1"), 
                              Decimal::Parse("-128.999"),
                              Decimal::Parse("-129") };           
   for each (Decimal value in values) {
      try {
         SByte byteValue = (SByte) value;
         Console::WriteLine("{0} ({1}) --> {2} ({3})", value,
                            value.GetType()->Name, byteValue, 
                            byteValue.GetType()->Name);
      }
      catch (OverflowException^ e) {
          Console::WriteLine("OverflowException: Cannot convert {0}",
                            value);
      }   
   }
}
// The example displays the following output:
//       78 (Decimal) --> 78 (SByte)
//       78.000 (Decimal) --> 78 (SByte)
//       78.999 (Decimal) --> 78 (SByte)
//       OverflowException: Cannot convert 255.999
//       OverflowException: Cannot convert 256
//       127.999 (Decimal) --> 127 (SByte)
//       OverflowException: Cannot convert 128
//       -0.999 (Decimal) --> 0 (SByte)
//       -1 (Decimal) --> -1 (SByte)
//       -128.999 (Decimal) --> -128 (SByte)
//       OverflowException: Cannot convert -129
// </Snippet1>
