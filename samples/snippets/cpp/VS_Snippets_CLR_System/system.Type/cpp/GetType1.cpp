// <Snippet2>
using namespace System;

void main()
{
   array<Object^>^ values = { "word", true, 120, 136.34 };
   for each (Object^ value in values)
      Console::WriteLine("{0} - type {1}", value, 
                        value->GetType()->Name);
}
// The example displays the following output:
//       word - type String
//       True - type Boolean
//       120 - type Int32
//       136.34 - type Double
// </Snippet2>

