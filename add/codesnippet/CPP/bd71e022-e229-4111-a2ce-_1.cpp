      ArrayList^ myInstallers = gcnew ArrayList;
      TransactedInstaller^ myTransactedInstaller = gcnew TransactedInstaller;
      AssemblyInstaller^ myAssemblyInstaller;
      InstallContext^ myInstallContext;

      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
      myAssemblyInstaller =
         gcnew AssemblyInstaller( "MyAssembly1.exe",nullptr );

      // Add the instance of 'AssemblyInstaller' to the list of installers.
      myInstallers->Add( myAssemblyInstaller );

      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
      myAssemblyInstaller =
         gcnew AssemblyInstaller( "MyAssembly2.exe",nullptr );

      // Add the instance of 'AssemblyInstaller' to the list of installers.
      myInstallers->Add( myAssemblyInstaller );

      // Add the installers to the 'TransactedInstaller' instance.
      myTransactedInstaller->Installers->AddRange( safe_cast<array<Installer^>^>(myInstallers->ToArray( Installer::typeid )) );