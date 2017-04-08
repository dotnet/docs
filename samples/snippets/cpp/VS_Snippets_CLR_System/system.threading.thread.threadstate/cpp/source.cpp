
// <Snippet1>
using namespace System;
using namespace System::Threading;

// ref class ApartmentTest
// {
// public:
   static void ThreadMethod()
   {
      Thread::Sleep( 1000 );
//    }

};

int main()
{
//    Thread^ newThread = gcnew Thread( gcnew ThreadStart( &ApartmentTest::ThreadMethod ) );
   Thread^ newThread = gcnew Thread( gcnew ThreadStart( &ThreadMethod ) );

   Console::WriteLine("ThreadState: {0}", newThread->ThreadState);
   newThread->Start();
   
   // Wait for newThread to start and go to sleep.
   Thread::Sleep(300);
   Console::WriteLine("ThreadState: {0}", newThread->ThreadState);

   // Wait for newThread to restart.
   Thread::Sleep(1000);
   Console::WriteLine("ThreadState: {0}", newThread->ThreadState);
}
// The example displays the following output:
//       ThreadState: Unstarted
//       ThreadState: WaitSleepJoin
//       ThreadState: Stopped
// </Snippet1>
