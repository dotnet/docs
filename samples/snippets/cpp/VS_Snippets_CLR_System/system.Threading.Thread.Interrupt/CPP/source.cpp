
// <Snippet1>
using namespace System;
using namespace System::Security::Permissions;
using namespace System::Threading;

ref class StayAwake
{
private:
   bool sleepSwitch;

public:

   property bool SleepSwitch 
   {
      void set( bool value )
      {
         sleepSwitch = value;
      }

   }
   StayAwake()
   {
      sleepSwitch = false;
   }

   void ThreadMethod()
   {
      Console::WriteLine( "newThread is executing ThreadMethod." );
      while (  !sleepSwitch )
      {
         
         // Use SpinWait instead of Sleep to demonstrate the 
         // effect of calling Interrupt on a running thread.
         Thread::SpinWait( 10000000 );
      }

      try
      {
         Console::WriteLine( "newThread going to sleep." );
         
         // When newThread goes to sleep, it is immediately 
         // woken up by a ThreadInterruptedException.
         Thread::Sleep( Timeout::Infinite );
      }
      catch ( ThreadInterruptedException^ /*e*/ ) 
      {
         Console::WriteLine( "newThread cannot go to sleep - "
         "interrupted by main thread." );
      }

   }

};

int main()
{
   StayAwake^ stayAwake = gcnew StayAwake;
   Thread^ newThread = gcnew Thread( gcnew ThreadStart( stayAwake, &StayAwake::ThreadMethod ) );
   newThread->Start();
   
   // The following line causes an exception to be thrown 
   // in ThreadMethod if newThread is currently blocked
   // or becomes blocked in the future.
   newThread->Interrupt();
   Console::WriteLine( "Main thread calls Interrupt on newThread." );
   
   // Then tell newThread to go to sleep.
   stayAwake->SleepSwitch = true;
   
   // Wait for newThread to end.
   newThread->Join();
}

// </Snippet1>
