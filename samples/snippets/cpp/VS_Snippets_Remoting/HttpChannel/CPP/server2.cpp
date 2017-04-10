
#using <system.dll>
#using <system.runtime.remoting.dll>
#using <Service.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Runtime::Remoting::Lifetime;
using namespace System::Collections::Specialized;
using namespace SampleNamespace;

// This assembly contains a remote service and its server host wrapped together.
int main()
{
   
   // The following sample uses an HttpChannel constructor
   // to create a new HttpChannel that will listen on port 9000.
   // System::Runtime::Remoting::Channels.Http::HttpChannel.HttpChannel(IDictionary*, IClientChannelSinkProvider*, IServerChannelSinkProvider*);
   // <Snippet4>
   ListDictionary^ channelProperties = gcnew ListDictionary;
   channelProperties->Add( "port", 9000 );
   HttpChannel^ channel = gcnew HttpChannel( channelProperties,gcnew SoapClientFormatterSinkProvider,gcnew SoapServerFormatterSinkProvider );
   ChannelServices::RegisterChannel( channel, false );
   RemotingConfiguration::RegisterWellKnownServiceType(SampleNamespace::SampleService::typeid, "MySampleService/SampleService::soap", WellKnownObjectMode::Singleton );
   Console::WriteLine( "** Press enter to end the server process. **" );
   Console::ReadLine();
   // </Snippet4>
}
