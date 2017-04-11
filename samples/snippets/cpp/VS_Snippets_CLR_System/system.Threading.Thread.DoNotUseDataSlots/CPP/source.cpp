
// <Snippet1>
using namespace System;
using namespace System::Threading;

ref class ThreadData
{
private:
   [ThreadStaticAttribute]
   static int threadSpecificData;

public:
   static void ThreadStaticDemo()
   {
      // Store the managed thread id for each thread in the static
      // variable.
      threadSpecificData = Thread::CurrentThread->ManagedThreadId;
      
      // Allow other threads time to execute the same code, to show
      // that the static data is unique to each thread.
      Thread::Sleep( 1000 );

      // Display the static data.
      Console::WriteLine( "Data for managed thread {0}: {1}", 
         Thread::CurrentThread->ManagedThreadId, threadSpecificData );
   }
};

int main()
{
   for ( int i = 0; i < 3; i++ )
   {
      Thread^ newThread = 
          gcnew Thread( gcnew ThreadStart( ThreadData::ThreadStaticDemo )); 
      newThread->Start();
   }
}

/* This code example produces output similar to the following:

Data for managed thread 4: 4
Data for managed thread 5: 5
Data for managed thread 3: 3
 */
// </Snippet1>
