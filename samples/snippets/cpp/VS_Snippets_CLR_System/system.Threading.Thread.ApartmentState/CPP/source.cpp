
// <Snippet1>
using namespace System;
using namespace System::Threading;
ref class ApartmentTest
{
public:
   static void ThreadMethod()
   {
      Thread::Sleep( 1000 );
   }

};

int main()
{
   Thread^ newThread = gcnew Thread( gcnew ThreadStart( &ApartmentTest::ThreadMethod ) );
   newThread->SetApartmentState(ApartmentState::MTA);
   
   Console::WriteLine( "ThreadState: {0}, ApartmentState: {1}", newThread->ThreadState.ToString(), newThread->GetApartmentState().ToString() );
   newThread->Start();
   
   // Wait for newThread to start and go to sleep.
   Thread::Sleep( 300 );
   try
   {
      
      // This causes an exception since newThread is sleeping.
      newThread->SetApartmentState(ApartmentState::STA);
   }
   catch ( ThreadStateException^ stateException ) 
   {
      Console::WriteLine( "\n{0} caught:\n"
      "Thread is not in the Unstarted or Running state.", stateException->GetType()->Name );
      Console::WriteLine( "ThreadState: {0}, ApartmentState: {1}", newThread->ThreadState.ToString(), newThread->GetApartmentState().ToString() );
   }

}

// </Snippet1>
