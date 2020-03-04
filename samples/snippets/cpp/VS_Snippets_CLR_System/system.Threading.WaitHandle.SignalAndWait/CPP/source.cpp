//<Snippet1>
using namespace System;
using namespace System::Threading;

public ref class Example
{
private:
   // The EventWaitHandle used to demonstrate the difference
   // between AutoReset and ManualReset synchronization events.
   //
   static EventWaitHandle^ ewh;

   // A counter to make sure all threads are started and
   // blocked before any are released. A Long is used to show
   // the use of the 64-bit Interlocked methods.
   //
   static __int64 threadCount = 0;

   // An AutoReset event that allows the main thread to block
   // until an exiting thread has decremented the count.
   //
   static EventWaitHandle^ clearCount =
      gcnew EventWaitHandle( false,EventResetMode::AutoReset );

public:
   [MTAThread]
   static void main()
   {
      // Create an AutoReset EventWaitHandle.
      //
      ewh = gcnew EventWaitHandle( false,EventResetMode::AutoReset );
      
      // Create and start five numbered threads. Use the
      // ParameterizedThreadStart delegate, so the thread
      // number can be passed as an argument to the Start
      // method.
      for ( int i = 0; i <= 4; i++ )
      {
         Thread^ t = gcnew Thread(
            gcnew ParameterizedThreadStart( ThreadProc ) );
         t->Start( i );
      }
      
      // Wait until all the threads have started and blocked.
      // When multiple threads use a 64-bit value on a 32-bit
      // system, you must access the value through the
      // Interlocked class to guarantee thread safety.
      //
      while ( Interlocked::Read( threadCount ) < 5 )
      {
         Thread::Sleep( 500 );
      }

      // Release one thread each time the user presses ENTER,
      // until all threads have been released.
      //
      while ( Interlocked::Read( threadCount ) > 0 )
      {
         Console::WriteLine( L"Press ENTER to release a waiting thread." );
         Console::ReadLine();
         
         // SignalAndWait signals the EventWaitHandle, which
         // releases exactly one thread before resetting,
         // because it was created with AutoReset mode.
         // SignalAndWait then blocks on clearCount, to
         // allow the signaled thread to decrement the count
         // before looping again.
         //
         WaitHandle::SignalAndWait( ewh, clearCount );
      }
      Console::WriteLine();
      
      // Create a ManualReset EventWaitHandle.
      //
      ewh = gcnew EventWaitHandle( false,EventResetMode::ManualReset );
      
      // Create and start five more numbered threads.
      //
      for ( int i = 0; i <= 4; i++ )
      {
         Thread^ t = gcnew Thread(
            gcnew ParameterizedThreadStart( ThreadProc ) );
         t->Start( i );
      }
      
      // Wait until all the threads have started and blocked.
      //
      while ( Interlocked::Read( threadCount ) < 5 )
      {
         Thread::Sleep( 500 );
      }

      // Because the EventWaitHandle was created with
      // ManualReset mode, signaling it releases all the
      // waiting threads.
      //
      Console::WriteLine( L"Press ENTER to release the waiting threads." );
      Console::ReadLine();
      ewh->Set();

   }

   static void ThreadProc( Object^ data )
   {
      int index = static_cast<Int32>(data);

      Console::WriteLine( L"Thread {0} blocks.", data );
      // Increment the count of blocked threads.
      Interlocked::Increment( threadCount );
      
      // Wait on the EventWaitHandle.
      ewh->WaitOne();

      Console::WriteLine( L"Thread {0} exits.", data );
      // Decrement the count of blocked threads.
      Interlocked::Decrement( threadCount );
      
      // After signaling ewh, the main thread blocks on
      // clearCount until the signaled thread has
      // decremented the count. Signal it now.
      //
      clearCount->Set();
   }
};
//</Snippet1>
