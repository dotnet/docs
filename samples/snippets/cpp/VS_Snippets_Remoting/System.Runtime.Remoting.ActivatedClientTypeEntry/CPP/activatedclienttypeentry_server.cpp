

//<snippet10>
#using <ActivatedClientTypeEntry_Share.dll>
#using <System.Runtime.Remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
void main()
{
   ChannelServices::RegisterChannel( gcnew TcpChannel( 8082 ) );
   RemotingConfiguration::RegisterActivatedServiceType( HelloServer::typeid );
   Console::WriteLine( "Press enter to stop this process" );
   Console::ReadLine();
}

//</snippet10>
