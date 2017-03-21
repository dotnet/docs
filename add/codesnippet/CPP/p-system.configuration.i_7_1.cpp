   AssemblyInstaller^ myAssemblyInstaller1 = gcnew AssemblyInstaller;
   InstallerCollection^ myInstallerCollection1 = myAssemblyInstaller1->Installers;
   // 'myAssemblyInstaller' is an installer of type 'AssemblyInstaller'.
   myInstallerCollection1->Add( myAssemblyInstaller );

   Installer^ myInstaller1 = myAssemblyInstaller->Parent;
   Console::WriteLine( "Parent of myAssembly : {0}", myInstaller1 );