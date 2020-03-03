//<Snippet1>
#using <System.dll>
using namespace System;
using namespace System::Threading;

public ref class Example
{
public:
   static void main()
   {
      // Create a Semaphore object that represents the named
      // system semaphore "SemaphoreExample3". The semaphore has a
      // maximum count of five. The initial count is also five.
      // There is no point in using a smaller initial count,
      // because the initial count is not used if this program
      // doesn't create the named system semaphore, and with
      // this method overload there is no way to tell. Thus, this
      // program assumes that it is competing with other
      // programs for the semaphore.
      //
      Semaphore^ sem = gcnew Semaphore( 5,5,L"SemaphoreExample3" );
      
      // Attempt to enter the semaphore three times. If another
      // copy of this program is already running, only the first
      // two requests can be satisfied. The third blocks. Note
      // that in a real application, timeouts should be used
      // on the WaitOne calls, to avoid deadlocks.
      //
      sem->WaitOne();
      Console::WriteLine( L"Entered the semaphore once." );
      sem->WaitOne();
      Console::WriteLine( L"Entered the semaphore twice." );
      sem->WaitOne();
      Console::WriteLine( L"Entered the semaphore three times." );
      
      // The thread executing this program has entered the
      // semaphore three times. If a second copy of the program
      // is run, it will block until this program releases the
      // semaphore at least once.
      //
      Console::WriteLine( L"Enter the number of times to call Release." );
      int n;
      if ( Int32::TryParse( Console::ReadLine(),n ) )
      {
         sem->Release( n );
      }

      int remaining = 3 - n;
      if ( remaining > 0 )
      {
         Console::WriteLine( L"Press Enter to release the remaining "
         L"count ({0}) and exit the program.", remaining );
         Console::ReadLine();
         sem->Release( remaining );
      }
   }
};
//</Snippet1>
