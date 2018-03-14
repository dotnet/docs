

#using <system.dll>
#using <system.runtime.remoting.dll>
#using "service.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace SampleNamespace;
using namespace System::Security::Permissions;

public ref class SampleClient
{
private:
   static const String^ SERVER_URL = "http://localhost:9000/MySampleService/SampleWellKnown.soap";

public:
   [SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::RemotingConfiguration)]    
   static void Snippet1()
   {
      // <Snippet1>
      Console::WriteLine( "Connecting to SampleNamespace::SampleWellKnown." );
      SampleWellKnown ^ proxy = dynamic_cast<SampleWellKnown^>(RemotingServices::Connect( SampleWellKnown::typeid, const_cast<String^>(SERVER_URL) ));
      Console::WriteLine( "Connected to SampleWellKnown" );

      // Verifies that the Object* reference is to a transparent proxy.
      if ( RemotingServices::IsTransparentProxy( proxy ) )
            Console::WriteLine( "proxy is a reference to a transparent proxy." );
      else
            Console::WriteLine( "proxy is not a transparent proxy.  This is unexpected." );

      // Calls a method on the server Object*.
      Console::WriteLine( "proxy->Add returned {0}.", proxy->Add( 2, 3 ) );
      // </Snippet1>
   }

};

int main()
{
   SampleClient::Snippet1();
   return 0;
}
