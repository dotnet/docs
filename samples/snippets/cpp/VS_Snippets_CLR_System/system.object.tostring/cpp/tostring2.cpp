// <Snippet2>
using namespace System;

namespace Examples
{
   ref class Object1
   {
   };
}

void main()
{
   Object^ obj1 = gcnew Examples::Object1();
   Console::WriteLine(obj1->ToString());
}
// The example displays the following output:
//   Examples.Object1
// </Snippet2>
