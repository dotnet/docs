// <Snippet1>
#using <system.dll>

using namespace System;
using namespace System::Timers;

public ref class Timer2
{
private: 
   static System::Timers::Timer^ aTimer;

public:
   static void Main()
   {
      // Create a new Timer with Interval set to 1.5 seconds.
      double interval = 1500.0;
      aTimer = gcnew System::Timers::Timer(interval);

      // Hook up the event handler for the Elapsed event.
      aTimer->Elapsed += gcnew ElapsedEventHandler( OnTimedEvent );
      
      // Only raise the event the first time Interval elapses.
      aTimer->AutoReset = false;
      aTimer->Enabled = true;

      // Ensure the event fires before the exit message appears.
      System::Threading::Thread::Sleep((int) interval * 2);
      Console::WriteLine("Press the Enter key to exit the program.");
      Console::ReadLine();

      // If the timer is declared in a long-running method, use
      // KeepAlive to prevent garbage collection from occurring
      // before the method ends.
      //GC::KeepAlive(aTimer);
   }

private:
   // Handle the Elapsed event.
   static void OnTimedEvent( Object^ /*source*/, ElapsedEventArgs^ /*e*/ )
   {
      Console::WriteLine( "Hello World!" );
   }

};

int main()
{
   Timer2::Main();
}
// The example displays the following output:
//       Hello World!
//       Press the Enter key to exit the program.
// </Snippet1>
