
// <Snippet1>
using namespace System;
using namespace System::Reflection;

ref class Example
{
  public:
     static String^ val = "test";
};

int main()
{
   FieldInfo^ fld = Example::typeid->GetField( "val" );
   Console::WriteLine(fld->GetValue(nullptr) );
   Example::val = "hi";
   Console::WriteLine(fld->GetValue(nullptr) );
}
// The example displays the following output:
//     test
//     hi
// </Snippet1>
