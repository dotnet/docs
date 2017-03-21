#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::Threading;
int main()
{
   try
   {
      Process^ myProcess;
      myProcess = Process::Start(  "Notepad.exe" );
      
      // Display physical memory usage 5 times at intervals of 2 seconds.
      for ( int i = 0; i < 5; i++ )
      {
         if (  !myProcess->HasExited )
         {
            
            // Discard cached information about the process.
            myProcess->Refresh();
            
            // Print working set to console.
            Console::WriteLine( "Physical Memory Usage : {0}", myProcess->WorkingSet.ToString() );
            
            // Wait 2 seconds.
            Thread::Sleep( 2000 );
         }
         else
         {
            break;
         }

      }
      myProcess->CloseMainWindow();
      
      // Free resources associated with process.
      myProcess->Close();
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The following exception was raised: " );
      Console::WriteLine( e->Message );
   }

}
