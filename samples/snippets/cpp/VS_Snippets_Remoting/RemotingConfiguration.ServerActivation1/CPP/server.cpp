

// <Snippet1>
#using <system.dll>
#using <system.runtime.remoting.dll>
#using "service.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
int main()
{
   // </Snippet1>
   // <Snippet2>
   ChannelServices::RegisterChannel( gcnew TcpChannel( 8082 ) );
   RemotingConfiguration::ApplicationName = "HelloServiceApplication";
   RemotingConfiguration::RegisterWellKnownServiceType( HelloService::typeid,
                                                        "MyUri",
                                                        WellKnownObjectMode::SingleCall );
   // </Snippet2>
   // <Snippet3>
   Console::WriteLine( "Press enter to stop this process." );
   Console::ReadLine();
   return 0;
}
// </Snippet3>
