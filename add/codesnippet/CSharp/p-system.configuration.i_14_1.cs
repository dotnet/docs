         TransactedInstaller myTransactedInstaller = new TransactedInstaller();
         AssemblyInstaller myAssemblyInstaller;
         InstallContext myInstallContext;

         // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
         myAssemblyInstaller = 
            new AssemblyInstaller("MyAssembly1.exe", null);

         // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
         myTransactedInstaller.Installers.Add(myAssemblyInstaller);

         // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
         myAssemblyInstaller = 
            new AssemblyInstaller("MyAssembly2.exe", null);

         // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.  
         myTransactedInstaller.Installers.Add(myAssemblyInstaller);

         //Print the assemblies to be installed.
         InstallerCollection myInstallers = myTransactedInstaller.Installers;
         Console.WriteLine("\nPrinting all assemblies to be installed");
         for(int i = 0; i < myInstallers.Count; i++)
         {
            if((myInstallers[i].GetType()).Equals(typeof(AssemblyInstaller)))
            {
               Console.WriteLine("{0} {1}", i + 1, 
                  ((AssemblyInstaller)myInstallers[i]).Path);
            }
         }