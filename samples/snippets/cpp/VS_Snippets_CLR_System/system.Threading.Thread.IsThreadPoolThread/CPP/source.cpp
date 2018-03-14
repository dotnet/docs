
// <Snippet1>
using namespace System;
using namespace System::Threading;
ref class IsThreadPool
{
public:

   // <Snippet2>
   static void ThreadMethod()
   {
      Console::WriteLine( "ThreadOne, executing ThreadMethod, "
      "is {0}from the thread pool.", Thread::CurrentThread->IsThreadPoolThread ? (String^)"" : "not " );
   }


   // </Snippet2>
   static void WorkMethod( Object^ stateInfo )
   {
      Console::WriteLine( "ThreadTwo, executing WorkMethod, "
      "is {0}from the thread pool.", Thread::CurrentThread->IsThreadPoolThread ? (String^)"" : "not " );
      
      // Signal that this thread is finished.
      dynamic_cast<AutoResetEvent^>(stateInfo)->Set();
   }

};

int main()
{
   AutoResetEvent^ autoEvent = gcnew AutoResetEvent( false );
   Thread^ regularThread = gcnew Thread( gcnew ThreadStart( &IsThreadPool::ThreadMethod ) );
   regularThread->Start();
   ThreadPool::QueueUserWorkItem( gcnew WaitCallback( &IsThreadPool::WorkMethod ), autoEvent );
   
   // Wait for foreground thread to end.
   regularThread->Join();
   
   // Wait for background thread to end.
   autoEvent->WaitOne();
}

// </Snippet1>
