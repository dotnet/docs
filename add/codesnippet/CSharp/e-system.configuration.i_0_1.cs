   // MyInstaller is derived from the class 'Installer'.
   MyInstaller() : base()
   {
      BeforeInstall += new InstallEventHandler(BeforeInstallEventHandler);
   }
   private void BeforeInstallEventHandler(object sender, InstallEventArgs e)
   {
      // Add steps to perform any actions before the install process.
      Console.WriteLine("Code for BeforeInstallEventHandler"); 
   }