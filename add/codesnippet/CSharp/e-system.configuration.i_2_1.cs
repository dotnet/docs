   // MyInstaller is derived from the class 'Installer'.
   MyInstaller() : base()
   {
      AfterInstall += new InstallEventHandler(AfterInstallEventHandler);
   }
   private void AfterInstallEventHandler(object sender, InstallEventArgs e)
   {
      // Add steps to perform any actions after the install process.
      Console.WriteLine("Code for AfterInstallEventHandler"); 
   }