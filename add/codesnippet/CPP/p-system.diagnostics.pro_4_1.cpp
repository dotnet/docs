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