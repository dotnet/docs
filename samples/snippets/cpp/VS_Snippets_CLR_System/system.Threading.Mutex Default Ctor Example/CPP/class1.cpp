
//<Snippet1>
// This example shows how a Mutex is used to synchronize access
// to a protected resource. Unlike Monitor, Mutex can be used with
// WaitHandle.WaitAll and WaitAny, and can be passed across
// AppDomain boundaries.
using namespace System;
using namespace System::Threading;
const int numIterations = 1;
const int numThreads = 3;
ref class Test
{
public:

   // Create a new Mutex. The creating thread does not own the
   // Mutex.
   static Mutex^ mut = gcnew Mutex;
   static void MyThreadProc()
   {
      for ( int i = 0; i < numIterations; i++ )
      {
         UseResource();

      }
   }


private:

   // This method represents a resource that must be synchronized
   // so that only one thread at a time can enter.
   static void UseResource()
   {
      
      //Wait until it is OK to enter.
      mut->WaitOne();
      Console::WriteLine( "{0} has entered protected the area", Thread::CurrentThread->Name );
      
      // Place code to access non-reentrant resources here.
      // Simulate some work.
      Thread::Sleep( 500 );
      Console::WriteLine( "{0} is leaving protected the area\r\n", Thread::CurrentThread->Name );
      
      // Release the Mutex.
      mut->ReleaseMutex();
   }

};

int main()
{
   
   // Create the threads that will use the protected resource.
   for ( int i = 0; i < numThreads; i++ )
   {
      Thread^ myThread = gcnew Thread( gcnew ThreadStart( Test::MyThreadProc ) );
      myThread->Name = String::Format( "Thread {0}", i + 1 );
      myThread->Start();

   }
   
   // The main thread exits, but the application continues to 
   // run until all foreground threads have exited.
}

//</Snippet1>
