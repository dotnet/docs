using namespace System;
using namespace System::Text;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Security::Principal;
using namespace System::Security::Permissions;

ref class LogicalCallContextData;

public ref class HelloServiceClass: public MarshalByRefObject
{
private:
   static int n_instances;
   int instanceNum;

public:
   HelloServiceClass()
   {
      n_instances++;
      instanceNum = n_instances;
      Console::WriteLine(  "{0} has been created.  Instance # = {1}", this->GetType()->Name, instanceNum );
   }

   ~HelloServiceClass()
   {
      Console::WriteLine( "Destroyed instance {0} of HelloServiceClass.", instanceNum );
   }

   [SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::Infrastructure)]
   String^ HelloMethod( String^ name )
   {
      //Extract the call context data
      LogicalCallContextData^ data = dynamic_cast<LogicalCallContextData^>(CallContext::GetData( "test data" ));
      IPrincipal^ myPrincipal = data->Principal;

      //Check the user identity
      if ( myPrincipal->Identity->Name == "Bob" )
      {
         Console::WriteLine( "\nHello {0}, you are identified!", myPrincipal->Identity->Name );
         Console::WriteLine( data->numOfAccesses );
      }
      else
      {
         Console::WriteLine( "Go away! You are not identified!" );
         return String::Empty;
      }

      // calculate and return result to client    
      return String::Format( "Hi there {0}.", name );
   }
};