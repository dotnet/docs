
// <Snippet1>
using namespace System;
using namespace System::Threading;
ref class StatusChecker
{
private:
   int invokeCount;
   int maxCount;

public:
   StatusChecker( int count )
      : invokeCount( 0 ), maxCount( count )
   {}


   // This method is called by the timer delegate.
   void CheckStatus( Object^ stateInfo )
   {
      AutoResetEvent^ autoEvent = dynamic_cast<AutoResetEvent^>(stateInfo);
      Console::WriteLine( "{0} Checking status {1,2}.", DateTime::Now.ToString(  "h:mm:ss.fff" ), (++invokeCount).ToString() );
      if ( invokeCount == maxCount )
      {
         
         // Reset the counter and signal main.
         invokeCount = 0;
         autoEvent->Set();
      }
   }

};

int main()
{
   AutoResetEvent^ autoEvent = gcnew AutoResetEvent( false );
   StatusChecker^ statusChecker = gcnew StatusChecker( 10 );
   
   // Create the delegate that invokes methods for the timer.
   TimerCallback^ timerDelegate = gcnew TimerCallback( statusChecker, &StatusChecker::CheckStatus );
   TimeSpan delayTime = TimeSpan(0,0,1);
   TimeSpan intervalTime = TimeSpan(0,0,0,0,250);
   
   // Create a timer that signals the delegate to invoke CheckStatus 
   // after one second, and every 1/4 second thereafter.
   Console::WriteLine( "{0} Creating timer.\n", DateTime::Now.ToString(  "h:mm:ss.fff" ) );
   Timer^ stateTimer = gcnew Timer( timerDelegate,autoEvent,delayTime,intervalTime );
   
   // When autoEvent signals, change the period to every 1/2 second.
   autoEvent->WaitOne( 5000, false );
   stateTimer->Change( TimeSpan(0), intervalTime + intervalTime );
   Console::WriteLine( "\nChanging period.\n" );
   
   // When autoEvent signals the second time, dispose of the timer.
   autoEvent->WaitOne( 5000, false );
   stateTimer->~Timer();
   Console::WriteLine( "\nDestroying timer." );
}

// </Snippet1>
