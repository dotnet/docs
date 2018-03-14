
// <Snippet1>
using namespace System;
using namespace System::Runtime::Remoting;
public ref class MyType: public MarshalByRefObject
{
public:
   MyType()
   {
      Console::Write( "Created an instance of MyType in an AppDomain with the " );
      Console::WriteLine( "hash code {0}", AppDomain::CurrentDomain->GetHashCode() );
      Console::WriteLine( "" );
   }

   int GetAppDomainHashCode()
   {
      return AppDomain::CurrentDomain->GetHashCode();
   }

};

int main()
{
   Console::WriteLine( "The hash code of the default AppDomain is {0}.", AppDomain::CurrentDomain->GetHashCode() );
   Console::WriteLine( "" );
   
   // Creates another AppDomain.
   AppDomain^ domain = AppDomain::CreateDomain( "AnotherDomain", nullptr, (AppDomainSetup^)nullptr );
   
   // <Snippet2>
   // Creates an instance of MyType defined in the assembly called ObjectHandleAssembly.
   ObjectHandle^ obj = domain->CreateInstance( "ObjectHandleAssembly", "MyType" );
   
   // Unwraps the proxy to the MyType object created in the other AppDomain.
   MyType^ testObj = dynamic_cast<MyType^>(obj->Unwrap());
   if ( RemotingServices::IsTransparentProxy( testObj ) )
      Console::WriteLine( "The unwrapped object is a proxy." );
   else
      Console::WriteLine( "The unwrapped object is not a proxy!" );

   Console::WriteLine( "" );
   Console::Write( "Calling a method on the object located in an AppDomain with the hash code " );
   Console::WriteLine( testObj->GetAppDomainHashCode() );
   
   // </Snippet2>
}

// </Snippet1>
