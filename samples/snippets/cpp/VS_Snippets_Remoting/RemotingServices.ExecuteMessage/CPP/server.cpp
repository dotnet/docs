

#using <system.dll>
#using <system.runtime.remoting.dll>
#using "serviceclass.dll"

using namespace System;
using namespace System::Diagnostics;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Contexts;
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   TcpChannel^ channel;
   bool isReplicationServer = false;
   
   // Determine if this should be the replication server
   if ( (args->Length > 1) && (args[ 1 ]->ToLower()->Equals( "r" )) )
   {
      isReplicationServer = true;
      channel = gcnew TcpChannel( 9001 );
   }
   else
   {
      channel = gcnew TcpChannel( 9000 );
   }

   ChannelServices::RegisterChannel( channel );
   WellKnownServiceTypeEntry^ entry = gcnew WellKnownServiceTypeEntry( SampleService::typeid,"SampleServiceUri",WellKnownObjectMode::Singleton );
   RemotingConfiguration::RegisterWellKnownServiceType( entry );
   if (  !isReplicationServer )
   {
      ReplicationSinkProp ^ myProp = gcnew ReplicationSinkProp;
      Context::RegisterDynamicProperty( myProp, nullptr, nullptr );
   }

   Console::WriteLine( "**** Press enter to stop this process. ****\n" );
   Console::ReadLine();
   return 0;
}
