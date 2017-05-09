

// <Snippet4>
#using <system.dll>
#using <system.runtime.remoting.dll>
#using <ILease_Share.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Lifetime;
using namespace RemotingSamples;

int main()
{
   TcpChannel^ myChannel = gcnew TcpChannel( 8085 );
   ChannelServices::RegisterChannel( myChannel );
   RemotingConfiguration::RegisterActivatedServiceType( HelloService::typeid );
   Console::WriteLine( "Server started." );
   Console::WriteLine( "Hit enter to terminate..." );
   Console::Read();
}
// </Snippet4>
