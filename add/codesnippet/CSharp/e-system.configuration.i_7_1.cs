   // MyInstaller is derived from the class 'Installer'.
   MyInstaller() : base()
   {
      AfterUninstall += new InstallEventHandler(AfterUninstallEventHandler);
   }
   private void AfterUninstallEventHandler(object sender, InstallEventArgs e)
   {
      // Add steps to perform any actions before the Uninstall process.
      Console.WriteLine("Code for AfterUninstallEventHandler"); 
   }