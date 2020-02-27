// System::Diagnostics::ProcessModule::FileName

/* The following program demonstrates the use of 'FileName' property of 
'ProcessModule' class. It creates a notepad, gets the 'MainModule' and 
all other modules of the process 'notepad.exe', displays 'FileName'
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
      Console::WriteLine( "File names of the modules associated with 'notepad' are:" );

      // Display the 'FileName' of each of the modules.
      for ( int i = 0; i < myProcessModuleCollection->Count; i++ )
      {
         myProcessModule = myProcessModuleCollection[ i ];
         Console::WriteLine( "{0:s} : {1:s}", myProcessModule->ModuleName,  myProcessModule->FileName );
      }
      myProcessModule = myProcess->MainModule;

      // Display the 'FileName' of the main module.
      Console::WriteLine( "The process's main module's FileName is: {0}", myProcessModule->FileName );
      myProcess->CloseMainWindow();
      // </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
   }
}
