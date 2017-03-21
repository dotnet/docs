#using <system.dll>
#using <system.runtime.remoting.dll>
#using <ClientSponsor_Share.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Lifetime;

int main()
{
   // Register a channel.
   TcpChannel^ myChannel = gcnew TcpChannel;
   ChannelServices::RegisterChannel( myChannel );
   RemotingConfiguration::RegisterActivatedClientType(
      RemotingSamples::HelloService::typeid, "tcp://localhost:8085/" );
   
   // Get the remote Object*.
   RemotingSamples::HelloService ^ myService = gcnew RemotingSamples::HelloService;
   
   // Get a sponsor for renewal of time.
   ClientSponsor^ mySponsor = gcnew ClientSponsor;
   
   // Register the service with sponsor.
   mySponsor->Register( myService );
   
   // Set renewaltime.
   mySponsor->RenewalTime = TimeSpan::FromMinutes( 2 );
   
   // Renew the lease.
   ILease^ myLease = dynamic_cast<ILease^>(mySponsor->InitializeLifetimeService());
   TimeSpan myTime = mySponsor->Renewal( myLease );
   Console::WriteLine( "Renewed time in minutes is {0}", myTime.Minutes );
   
   // Call the remote method.
   Console::WriteLine( myService->HelloMethod( "World" ) );
   
   // Unregister the channel.
   mySponsor->Unregister( myService );
   mySponsor->Close();
}