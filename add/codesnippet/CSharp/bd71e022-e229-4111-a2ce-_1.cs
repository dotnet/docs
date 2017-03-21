         ArrayList myInstallers =new ArrayList();
         TransactedInstaller myTransactedInstaller = new TransactedInstaller();
         AssemblyInstaller myAssemblyInstaller;
         InstallContext myInstallContext;

         // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
         myAssemblyInstaller = 
            new AssemblyInstaller("MyAssembly1.exe", null);

         // Add the instance of 'AssemblyInstaller' to the list of installers.  
         myInstallers.Add(myAssemblyInstaller);

         // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
         myAssemblyInstaller = 
            new AssemblyInstaller("MyAssembly2.exe", null);

         // Add the instance of 'AssemblyInstaller' to the list of installers.  
         myInstallers.Add(myAssemblyInstaller);

         // Add the installers to the 'TransactedInstaller' instance.
         myTransactedInstaller.Installers.AddRange((Installer[])myInstallers.ToArray(typeof(Installer)));