
// <Snippet1>
using namespace System;
using namespace System::Threading;
ref class Test
{
private:
   Test(){}


public:
   static void TestMethod()
   {
      try
      {
         while ( true )
         {
            Console::WriteLine( "New thread running." );
            Thread::Sleep( 1000 );
         }
      }
      catch ( ThreadAbortException^ abortException ) 
      {
         Console::WriteLine( dynamic_cast<String^>(abortException->ExceptionState) );
      }

   }

};

int main()
{
   Thread^ newThread = gcnew Thread( gcnew ThreadStart( &Test::TestMethod ) );
   newThread->Start();
   Thread::Sleep( 1000 );
   
   // Abort newThread.
   Console::WriteLine( "Main aborting new thread." );
   newThread->Abort( "Information from main." );
   
   // Wait for the thread to terminate.
   newThread->Join();
   Console::WriteLine( "New thread terminated - main exiting." );
}

// </Snippet1>
