
// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Security::Permissions;
using namespace System::Threading;

// Maintain state to pass to WriteToFile.
ref class State
{
public:
   String^ fileName;
   array<Byte>^byteArray;
   ManualResetEvent^ manualEvent;
   State( String^ fileName, array<Byte>^byteArray, ManualResetEvent^ manualEvent )
      : fileName( fileName ), byteArray( byteArray ), manualEvent( manualEvent )
   {}

};

ref class Writer
{
private:
   static int workItemCount = 0;
   Writer(){}


public:
   static void WriteToFile( Object^ state )
   {
      int workItemNumber = workItemCount;
      Interlocked::Increment( workItemCount );
      Console::WriteLine( "Starting work item {0}.", workItemNumber.ToString() );
      State^ stateInfo = dynamic_cast<State^>(state);
      FileStream^ fileWriter;
      
      // Create and write to the file.
      try
      {
         fileWriter = gcnew FileStream( stateInfo->fileName,FileMode::Create );
         fileWriter->Write( stateInfo->byteArray, 0, stateInfo->byteArray->Length );
      }
      finally
      {
         if ( fileWriter != nullptr )
         {
            fileWriter->Close();
         }
         
         // Signal main() that the work item has finished.
         Console::WriteLine( "Ending work item {0}.", workItemNumber.ToString() );
         stateInfo->manualEvent->Set();
      }

   }

};

int main()
{
   const int numberOfFiles = 5;
   String^ dirName =  "C:\\TestTest";
   String^ fileName;
   array<Byte>^byteArray;
   Random^ randomGenerator = gcnew Random;
   array<ManualResetEvent^>^manualEvents = gcnew array<ManualResetEvent^>(numberOfFiles);
   State^ stateInfo;
   if (  !Directory::Exists( dirName ) )
   {
      Directory::CreateDirectory( dirName );
   }

   
   // Queue the work items that create and write to the files.
   for ( int i = 0; i < numberOfFiles; i++ )
   {
      fileName = String::Concat( dirName,  "\\Test", ((i)).ToString(),  ".dat" );
      
      // Create random data to write to the file.
      byteArray = gcnew array<Byte>(1000000);
      randomGenerator->NextBytes( byteArray );
      manualEvents[ i ] = gcnew ManualResetEvent( false );
      stateInfo = gcnew State( fileName,byteArray,manualEvents[ i ] );
      ThreadPool::QueueUserWorkItem( gcnew WaitCallback( &Writer::WriteToFile ), stateInfo );

   }
   
   // Since ThreadPool threads are background threads, 
   // wait for the work items to signal before exiting.
   if ( WaitHandle::WaitAll( manualEvents, 5000, false ) )
   {
      Console::WriteLine( "Files written - main exiting." );
   }
   else
   {
      
      // The wait operation times out.
      Console::WriteLine( "Error writing files - main exiting." );
   }
}

// </Snippet1>
