   public MyInstallerClass() :base()
   {
      // Attach the 'Committed' event.
      this.Committed += new InstallEventHandler(MyInstaller_Committed);
   }

   // Event handler for 'Committed' event.
   private void MyInstaller_Committed(object sender, InstallEventArgs e)
   {
      Console.WriteLine("Committed Event occured.");
   }