   TransactedInstaller^ myTransactedInstaller = gcnew TransactedInstaller;
   AssemblyInstaller^ myAssemblyInstaller;
   InstallContext^ myInstallContext;
   
   // Create an instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
   myAssemblyInstaller =
      gcnew AssemblyInstaller( "MyAssembly1.exe",nullptr );
   
   // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
   myTransactedInstaller->Installers->Add( myAssemblyInstaller );
   
   // Create an instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
   myAssemblyInstaller =
      gcnew AssemblyInstaller( "MyAssembly2.exe",nullptr );
   
   // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
   myTransactedInstaller->Installers->Add( myAssemblyInstaller );

   array<Installer^>^ myInstallers =
      gcnew array<Installer^>(myTransactedInstaller->Installers->Count);

   myTransactedInstaller->Installers->CopyTo( myInstallers, 0 );
   // Print the assemblies to be installed.
   Console::WriteLine( "Printing all assemblies to be installed -" );
   for ( int i = 0; i < myInstallers->Length; i++ )
   {
      if ( dynamic_cast<AssemblyInstaller^>( myInstallers[ i ] ) )
      {
         Console::WriteLine( "{0} {1}", i + 1, ( (AssemblyInstaller^)( myInstallers[ i ]) )->Path );
      }
   }