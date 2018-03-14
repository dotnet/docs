
// <Snippet1>
using namespace System;
using namespace System::Threading;
ref class Test
{
private:
   Test(){}


public:
   static void ThreadMethod()
   {
      Console::WriteLine( "Thread {0} started in {1} with AppDomainID = {2}.", AppDomain::GetCurrentThreadId().ToString(), Thread::GetDomain()->FriendlyName, Thread::GetDomainID().ToString() );
   }

};

int main()
{
   Thread^ newThread = gcnew Thread( gcnew ThreadStart( &Test::ThreadMethod ) );
   newThread->Start();
}

// </Snippet1>
