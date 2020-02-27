// <Snippet4>
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
         Byte byteValue = (Byte) value;
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
//       78 (Decimal) --> 78 (Byte)
//       78.000 (Decimal) --> 78 (Byte)
//       78.999 (Decimal) --> 78 (Byte)
//       255.999 (Decimal) --> 255 (Byte)
//       OverflowException: Cannot convert 256
//       127.999 (Decimal) --> 127 (Byte)
//       128 (Decimal) --> 128 (Byte)
//       -0.999 (Decimal) --> 0 (Byte)
//       OverflowException: Cannot convert -1
//       OverflowException: Cannot convert -128.999
//       OverflowException: Cannot convert -129
// </Snippet4>
