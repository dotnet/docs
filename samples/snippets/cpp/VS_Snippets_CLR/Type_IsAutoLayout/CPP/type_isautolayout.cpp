

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::ComponentModel;
using namespace System::Runtime::InteropServices;

// The MyDemoAttribute class is selected as AutoLayout.

[StructLayoutAttribute(LayoutKind::Auto)]
public ref class MyDemoAttribute{};

void MyAutoLayoutMethod( String^ typeName )
{
   try
   {
      
      // Create an instance of the Type class using the GetType method.
      Type^ myType = Type::GetType( typeName );
      
      // Get and display the IsAutoLayout property of the
      // MyDemoAttribute instance.
      Console::WriteLine( "\nThe AutoLayout property for the MyDemoAttribute is {0}.", myType->IsAutoLayout );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "\nAn exception occurred: {0}.", e->Message );
   }

}

int main()
{
   MyAutoLayoutMethod( "MyDemoAttribute" );
}

// </Snippet1>
