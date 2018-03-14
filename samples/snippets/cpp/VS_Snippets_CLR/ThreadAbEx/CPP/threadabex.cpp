
//<Snippet1>
using namespace System;
using namespace System::Threading;
using namespace System::Security::Permissions;
ref class ThreadWork
{
public:
   static void DoWork()
   {
      try
      {
         for ( int i = 0; i < 100; i++ )
         {
            Console::WriteLine( "Thread - working." );
            Thread::Sleep( 100 );

         }
      }
      catch ( ThreadAbortException^ e ) 
      {
         Console::WriteLine( "Thread - caught ThreadAbortException - resetting." );
         Console::WriteLine( "Exception message: {0}", e->Message );
         Thread::ResetAbort();
      }

      Console::WriteLine( "Thread - still alive and working." );
      Thread::Sleep( 1000 );
      Console::WriteLine( "Thread - finished working." );
   }

};

int main()
{
   ThreadStart^ myThreadDelegate = gcnew ThreadStart( ThreadWork::DoWork );
   Thread^ myThread = gcnew Thread( myThreadDelegate );
   myThread->Start();
   Thread::Sleep( 100 );
   Console::WriteLine( "Main - aborting my thread." );
   myThread->Abort();
   myThread->Join();
   Console::WriteLine( "Main ending." );
}

//</Snippet1>
