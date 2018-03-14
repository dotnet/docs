// System::Diagnostics::ProcessModule::EntryPointAddress

/* The following program demonstrates the use of 'EntryPointAddress' property of 
'ProcessModule' class. It creates a notepad, gets the 'MainModule' and 
all other modules of the process 'notepad.exe', displays 'EntryPointAddress'
for all the modules and the main module.
*/

#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
void main()
{
   try
   {
      // <Snippet1>
      Process^ myProcess = gcnew Process;

      // Get the process start information of notepad.
      ProcessStartInfo^ myProcessStartInfo = gcnew ProcessStartInfo( "notepad.exe" );

      // Assign 'StartInfo' of notepad to 'StartInfo' of 'myProcess' object.
      myProcess->StartInfo = myProcessStartInfo;

      // Create a notepad.
      myProcess->Start();
      System::Threading::Thread::Sleep( 1000 );
      ProcessModule^ myProcessModule;

      // Get all the modules associated with 'myProcess'.
      ProcessModuleCollection^ myProcessModuleCollection = myProcess->Modules;
      Console::WriteLine( "Entry point addresses of the modules associated with 'notepad' are:" );

      // Display the 'EntryPointAddress' of each of the modules.
      for ( int i = 0; i < myProcessModuleCollection->Count; i++ )
      {
         myProcessModule = myProcessModuleCollection[ i ];
         Console::WriteLine( "{0} : {1}", myProcessModule->ModuleName, myProcessModule->EntryPointAddress );
      }
      myProcessModule = myProcess->MainModule;
      Console::WriteLine( "The process's main module's EntryPointAddress is: {0}", myProcessModule->EntryPointAddress );
      myProcess->CloseMainWindow();
      // </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
   }
}
