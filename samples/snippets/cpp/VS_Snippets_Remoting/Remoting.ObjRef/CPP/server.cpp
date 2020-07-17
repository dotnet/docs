

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
   HttpChannel^ channel = gcnew HttpChannel( 9000 );
   ChannelServices::RegisterChannel( channel );
   RemotingConfiguration::ApplicationName = "MySampleService";
   RemotingConfiguration::RegisterActivatedServiceType( SampleService::typeid );
   Console::WriteLine( "Press enter to end the server process." );
   Console::ReadLine();
   return 0;
}
