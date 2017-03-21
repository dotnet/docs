      TransactedInstaller myTransactedInstaller = new TransactedInstaller();
      AssemblyInstaller myAssemblyInstaller;
      InstallContext myInstallContext;

      // Create an instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
      myAssemblyInstaller =
         new AssemblyInstaller("MyAssembly1.exe", null);

      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller.Installers.Add(myAssemblyInstaller);

      // Create an instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
      myAssemblyInstaller =
         new AssemblyInstaller("MyAssembly2.exe", null);

      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller.Installers.Add(myAssemblyInstaller);
     
      Installer[] myInstallers =
         new Installer[myTransactedInstaller.Installers.Count];

      myTransactedInstaller.Installers.CopyTo(myInstallers, 0);
      // Print the assemblies to be installed.
      Console.WriteLine("Printing all assemblies to be installed -");
      for(int i = 0; i < myInstallers.Length; i++)
      {
         if((myInstallers[i].GetType()).Equals(typeof(AssemblyInstaller)))
         {
            Console.WriteLine("{0} {1}", i + 1,
               ((AssemblyInstaller)myInstallers[i]).Path);
         }
      }