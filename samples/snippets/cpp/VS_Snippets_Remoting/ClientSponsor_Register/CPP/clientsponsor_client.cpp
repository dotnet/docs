// System::Runtime::Remoting::Lifetime.ClientSponsor::Register(MarshalByRefObject)
// System::Runtime::Remoting::Lifetime.ClientSponsor::Unregister(MarshalByRefObject)
// System::Runtime::Remoting::Lifetime.ClientSponsor::RenewalTime
// System::Runtime::Remoting::Lifetime.ClientSponsor::InitializeLifetimeService()
// System::Runtime::Remoting::Lifetime.ClientSponsor::Renewal(ILease*)
// System::Runtime::Remoting::Lifetime.ClientSponsor::Close()
// System::Runtime::Remoting::Lifetime.ClientSponsor

/* The following example demonstrates 'RenewalTime', 'Register', 'UnRegister' and
'Close' methods of 'ClientSponsor' class.
A remote Object* is created and registered with 'ClientSponsor' class. The renewal
time is set. Then the leased time is renewed and the method of remote Object* is invoked.
Finally the remote Object* is unregistered.
*/

// <Snippet1>
#using <system.dll>
#using <system.runtime.remoting.dll>
#using <ClientSponsor_Share.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Lifetime;

// <Snippet2>
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
// </Snippet2>
// </Snippet1>
