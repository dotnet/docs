      TransactedInstaller^ myTransactedInstaller = gcnew TransactedInstaller;
      AssemblyInstaller^ myAssemblyInstaller;
      InstallContext^ myInstallContext;
      
      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
      myAssemblyInstaller = gcnew AssemblyInstaller( "MyAssembly1.exe",nullptr );
      
      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller->Installers->Add( myAssemblyInstaller );
      
      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
      myAssemblyInstaller = gcnew AssemblyInstaller( "MyAssembly2.exe",nullptr );
      
      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller->Installers->Add( myAssemblyInstaller );
      
      //Print the assemblies to be installed.
      InstallerCollection^ myInstallers = myTransactedInstaller->Installers;
      Console::WriteLine( "\nPrinting all assemblies to be installed" );
      for ( int i = 0; i < myInstallers->Count; i++ )
      {
         if ( dynamic_cast<AssemblyInstaller^>(myInstallers[ i ]) )
         {
            Console::WriteLine( "{0} {1}", i + 1, safe_cast<AssemblyInstaller^>(myInstallers[ i ])->Path );
         }
      }