
// <Snippet1>
using namespace System;
using namespace System::Threading;
ref class Slot
{
private:
   static Random^ randomGenerator;
   static LocalDataStoreSlot^ localSlot;
   static Slot()
   {
      randomGenerator = gcnew Random;
      localSlot = Thread::AllocateDataSlot();
   }


public:
   static void SlotTest()
   {
      
      // Set different data in each thread's data slot.
      Thread::SetData( localSlot, randomGenerator->Next( 1, 200 ) );
      
      // Write the data from each thread's data slot.
      Console::WriteLine( "Data in thread_{0}'s data slot: {1,3}", AppDomain::GetCurrentThreadId().ToString(), Thread::GetData( localSlot )->ToString() );
      
      // Allow other threads time to execute SetData to show
      // that a thread's data slot is unique to the thread.
      Thread::Sleep( 1000 );
      Console::WriteLine( "Data in thread_{0}'s data slot: {1,3}", AppDomain::GetCurrentThreadId().ToString(), Thread::GetData( localSlot )->ToString() );
   }

};

int main()
{
   array<Thread^>^newThreads = gcnew array<Thread^>(4);
   for ( int i = 0; i < newThreads->Length; i++ )
   {
      newThreads[ i ] = gcnew Thread( gcnew ThreadStart( &Slot::SlotTest ) );
      newThreads[ i ]->Start();

   }
}

// </Snippet1>
