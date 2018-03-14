
//<Snippet1>
using namespace System;
using namespace System::Threading;

// TaskInfo contains data that will be passed to the callback
// method.
public ref class TaskInfo
{
public:
   TaskInfo()
   {
      Handle = nullptr;
      OtherInfo = "default";
   }

   RegisteredWaitHandle^ Handle;
   String^ OtherInfo;
};

ref class Example
{
public:

   // The callback method executes when the registered wait times out,
   // or when the WaitHandle (in this case AutoResetEvent) is signaled.
   // WaitProc unregisters the WaitHandle the first time the event is 
   // signaled.
   static void WaitProc( Object^ state, bool timedOut )
   {
      
      // The state Object must be cast to the correct type, because the
      // signature of the WaitOrTimerCallback delegate specifies type
      // Object.
      TaskInfo^ ti = static_cast<TaskInfo^>(state);
      String^ cause = "TIMED OUT";
      if (  !timedOut )
      {
         cause = "SIGNALED";
         
         // If the callback method executes because the WaitHandle is
         // signaled, stop future execution of the callback method
         // by unregistering the WaitHandle.
         if ( ti->Handle != nullptr )
                  ti->Handle->Unregister( nullptr );
      }

      Console::WriteLine( "WaitProc( {0}) executes on thread {1}; cause = {2}.", ti->OtherInfo, Thread::CurrentThread->GetHashCode(), cause );
   }

};

int main()
{
   
   // The main thread uses AutoResetEvent to signal the
   // registered wait handle, which executes the callback
   // method.
   AutoResetEvent^ ev = gcnew AutoResetEvent( false );
   TaskInfo^ ti = gcnew TaskInfo;
   ti->OtherInfo = "First task";
   
   // The TaskInfo for the task includes the registered wait
   // handle returned by RegisterWaitForSingleObject.  This
   // allows the wait to be terminated when the object has
   // been signaled once (see WaitProc).
   ti->Handle = ThreadPool::RegisterWaitForSingleObject( ev, gcnew WaitOrTimerCallback( Example::WaitProc ), ti, 1000, false );
   
   // The main thread waits three seconds, to demonstrate the
   // time-outs on the queued thread, and then signals.
   Thread::Sleep( 3100 );
   Console::WriteLine( "Main thread signals." );
   ev->Set();
   
   // The main thread sleeps, which should give the callback
   // method time to execute.  If you comment out this line, the
   // program usually ends before the ThreadPool thread can execute.
   Thread::Sleep( 1000 );
   
   // If you start a thread yourself, you can wait for it to end
   // by calling Thread::Join.  This option is not available with 
   // thread pool threads.
   return 0;
}

//</Snippet1>
