

#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <RemotingConfiguration_GetRegisteredActivatedService_Shared.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

int main()
{
   try
   {
      ChannelServices::RegisterChannel( gcnew TcpChannel );
      RemotingConfiguration::RegisterActivatedClientType( MyServerImpl::typeid, "tcp://localhost:8085" );
      MyServerImpl ^ myObject = gcnew MyServerImpl;
      for ( int i = 0; i <= 4; i++ )
         Console::WriteLine( myObject->MyMethod( String::Format( "invoke the server method {0} time", (i + 1) ) ) );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }
}
