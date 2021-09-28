// System::Runtime::Remoting::CallContext.SetHeaders(Header->Item[])

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::Remoting::Contexts;
using namespace System::Security;
using namespace System::Security::Principal;
using namespace System::Security::Permissions;

// <Snippet3>
public ref class HelloService: public MarshalByRefObject
{
public:
   String^ HelloMethod( String^ name )
   {
      Console::WriteLine( "Hello {0}", name );
      return "Hello {0}",name;
   }


   [SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::Infrastructure)]
   String^ HeaderMethod( String^ name, array<Header^>^arrHeader )
   {
      Console::WriteLine( "HeaderMethod {0}", name );
      
      //Header Set with the header array passed
      CallContext::SetHeaders( arrHeader );
      return "HeaderMethod {0}",name;
   }
};
// </Snippet3>

// 'CallContext' and 'ILogicalThreadAffinative*' is needed to pass information between threads
// on either end of a call across an application domain boundary or context boundary.

[Serializable]
public ref class MyLogicalCallContextData: public ILogicalThreadAffinative
{
private:
   int noOfAccesses;
   IPrincipal^ myIprincipal;

public:
   property String^ numOfAccesses 
   {
      String^ get()
      {
         return String::Format( "The identity of {0} has been accessed {1} times.",
            myIprincipal->Identity->Name, noOfAccesses );
      }
   }

   property IPrincipal^ Principal 
   {
      IPrincipal^ get()
      {
         noOfAccesses++;
         return myIprincipal;
      }
   }

   MyLogicalCallContextData( IPrincipal^ p )
   {
      noOfAccesses = 0;
      myIprincipal = p;
   }
};
