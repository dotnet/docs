// System::Diagnostics::ProcessModule
/* The following program demonstrates the use of 'ProcessModule' class. 
It creates a notepad, gets the 'MainModule' and all other modules of 
the process 'notepad.exe', displays some of the properties of each modules.
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

      // Assign 'StartInfo' of notepad to 'StartInfo' of 'myProcess' Object*.
      myProcess->StartInfo = myProcessStartInfo;

      // Create a notepad.
      myProcess->Start();
      System::Threading::Thread::Sleep( 1000 );
      ProcessModule^ myProcessModule;

      // Get all the modules associated with 'myProcess'.
      ProcessModuleCollection^ myProcessModuleCollection = myProcess->Modules;
      Console::WriteLine( "Properties of the modules  associated with 'notepad' are:" );

      // Display the properties of each of the modules.
      for ( int i = 0; i < myProcessModuleCollection->Count; i++ )
      {
         myProcessModule = myProcessModuleCollection[ i ];
         Console::WriteLine( "The moduleName is {0}", myProcessModule->ModuleName );
         Console::WriteLine( "The {0}'s base address is: {1}", myProcessModule->ModuleName, myProcessModule->BaseAddress );
         Console::WriteLine( "The {0}'s Entry point address is: {1}", myProcessModule->ModuleName, myProcessModule->EntryPointAddress );
         Console::WriteLine( "The {0}'s File name is: {1}", myProcessModule->ModuleName, myProcessModule->FileName );
      }
      myProcessModule = myProcess->MainModule;
      
      // Display the properties of the main module.
      Console::WriteLine( "The process's main moduleName is: {0}", myProcessModule->ModuleName );
      Console::WriteLine( "The process's main module's base address is: {0}", myProcessModule->BaseAddress );
      Console::WriteLine( "The process's main module's Entry point address is: {0}", myProcessModule->EntryPointAddress );
      Console::WriteLine( "The process's main module's File name is: {0}", myProcessModule->FileName );
      myProcess->CloseMainWindow();
      // </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
   }
}
