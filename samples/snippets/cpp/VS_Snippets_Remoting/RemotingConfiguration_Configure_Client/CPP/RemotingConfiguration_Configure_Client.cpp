

#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <RemotingConfiguration_Configure_Shared.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

int main()
{
   TcpChannel^ myChannel = gcnew TcpChannel;
   ChannelServices::RegisterChannel( myChannel );
   MyServerImpl ^ myObject = dynamic_cast<MyServerImpl^>(Activator::GetObject( MyServerImpl::typeid, "tcp://localhost:8085/SayHello" ));
   Console::WriteLine( myObject->MyMethod( "ClientString" ) );
}
