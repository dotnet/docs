
// <Snippet1>
using namespace System;
using namespace System::Reflection;
ref class MyClass
{
public:
   int myField;
};

void DisplayTypeHandle( RuntimeTypeHandle myTypeHandle )
{
   
   // Get the type from the handle.
   Type^ myType = Type::GetTypeFromHandle( myTypeHandle );
   
   // Display the type.
   Console::WriteLine( "\nDisplaying the type from the handle:\n" );
   Console::WriteLine( "The type is {0}.", myType );
}

int main()
{
   try
   {
      MyClass^ myClass = gcnew MyClass;
      
      // Get the type of MyClass.
      Type^ myClassType = myClass->GetType();
      
      // Get the runtime handle of MyClass.
      RuntimeTypeHandle myClassHandle = myClassType->TypeHandle;
      DisplayTypeHandle( myClassHandle );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }

}

// </Snippet1>
