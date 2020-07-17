

//<snippet2>
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using "RemoteObject.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

[STAThread]
int main()
{
   
   // Report status to user.
   Console::WriteLine( "Server starting." );
   
   // Register the TCP channel.
   ChannelServices::RegisterChannel( gcnew TcpChannel( 1234 ) );
   
   // Set application name.
   RemotingConfiguration::ApplicationName = "RemoteApp";
   
   // Register object for client activated remoting.
   RemotingConfiguration::RegisterActivatedServiceType( RemoteObject::typeid );
   
   // Wait until termination.
   Console::WriteLine( "Press enter to end." );
   Console::ReadLine();
   Console::WriteLine( "Terminating server." );
}

//</snippet2>
