
// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Security::Permissions;
using namespace System::Threading;

ref class ThreadPoolTest
{
private:

   // Maintains state information to be passed to EndWriteCallback.
   // This information allows the callback to end the asynchronous
   // write operation and signal when it is finished.
   ref class State
   {
   public:
      FileStream^ fStream;
      AutoResetEvent^ autoEvent;
      State( FileStream^ fStream, AutoResetEvent^ autoEvent )
      {
         this->fStream = fStream;
         this->autoEvent = autoEvent;
      }

   };


public:
   ThreadPoolTest(){}

   static void EndWriteCallback( IAsyncResult^ asyncResult )
   {
      Console::WriteLine( "Starting EndWriteCallback." );
      State^ stateInfo = dynamic_cast<State^>(asyncResult->AsyncState);
      int workerThreads;
      int portThreads;
      try
      {
         ThreadPool::GetAvailableThreads( workerThreads, portThreads );
         Console::WriteLine( "\nAvailable worker threads: \t{0}"
         "\nAvailable completion port threads: {1}\n", workerThreads.ToString(), portThreads.ToString() );
         stateInfo->fStream->EndWrite( asyncResult );
         
         // Sleep so the other thread has a chance to run
         // before the current thread ends.
         Thread::Sleep( 1500 );
      }
      catch ( Exception^ e ) 
      {
      }
      finally
      {
         
         // Signal that the current thread is finished.
         stateInfo->autoEvent->Set();
         Console::WriteLine( "Ending EndWriteCallback." );
      }

   }

   static void WorkItemMethod( Object^ mainEvent )
   {
      Console::WriteLine( "\nStarting WorkItem.\n" );
      AutoResetEvent^ autoEvent = gcnew AutoResetEvent( false );
      
      // Create some data.
      const int ArraySize = 10000;
      const int BufferSize = 1000;
      array<Byte>^byteArray = gcnew array<Byte>(ArraySize);
      (gcnew Random)->NextBytes( byteArray );
      
      // Create two files and two State objects. 
      FileStream^ fileWriter1 = gcnew FileStream(  "C:\\Test1@##.dat",FileMode::Create,FileAccess::ReadWrite,FileShare::ReadWrite,BufferSize,true );
      FileStream^ fileWriter2 = gcnew FileStream(  "C:\\Test2@##.dat",FileMode::Create,FileAccess::ReadWrite,FileShare::ReadWrite,BufferSize,true );
      State^ stateInfo1 = gcnew State( fileWriter1,autoEvent );
      State^ stateInfo2 = gcnew State( fileWriter2,autoEvent );
      
      // Asynchronously write to the files.
      fileWriter1->BeginWrite( byteArray, 0, byteArray->Length, gcnew AsyncCallback( &ThreadPoolTest::EndWriteCallback ), stateInfo1 );
      fileWriter2->BeginWrite( byteArray, 0, byteArray->Length, gcnew AsyncCallback( &ThreadPoolTest::EndWriteCallback ), stateInfo2 );
      
      // Wait for each callback to finish.
      autoEvent->WaitOne();
      autoEvent->WaitOne();
      fileWriter1->Close();
      fileWriter2->Close();
      Console::WriteLine( "\nEnding WorkItem.\n" );
      
      // Signal Main that the work item is finished.
      dynamic_cast<AutoResetEvent^>(mainEvent)->Set();
   }

};

int main()
{
   AutoResetEvent^ mainEvent = gcnew AutoResetEvent( false );
   int workerThreads;
   int portThreads;
   ThreadPool::GetMaxThreads( workerThreads, portThreads );
   Console::WriteLine( "\nMaximum worker threads: \t{0}"
   "\nMaximum completion port threads: {1}", workerThreads.ToString(), portThreads.ToString() );
   ThreadPool::GetAvailableThreads( workerThreads, portThreads );
   Console::WriteLine( "\nAvailable worker threads: \t{0}"
   "\nAvailable completion port threads: {1}\n", workerThreads.ToString(), portThreads.ToString() );
   ThreadPool::QueueUserWorkItem( gcnew WaitCallback( &ThreadPoolTest::WorkItemMethod ), mainEvent );
   
   // Since ThreadPool threads are background threads, 
   // wait for the work item to signal before ending main().
   mainEvent->WaitOne( 5000, false );
}

// </Snippet1>
