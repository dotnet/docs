// <Snippet5>
#using <system.dll>
#using <system.runtime.remoting.dll>
#using "server.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Channels;

int main()
{
   // open channel and get handle to Object
   ChannelServices::RegisterChannel( gcnew TcpChannel );
   
   //Registering the well known Object on the client side for use by the operator gcnew.
   RemotingConfiguration::RegisterWellKnownClientType( HelloServer::typeid,
      "tcp://localhost:8084/SayHello" );
   HelloServer^ obj = gcnew HelloServer;
   
   // call remote method
   Console::WriteLine();
   Console::WriteLine( "Before Call" );
   Console::WriteLine( obj->HelloMethod( "Caveman" ) );
   Console::WriteLine( obj->HelloMethod( "Spaceman" ) );
   Console::WriteLine( obj->HelloMethod( "Client Man" ) );
   Console::WriteLine( "After Call" );
   Console::WriteLine();
}
//</Snippet5>