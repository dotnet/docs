   // MyInstaller is derived from the class 'Installer'.
   MyInstaller() : base()
   {
      BeforeUninstall += new InstallEventHandler(BeforeUninstallEventHandler);
   }
   private void BeforeUninstallEventHandler(object sender, InstallEventArgs e)
   {
      // Add steps to perform any actions before the Uninstall process.
      Console.WriteLine("Code for BeforeUninstallEventHandler"); 
   }