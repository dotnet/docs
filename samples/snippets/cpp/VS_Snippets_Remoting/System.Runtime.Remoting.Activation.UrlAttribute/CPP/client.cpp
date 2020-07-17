

//<snippet0>
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using "RemoteObject.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Activation;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

[STAThread]
int main()
{
   
   // Report initial status.
   Console::WriteLine( "Client starting." );
   
   // Register TCP channel.
   ChannelServices::RegisterChannel( gcnew TcpChannel );
   
   //<snippet1>
   // Create UrlAttribute.
   UrlAttribute^ attribute = gcnew UrlAttribute( "tcp://localhost:1234/RemoteApp" );
   Console::WriteLine( "UrlAttribute value: {0}", attribute->UrlValue );
   
   //</snippet1>
   array<Object^>^activationAttributes = {attribute};
   
   // Use UrlAttribute to register for client activated remote object.
   RemotingConfiguration::RegisterActivatedClientType( RemoteObject::typeid, "tcp://localhost:1234/RemoteApp" );
   
   // Activate remote object.
   Console::WriteLine( "Activating remote object." );
   RemoteObject ^ obj = dynamic_cast<RemoteObject^>(Activator::CreateInstance( RemoteObject::typeid, nullptr, activationAttributes ));
   
   // Invoke a method on it.
   Console::WriteLine( "Invoking Hello() on remote object." );
   obj->Hello();
   
   // Inform user of termination.
   Console::WriteLine( "Terminating client." );
}

//</snippet0>
