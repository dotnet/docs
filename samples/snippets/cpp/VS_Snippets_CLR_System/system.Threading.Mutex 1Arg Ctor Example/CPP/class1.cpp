
//<Snippet1>
using namespace System;
using namespace System::Threading;

const int numIterations = 1;
const int numThreads = 3;

ref class Test
{
public:

   // Create a new Mutex. The creating thread owns the
   // Mutex.
   static Mutex^ mut = gcnew Mutex( true );
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
   
   // Initialize the Mutex.
   Mutex^ mut = Test::mut;
   
   // Create the threads that will use the protected resource.
   for ( int i = 0; i < numThreads; i++ )
   {
      Thread^ myThread = gcnew Thread( gcnew ThreadStart( Test::MyThreadProc ) );
      myThread->Name = String::Format( "Thread {0}", i + 1 );
      myThread->Start();

   }
   
   // Wait one second before allowing other threads to
   // acquire the Mutex.
   Console::WriteLine( "Creating thread owns the Mutex." );
   Thread::Sleep( 1000 );
   Console::WriteLine( "Creating thread releases the Mutex.\r\n" );
   mut->ReleaseMutex();
}
// The example displays output like the following:
//       Creating thread owns the Mutex.
//       Creating thread releases the Mutex.
//       
//       Thread1 has entered the protected area
//       Thread1 is leaving the protected area
//       
//       Thread2 has entered the protected area
//       Thread2 is leaving the protected area
//       
//       Thread3 has entered the protected area
//       Thread3 is leaving the protected area
//</Snippet1>
