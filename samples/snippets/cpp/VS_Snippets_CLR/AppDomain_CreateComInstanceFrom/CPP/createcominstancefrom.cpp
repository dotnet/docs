
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::InteropServices;

[ComVisible(true)]
public ref class MyComVisibleType
{
public:
   MyComVisibleType()
   {
      Console::WriteLine( "MyComVisibleType instantiated!" );
   }

};


[ComVisible(false)]
public ref class MyComNonVisibleType
{
public:
   MyComNonVisibleType()
   {
      Console::WriteLine( "MyComNonVisibleType instantiated!" );
   }

};

void CreateComInstance( String^ typeName )
{
   try
   {
      AppDomain^ currentDomain = AppDomain::CurrentDomain;
      String^ assemblyName = currentDomain->FriendlyName;
      currentDomain->CreateComInstanceFrom( assemblyName, typeName );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }

}

int main()
{
   CreateComInstance( "MyComNonVisibleType" ); // Fail!
   CreateComInstance( "MyComVisibleType" ); // OK!
}

// </Snippet1>
