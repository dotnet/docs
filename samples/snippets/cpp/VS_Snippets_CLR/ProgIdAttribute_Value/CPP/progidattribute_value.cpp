/*
System::Runtime::InteropServices::ProgIdAttribute.Value

The program shows MyClass as a COM class with prog id 'InteropSample::MyClass'.
It gets all attributes of MyClass by calling GetAttributes method of TypeDescriptor
then prints the 'Value' property of 'ProgIdAttribute' class.
*/

#using <system.dll>

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::ComponentModel;

// <Snippet1>
[ClassInterface(ClassInterfaceType::AutoDispatch)]
[ProgId("InteropSample.MyClass")]
public ref class MyClass
{
public:
   MyClass(){}

};

int main()
{
   try
   {
      AttributeCollection^ attributes;
      attributes = TypeDescriptor::GetAttributes( MyClass::typeid );
      ProgIdAttribute^ progIdAttributeObj = dynamic_cast<ProgIdAttribute^>(attributes[ ProgIdAttribute::typeid ]);
      Console::WriteLine( "ProgIdAttribute's value is set to : {0}", progIdAttributeObj->Value );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
   }
}
// </Snippet1>
