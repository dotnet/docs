#using <system.dll>
#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Runtime::Remoting::Lifetime;
using namespace System::Timers;

namespace TimerSample
{
   // Define the event arguments

   [Serializable]
   public ref class TimerServiceEventArgs: public EventArgs
   {
   private:
      String^ m_Message;

   public:
      TimerServiceEventArgs( String^ message )
      {
         m_Message = message;
      }

      property String^ Message 
      {
         String^ get()
         {
            return m_Message;
         }
      }
   };

   public delegate void TimerExpiredEventHandler(    // Define the delegate for the event
   Object^ sender, TimerServiceEventArgs^ e );

   // Define the remote service class
   public ref class TimerService: public MarshalByRefObject
   {
   private:
      double m_MinutesToTime;
      Timer^ m_Timer;

   public:
      event TimerExpiredEventHandler^ TimerExpired;

      // The client will subscribe and unsubscribe to this event
      // Default: Initialize the TimerService to 4 minutes, the time required
      // to brew coffee in a French Press.
      TimerService()
      {
         Console::WriteLine( "TimerService instantiated." );
         m_MinutesToTime = 4.0;
         m_Timer = gcnew Timer;
         m_Timer->Elapsed += gcnew ElapsedEventHandler( this, &TimerService::OnElapsed );
      }

      TimerService( double minutes )
      {
         Console::WriteLine( "TimerService instantiated." );
         m_MinutesToTime = minutes;
         m_Timer = gcnew Timer;
         m_Timer->Elapsed += gcnew ElapsedEventHandler( this, &TimerService::OnElapsed );
      }

      property double MinutesToTime 
      {
         double get()
         {
            return m_MinutesToTime;
         }

         void set( double value )
         {
            m_MinutesToTime = value;
         }

      }
      void Start()
      {
         if (  !m_Timer->Enabled )
         {
            TimeSpan interval = TimeSpan::FromMinutes( m_MinutesToTime );
            m_Timer->Interval = interval.TotalMilliseconds;
            m_Timer->Enabled = true;
         }
         else
         {
            // TODO: Raise an exception
         }
      }

      [System::Security::Permissions::SecurityPermissionAttribute
      (System::Security::Permissions::SecurityAction::LinkDemand, 
      Flags=System::Security::Permissions::SecurityPermissionFlag::Infrastructure)]
      virtual Object^ InitializeLifetimeService() override
      {
         ILease^ lease = dynamic_cast<ILease^>(MarshalByRefObject::InitializeLifetimeService());
         if ( lease->CurrentState == LeaseState::Initial )
         {
            lease->InitialLeaseTime = TimeSpan::FromMinutes( 0.125 );
            lease->SponsorshipTimeout = TimeSpan::FromMinutes( 2 );
            lease->RenewOnCallTime = TimeSpan::FromSeconds( 2 );
            Console::WriteLine( "TimerService: InitializeLifetimeService" );
         }

         return lease;
      }
    private:	
      void OnElapsed( Object^ source, ElapsedEventArgs^ e )
      {
         m_Timer->Enabled = false;
         
         // Fire Event
         // Package String in TimerServiceEventArgs
         TimerServiceEventArgs^ timerEventArgs = gcnew TimerServiceEventArgs( "TimerServiceEventArgs: Timer Expired." );
         Console::WriteLine( "Firing TimerExpired Event" );
         TimerExpired( this, timerEventArgs );
      }
   };
}
