

// System::Runtime::Remoting::Lifetime.ILease*
// System::Runtime::Remoting::Lifetime.ILease*.InitialLeaseTime
// System::Runtime::Remoting::Lifetime.ILease*.CurrentLeaseTime
// System::Runtime::Remoting::Lifetime.ILease*.RenewOnCallTime
// System::Runtime::Remoting::Lifetime.ILease*.SponsorshipTimeout
//System::Runtime::Remoting::Lifetime.ILease*.CurrentState
// System::Runtime::Remoting::Lifetime.ILease*.Register(ISponsor*)
// System::Runtime::Remoting::Lifetime.ILease*.Renew(TimeSpam)
// System::Runtime::Remoting::Lifetime.ILease*.Unregister(ISponsor*)
// System::Runtime::Remoting::Lifetime.ILease*.Register(ISponsor*, TimeSpam)
/* The following example demonstrates 'InitialLeaseTime', 'CurrentLeaseTime',
'RenewOnCallTime', 'SponsorshipTimeout', 'CurrentState', 'Register', 'Renew',
'Unregister' and 'Register' methods of 'ClientSponsor' class.

In the example using 'RemotingServices::GetLifetimeService' the lease information
of the remote service is obtained. All the properties and methods 'ILease' are demonstrated
using this lease variable. The client registers itself with 'ClientSponsor' class.
After registeration the current lease time is displayed. The lease is expired
and renewed. Then the renewed lease time is displayed. Finally the client unregister itself.
The client again registers itself. This time with initial lease time mentioned at
the time of registeration. The lease time is displayed.
*/
// <Snippet1>
#using <system.dll>
#using <system.runtime.remoting.dll>
#using <ILease_Share.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Lifetime;
using namespace RemotingSamples;

// <Snippet2>
int main()
{
   // <Snippet3>
   // Register the channel.
   TcpChannel^ myChannel = gcnew TcpChannel;
   ChannelServices::RegisterChannel( myChannel );
   RemotingConfiguration::RegisterActivatedClientType( HelloService::typeid, "Tcp://localhost:8085" );
   TimeSpan myTimeSpan = TimeSpan::FromMinutes( 10 );

   // Create a remote object.
   HelloService ^ myService = gcnew HelloService;
   ILease^ myLease;
   myLease = dynamic_cast<ILease^>(RemotingServices::GetLifetimeService( myService ));
   if ( myLease == nullptr )
   {
      Console::WriteLine( "Cannot lease." );
      return  -1;
   }

   Console::WriteLine( "Initial lease time is {0}", myLease->InitialLeaseTime );
   Console::WriteLine( "Current lease time is {0}", myLease->CurrentLeaseTime );
   Console::WriteLine( "Renew on call time is {0}", myLease->RenewOnCallTime );
   Console::WriteLine( "Sponsorship timeout is {0}", myLease->SponsorshipTimeout );
   Console::WriteLine( "Current lease state is {0}", myLease->CurrentState );
   // </Snippet3>

   // Register with a sponser.
   ClientSponsor^ mySponsor = gcnew ClientSponsor;
   myLease->Register( mySponsor );
   Console::WriteLine( "Wait for lease to expire (approx. 15 seconds)..." );
   System::Threading::Thread::Sleep( myLease->CurrentLeaseTime );
   Console::WriteLine( "Current lease time before renewal is {0}", myLease->CurrentLeaseTime );

   // Renew the lease time.
   myLease->Renew( myTimeSpan );
   Console::WriteLine( "Current lease time after renewal is {0}", myLease->CurrentLeaseTime );

   // Call the Remote method.
   Console::WriteLine( "Remote method output is {0}", myService->HelloMethod( "Microsoft" ) );
   myLease->Unregister( mySponsor );
   GC::Collect();
   GC::WaitForPendingFinalizers();

   // Register with lease time of 15 minutes.
   myLease->Register( mySponsor, TimeSpan::FromMinutes( 15 ) );
   Console::WriteLine( "Registered client with lease time of 15 minutes." );
   Console::WriteLine( "Current lease time is {0}", myLease->CurrentLeaseTime );

   // Call the Remote method.
   Console::WriteLine( "Remote method output is {0}", myService->HelloMethod( "Microsoft" ) );
   myLease->Unregister( mySponsor );
}
// </Snippet2>
// </Snippet1>
