   public MyInstallerClass() :base()
   {
      // Attach the 'Committing' event.
      this.Committing += new InstallEventHandler(MyInstaller_Committing);
   }
   // Event handler for 'Committing' event.
   private void MyInstaller_Committing(object sender, InstallEventArgs e)
   {
      Console.WriteLine("Committing Event occured.");
   }