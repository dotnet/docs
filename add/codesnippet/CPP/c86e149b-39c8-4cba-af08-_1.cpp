      TransactedInstaller^ myTransactedInstaller = gcnew TransactedInstaller;
      AssemblyInstaller^ myAssemblyInstaller1;
      AssemblyInstaller^ myAssemblyInstaller2;
      InstallContext^ myInstallContext;
      
      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
      myAssemblyInstaller1 = gcnew AssemblyInstaller( "MyAssembly1.exe",nullptr );
      
      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller->Installers->Insert( 0, myAssemblyInstaller1 );
      
      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
      myAssemblyInstaller2 = gcnew AssemblyInstaller( "MyAssembly2.exe",nullptr );
      
      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller->Installers->Insert( 1, myAssemblyInstaller2 );
      
      // Remove the 'myAssemblyInstaller2' from the 'Installers' collection.
      if ( myTransactedInstaller->Installers->Contains( myAssemblyInstaller2 ) )
      {
         Console::WriteLine( "\nInstaller at index : {0} is being removed", myTransactedInstaller->Installers->IndexOf( myAssemblyInstaller2 ) );
         myTransactedInstaller->Installers->Remove( myAssemblyInstaller2 );
      }