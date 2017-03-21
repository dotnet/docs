      AssemblyInstaller myAssemblyInstaller = new AssemblyInstaller();
      ServiceInstaller myServiceInstaller = new ServiceInstaller();
      EventLogInstaller myEventLogInstaller = new EventLogInstaller();
      
      InstallerCollection myInstallerCollection = myAssemblyInstaller.Installers;
      
      // Add Installers to the InstallerCollection of 'myAssemblyInstaller'.
      myInstallerCollection.Add(myServiceInstaller);
      myInstallerCollection.Add(myEventLogInstaller);

      Installer[] myInstaller = new Installer[2];
      myInstallerCollection.CopyTo(myInstaller,0);
      // Show the contents of the InstallerCollection of 'myAssemblyInstaller'.
      Console.WriteLine("Installers in the InstallerCollection : ");
      for (int iIndex=0; iIndex < myInstaller.Length; iIndex++)
         Console.WriteLine(myInstaller[iIndex].ToString());