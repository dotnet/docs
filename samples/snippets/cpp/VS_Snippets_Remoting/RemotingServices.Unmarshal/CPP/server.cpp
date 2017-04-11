#using <system.dll>
#using <system.runtime.remoting.dll>
#using "service.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Runtime::Remoting::Lifetime;
using namespace SampleNamespace;

int main()
{
   // System::Runtime::Remoting::RemotingServices.SetObjectUriForMarshal
   // <Snippet1>
   RemotingConfiguration::ApplicationName = "MySampleService";
   HttpChannel^ channel = gcnew HttpChannel( 9000 );
   ChannelServices::RegisterChannel( channel );
   SampleService^ objectService = gcnew SampleService;
   RemotingServices::SetObjectUriForMarshal( objectService, "SampleService.soap" );
   RemotingServices::Marshal( objectService );

   Console::WriteLine( "Press enter to end the server process." );
   Console::ReadLine();
   // </Snippet1>
}
