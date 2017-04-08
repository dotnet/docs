
// <Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class MyClass
{
public:
   String^ MyField;
};

void DisplayFieldHandle( RuntimeFieldHandle myFieldHandle )
{
   // Get the type from the handle.
   FieldInfo^ myField = FieldInfo::GetFieldFromHandle( myFieldHandle );

   // Display the type.
   Console::WriteLine( "\nDisplaying the field from the handle.\n" );
   Console::WriteLine( "The type is {0}.", myField );
}

int main()
{
   MyClass^ myClass = gcnew MyClass;

   // Get the type of MyClass.
   Type^ myType = MyClass::typeid;
   try
   {
      // Get the field information of MyField.
      FieldInfo^ myFieldInfo = myType->GetField( "MyField", static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Instance) );

      // Determine whether or not the FieldInfo Object* is 0.
      if ( myFieldInfo != nullptr )
      {
         // Get the handle for the field.
         RuntimeFieldHandle myFieldHandle = myFieldInfo->FieldHandle;
         DisplayFieldHandle( myFieldHandle );
      }
      else
      {
         Console::WriteLine( "The myFieldInfo Object* is 0." );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
// </Snippet1>
