
//<Snippet1>
using namespace System;
using namespace System::Threading;

ref class Example
{
public:

   // This thread procedure performs the task.
   static void ThreadProc(Object^ stateInfo)
   {
      
      // No state object was passed to QueueUserWorkItem, so stateInfo is 0.
      Console::WriteLine( "Hello from the thread pool." );
   }
};

int main()
{
   // Queue the task.
   ThreadPool::QueueUserWorkItem(gcnew WaitCallback(Example::ThreadProc));

   Console::WriteLine("Main thread does some work, then sleeps.");
   
   Thread::Sleep(1000);
   Console::WriteLine("Main thread exits.");
   return 0;
}
// The example displays output like the following:
//       Main thread does some work, then sleeps.
//       Hello from the thread pool.
//       Main thread exits.
//</Snippet1>
