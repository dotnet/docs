//<Snippet1>
#using <system.dll>
#using <system.runtime.remoting.dll>
#using "Service.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Collections;

int main()
{
   // Create a remotable object.
   TcpChannel^ tcpChannel = gcnew TcpChannel( 8085 );
   WellKnownServiceTypeEntry^ WKSTE =
      gcnew WellKnownServiceTypeEntry( HelloService::typeid,
         "Service",
         WellKnownObjectMode::Singleton );
   RemotingConfiguration::RegisterWellKnownServiceType( WKSTE );

   RemotingConfiguration::ApplicationName = "HelloServer";
   
   // Print out the urls for the HelloServer.
   array<String^>^ urls = tcpChannel->GetUrlsForUri( "HelloServer" );

   for each ( String^ url in urls )
   {
      System::Console::WriteLine( "{0}", url );
   }
   return 0;
}
//</Snippet1>
