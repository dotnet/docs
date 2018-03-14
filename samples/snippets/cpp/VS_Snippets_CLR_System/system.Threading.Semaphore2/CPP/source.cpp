//<Snippet1>
#using <System.dll>
using namespace System;
using namespace System::Threading;

public ref class Example
{
private:
   // A semaphore that simulates a limited resource pool.
   //
   static Semaphore^ _pool;

   // A padding interval to make the output more orderly.
   static int _padding;

public:
   static void Main()
   {
      // Create a semaphore that can satisfy up to three
      // concurrent requests. Use an initial count of zero,
      // so that the entire semaphore count is initially
      // owned by the main program thread.
      //
      _pool = gcnew Semaphore( 0,3 );
      
      // Create and start five numbered threads.
      //
      for ( int i = 1; i <= 5; i++ )
      {
         Thread^ t = gcnew Thread(
            gcnew ParameterizedThreadStart( Worker ) );
         
         // Start the thread, passing the number.
         //
         t->Start( i );
      }
      
      // Wait for half a second, to allow all the
      // threads to start and to block on the semaphore.
      //
      Thread::Sleep( 500 );
      
      // The main thread starts out holding the entire
      // semaphore count. Calling Release(3) brings the
      // semaphore count back to its maximum value, and
      // allows the waiting threads to enter the semaphore,
      // up to three at a time.
      //
      Console::WriteLine( L"Main thread calls Release(3)." );
      _pool->Release( 3 );

      Console::WriteLine( L"Main thread exits." );
   }

private:
   static void Worker( Object^ num )
   {
      // Each worker thread begins by requesting the
      // semaphore.
      Console::WriteLine( L"Thread {0} begins and waits for the semaphore.", num );
      _pool->WaitOne();
      
      // A padding interval to make the output more orderly.
      int padding = Interlocked::Add( _padding, 100 );

      Console::WriteLine( L"Thread {0} enters the semaphore.", num );
      
      // The thread's "work" consists of sleeping for
      // about a second. Each thread "works" a little
      // longer, just to make the output more orderly.
      //
      Thread::Sleep( 1000 + padding );

      Console::WriteLine( L"Thread {0} releases the semaphore.", num );
      Console::WriteLine( L"Thread {0} previous semaphore count: {1}",
         num, _pool->Release() );
   }
};
//</Snippet1>
