//<Snippet1>
#using <System.dll>
using namespace System;
using namespace System::Threading;

public ref class Example
{
private:
   // A semaphore that can satisfy at most two concurrent
   // requests.
   //
   static Semaphore^ _pool = gcnew Semaphore( 2,2 );

public:
   static void main()
   {
      // Create and start two threads, A and B.
      //
      Thread^ tA = gcnew Thread( gcnew ThreadStart( ThreadA ) );
      tA->Start();

      Thread^ tB = gcnew Thread( gcnew ThreadStart( ThreadB ) );
      tB->Start();
   }

private:
   static void ThreadA()
   {
      // Thread A enters the semaphore and simulates a task
      // that lasts a second.
      //
      _pool->WaitOne();
      Console::WriteLine( L"Thread A entered the semaphore." );

      Thread::Sleep( 1000 );

      try
      {
         _pool->Release();
         Console::WriteLine( L"Thread A released the semaphore." );
      }
      catch ( Exception^ ex ) 
      {
         Console::WriteLine( L"Thread A: {0}", ex->Message );
      }
   }

   static void ThreadB()
   {
      // Thread B simulates a task that lasts half a second,
      // then enters the semaphore.
      //
      Thread::Sleep( 500 );

      _pool->WaitOne();
      Console::WriteLine( L"Thread B entered the semaphore." );
      
      // Due to a programming error, Thread B releases the
      // semaphore twice. To fix the program, delete one line.
      _pool->Release();
      _pool->Release();
      Console::WriteLine( L"Thread B exits successfully." );
   }
};
/* This code example produces the following output:

Thread A entered the semaphore.
Thread B entered the semaphore.
Thread B exits successfully.
Thread A: Adding the given count to the semaphore would cause it to exceed its maximum count.
 */
//</Snippet1>
