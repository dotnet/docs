// System::Runtime::Remoting::RemotingServices.GetLifetimeService
// This sample is of a remote client for a group coffee timer.
// Since the client must stay connected to a stateful server object
// for minutes without calling it, it needs to register as a sponsor
// of the lease to prevent the server from being collected.
// Multiple clients can connect to the same timer object, and receive
// notification when the timer expires.
// System::Runtime::Remoting::RemotingServices.GetLifetimeService
// <Snippet1>
#using <system.dll>
#using <system.runtime.remoting.dll>
#using "timerservice.dll"

using namespace System;
using namespace System::Net::Sockets;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::Remoting::Lifetime;
using namespace TimerSample;
using namespace System::Security::Permissions;

namespace GroupCoffeeTimer
{
   public ref class TimerClient: public MarshalByRefObject, public ISponsor
   {
   public:
      [SecurityPermissionAttribute(SecurityAction::Demand, Flags=SecurityPermissionFlag::Infrastructure)]   
      TimerClient()
      {
         // Registers the HTTP Channel so that this client can receive
         // events from the remote service.
         ChannelServices::RegisterChannel( gcnew HttpChannel( 0 ), false );
         WellKnownClientTypeEntry^ remoteType = gcnew WellKnownClientTypeEntry( TimerService::typeid,"http://localhost:9000/MyService/TimerService.soap" );
         RemotingConfiguration::RegisterWellKnownClientType( remoteType );
         TimerService^ groupTimer = gcnew TimerService;
         groupTimer->MinutesToTime = 4.0;

         // Registers this client as a lease sponsor so that it can
         // prevent the expiration of the TimerService.
         ILease^ leaseObject = dynamic_cast<ILease^>(RemotingServices::GetLifetimeService( groupTimer ));
         leaseObject->Register( this );

         // Subscribes to the event so that the client can receive notifications from the server.
         groupTimer->TimerExpired += gcnew TimerExpiredEventHandler( this, &TimerClient::OnTimerExpired );
         Console::WriteLine( "Connected to TimerExpired event" );
         groupTimer->Start();
         Console::WriteLine( "Timer started for {0} minutes.", groupTimer->MinutesToTime );
         Console::WriteLine( "Press enter to end the client process." );
         Console::ReadLine();
      }

   private:
      void OnTimerExpired( Object^, TimerServiceEventArgs^ e )
      {
         Console::WriteLine( "TimerHelper::OnTimerExpired: {0}", e->Message );
      }
 public:
      [System::Security::Permissions::PermissionSet(System::Security::
         Permissions::SecurityAction::Demand, Name = "FullTrust")]
   virtual TimeSpan Renewal( ILease^ )
      {
         Console::WriteLine( "TimerClient: Renewal called." );
         return TimeSpan::FromMinutes( 0.5 );
      }
   };
}

int main()
{
   using namespace GroupCoffeeTimer;
   gcnew TimerClient;
}
// </Snippet1>
