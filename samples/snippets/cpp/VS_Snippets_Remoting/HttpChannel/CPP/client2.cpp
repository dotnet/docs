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
using namespace SampleNamespace;

// The following sample uses an HttpChannel constructor
// to create a new HttpChannel.  
// NOTE: manually instantiating HttpChannel() and registering it does not seem
// necessary.  This sample will work if the line of code is commented out.
// System::Runtime::Remoting::Channels.Http::HttpChannel.HttpChannel()
// <Snippet3>
public ref class SampleClient: public MarshalByRefObject
{
public:
   void main()
   {
      ChannelServices::RegisterChannel( gcnew HttpChannel, false );
	  RemotingConfiguration::RegisterWellKnownClientType( SampleService::typeid, "http://localhost:9000/MySampleService/SampleService::soap" );
      SampleService ^ service = gcnew SampleService;
      service->SampleMethod();
   }

};


// actual entry point
int main()
{
   SampleClient^ p = gcnew SampleClient;
   p->main();
   return 0;
}

// </Snippet3>
