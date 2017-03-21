      TransactedInstaller myTransactedInstaller1 = new TransactedInstaller();
      TransactedInstaller myTransactedInstaller2 = new TransactedInstaller();
      AssemblyInstaller myAssemblyInstaller = new AssemblyInstaller();
      InstallContext myInstallContext;

      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
      myAssemblyInstaller = 
         new AssemblyInstaller("MyAssembly1.exe", null);

      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller1.Installers.Insert(0, myAssemblyInstaller);

      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
      myAssemblyInstaller = 
         new AssemblyInstaller("MyAssembly2.exe", null);

      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller1.Installers.Insert(1, myAssemblyInstaller);

      // Copy the installers of 'myTransactedInstaller1' to 'myTransactedInstaller2'.
      myTransactedInstaller2.Installers.AddRange(myTransactedInstaller1.Installers);
