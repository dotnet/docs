
// <Snippet1>
using namespace System;
using namespace System::Reflection;
public ref class MyClass
{
protected:
   String^ myField;

public:
   MyClass()
   {
      myField =  "A sample protected field";
   }
};

int main()
{
   try
   {
      MyClass^ myObject = gcnew MyClass;
      
      // Get the type of the 'MyClass'.
      Type^ myType = MyClass::typeid;
      
      // Get the field information and the attributes associated with MyClass.
      FieldInfo^ myFieldInfo = myType->GetField( "myField", static_cast<BindingFlags>(BindingFlags::NonPublic | BindingFlags::Instance) );
      Console::WriteLine( "\nChecking for the AnsiClass attribute for a field.\n" );
      
      // Get and display the name, field, and the AnsiClass attribute.
      Console::WriteLine( "Name of Class: {0} \nValue of Field: {1} \nIsAnsiClass = {2}", myType->FullName, myFieldInfo->GetValue( myObject ), myType->IsAnsiClass );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
// </Snippet1>
