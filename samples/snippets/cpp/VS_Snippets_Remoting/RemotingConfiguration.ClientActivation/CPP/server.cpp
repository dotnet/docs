

// <Snippet2>
#using <system.dll>
#using <system.runtime.remoting.dll>
#using "service.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

int main()
{
   ChannelServices::RegisterChannel( gcnew TcpChannel( 8082 ) );
   RemotingConfiguration::RegisterActivatedServiceType( HelloServiceClass::typeid );
   Console::WriteLine( "Press enter to stop this process." );
   Console::ReadLine();
   return 0;
}
// </Snippet2>
