

#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <RemotingConfiguration_GetRegisteredWellKnownClient_Shared.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
int main()
{
   TcpChannel^ chan = gcnew TcpChannel( 8085 );
   ChannelServices::RegisterChannel( chan );
   RemotingConfiguration::RegisterWellKnownServiceType( MyServerImpl::typeid, "SayHello", WellKnownObjectMode::Singleton );
   Console::WriteLine( "Press <enter> to exit..." );
   Console::ReadLine();
}
