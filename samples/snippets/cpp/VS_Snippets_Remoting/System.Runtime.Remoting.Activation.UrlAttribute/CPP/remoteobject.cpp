
//<snippet3>
using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;

[assembly:AllowPartiallyTrustedCallersAttribute];
public ref class RemoteObject: public MarshalByRefObject
{
public:
   RemoteObject()
   {
      
      // Report object construction to server's console.
      Console::WriteLine( "You have called the constructor." );
   }

   void Hello()
   {
      
      // Report method invocation to server's console.
      Console::WriteLine( "You have called Hello()." );
   }

};

//</snippet3>
