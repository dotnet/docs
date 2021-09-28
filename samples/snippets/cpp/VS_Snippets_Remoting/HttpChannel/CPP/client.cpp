#using <system.dll>
#using <system.runtime.remoting.dll>
#using <service.dll>

using namespace System;
using namespace System::Net::Sockets;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::Remoting::Lifetime;
using namespace System::Security::Permissions;
using namespace SampleNamespace;

// The following sample uses an HttpChannel constructor
// to create a new HttpChannel, allowing this client to
// hook up to an event on a server Object*.
// System::Runtime::Remoting::Channels.Http::HttpChannel.HttpChannel(int)
// <Snippet2>
public ref class SampleClient: public MarshalByRefObject
{
public:
	[PermissionSet(SecurityAction::LinkDemand)]
   SampleClient()
   {
      ChannelServices::RegisterChannel( gcnew HttpChannel( 0 ), false );
	  SampleService ^ service = dynamic_cast<SampleService^>(Activator::GetObject(SampleNamespace::SampleService::typeid, "http://localhost:9000/MySampleService/SampleService::soap" ));
      
      // Subscribe to event so that the client can receive notification from ther server.
	  SomethingHappenedEventHandler ^ eventHandler = gcnew SomethingHappenedEventHandler(this, &SampleClient::OnSomethingHappened );
      service->SomethingHappened += eventHandler;
      
      // The server will fire the SomethingHappened event in SampleMethod()
      service->SampleMethod();
      service->SomethingHappened -= eventHandler;
   }

   void OnSomethingHappened( Object^ source, SampleServiceEventArgs^ e )
   {
      Console::WriteLine( "SomethingHappened event fired: {0}", e->Message );
   }

};

int main()
{
   SampleClient^ client = gcnew SampleClient;
}

// </Snippet2>
