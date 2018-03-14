
// <Snippet1>
using namespace System;
using namespace System::Reflection;
public ref class MyDemoClass{};

int main()
{
   try
   {
      Type^ myType = Type::GetType( "MyDemoClass" );
      
      // Get and display the 'IsClass' property of the 'MyDemoClass' instance.
      Console::WriteLine( "\nIs the specified type a class? {0}.", myType->IsClass );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nAn exception occurred: {0}.", e->Message );
   }

}

// </Snippet1>
