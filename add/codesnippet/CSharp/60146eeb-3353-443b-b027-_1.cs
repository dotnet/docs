   // Override the 'OnAfterInstall' method.
   protected override void OnAfterInstall(IDictionary savedState)
   {
      base.OnAfterInstall(savedState);
      // Add steps to be done after the installation is over.
      Console.WriteLine("OnAfterInstall method of MyInstaller called");
   }