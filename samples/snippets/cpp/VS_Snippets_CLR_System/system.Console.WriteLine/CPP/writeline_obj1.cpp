// <Snippet3>
using namespace System;

void main()
{
   array<Object^>^ values = { true, 12.632, 17908, "stringValue",
                              'a', (Decimal) 16907.32 };
   for each (Object^ value in values)
      Console::WriteLine(value);
}
// The example displays the following output:
//    True
//    12.632
//    17908
//    stringValue
//    a
//    16907.32
// </Snippet3>
