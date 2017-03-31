
//<snippet1>
using namespace System;
using namespace System::Threading;

const int numThreads = 10;
const int numThreadIterations = 5;
ref class MyInterlockedExchangeExampleClass
{
public:
   static void MyThreadProc()
   {
      for ( int i = 0; i < numThreadIterations; i++ )
      {
         UseResource();
         
         //Wait 1 second before next attempt.
         Thread::Sleep( 1000 );

      }
   }


private:
   //A simple method that denies reentrancy.
   static bool UseResource()
   {
      
      //0 indicates that the method is not in use.
      if ( 0 == Interlocked::Exchange( usingResource, 1 ) )
      {
         Console::WriteLine( " {0} acquired the lock", Thread::CurrentThread->Name );
         
         //Code to access a resource that is not thread safe would go here.
         //Simulate some work
         Thread::Sleep( 500 );
         Console::WriteLine( " {0} exiting lock", Thread::CurrentThread->Name );
         
         //Release the lock
         Interlocked::Exchange( usingResource, 0 );
         return true;
      }
      else
      {
         Console::WriteLine( " {0} was denied the lock", Thread::CurrentThread->Name );
         return false;
      }
   }


   //0 for false, 1 for true.
   static int usingResource;
};

int main()
{
   Thread^ myThread;
   Random^ rnd = gcnew Random;
   for ( int i = 0; i < numThreads; i++ )
   {
      myThread = gcnew Thread( gcnew ThreadStart( MyInterlockedExchangeExampleClass::MyThreadProc ) );
      myThread->Name = String::Format( "Thread {0}", i + 1 );
      
      //Wait a random amount of time before starting next thread.
      Thread::Sleep( rnd->Next( 0, 1000 ) );
      myThread->Start();

   }
}

//</snippet1>
