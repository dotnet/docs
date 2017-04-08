
// <Snippet1>
// [C++]
// Compile using /clr option.
using namespace System;
using namespace System::Threading;

// Simple threading scenario:  Start a Shared method running
// on a second thread.
public ref class ThreadExample
{
public:

   // The ThreadProc method is called when the thread starts.
   // It loops ten times, writing to the console and yielding 
   // the rest of its time slice each time, and then ends.
   static void ThreadProc()
   {
      for ( int i = 0; i < 10; i++ )
      {
         Console::Write(  "ThreadProc: " );
         Console::WriteLine( i );
         
         // Yield the rest of the time slice.
         Thread::Sleep( 0 );

      }
   }

};

int main()
{
   Console::WriteLine( "Main thread: Start a second thread." );
   
   // Create the thread, passing a ThreadStart delegate that
   // represents the ThreadExample::ThreadProc method.  For a 
   // delegate representing a static method, no object is
   // required.
   Thread^ oThread = gcnew Thread( gcnew ThreadStart( &ThreadExample::ThreadProc ) );
   
   // Start ThreadProc.  Note that on a uniprocessor, the new 
   // thread does not get any processor time until the main thread 
   // is preempted or yields.  Uncomment the Thread::Sleep that 
   // follows oThread->Start() to see the difference.
   oThread->Start();
   
   //Thread::Sleep(0);
   for ( int i = 0; i < 4; i++ )
   {
      Console::WriteLine(  "Main thread: Do some work." );
      Thread::Sleep( 0 );

   }
   Console::WriteLine(  "Main thread: Call Join(), to wait until ThreadProc ends." );
   oThread->Join();
   Console::WriteLine(  "Main thread: ThreadProc.Join has returned.  Press Enter to end program." );
   Console::ReadLine();
   return 0;
}

// </Snippet1>
