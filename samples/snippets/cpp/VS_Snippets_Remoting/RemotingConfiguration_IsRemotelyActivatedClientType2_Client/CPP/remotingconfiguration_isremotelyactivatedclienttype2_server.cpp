

#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <RemotingConfiguration_IsRemotelyActivatedClientType2_Shared.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

int main()
{
   ChannelServices::RegisterChannel( gcnew TcpChannel( 8085 ), false );
   RemotingConfiguration::RegisterActivatedServiceType( MyServerImpl::typeid );
   Console::WriteLine( "Press enter to stop this process." );
   Console::ReadLine();
}
