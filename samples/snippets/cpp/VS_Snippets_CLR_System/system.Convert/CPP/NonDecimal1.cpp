// <Snippet2>
using namespace System;

void main()
{
   array<int>^ baseValues = { 2, 8, 10, 16 };
   Int16 value = Int16::MaxValue;
   for each (Int16 baseValue in baseValues) {
      String^ s = Convert::ToString(value, baseValue);
      Int16 value2 = Convert::ToInt16(s, baseValue);

      Console::WriteLine("{0} --> {1} (base {2}) --> {3}", 
                        value, s, baseValue, value2);
   }                     
}
// The example displays the following output:
//     32767 --> 111111111111111 (base 2) --> 32767
//     32767 --> 77777 (base 8) --> 32767
//     32767 --> 32767 (base 10) --> 32767
//     32767 --> 7fff (base 16) --> 32767
// </Snippet2>
