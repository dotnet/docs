   TransactedInstaller^ myTransactedInstaller1 = gcnew TransactedInstaller;
   TransactedInstaller^ myTransactedInstaller2 = gcnew TransactedInstaller;
   AssemblyInstaller^ myAssemblyInstaller = gcnew AssemblyInstaller;
   InstallContext^ myInstallContext;
   
   // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
   myAssemblyInstaller =
      gcnew AssemblyInstaller( "MyAssembly1.exe",nullptr );
   
   // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
   myTransactedInstaller1->Installers->Insert( 0, myAssemblyInstaller );
   
   // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
   myAssemblyInstaller =
      gcnew AssemblyInstaller( "MyAssembly2.exe",nullptr );
   
   // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
   myTransactedInstaller1->Installers->Insert( 1, myAssemblyInstaller );
   
   // Copy the installers of 'myTransactedInstaller1' to 'myTransactedInstaller2'.
   myTransactedInstaller2->Installers->AddRange( myTransactedInstaller1->Installers );