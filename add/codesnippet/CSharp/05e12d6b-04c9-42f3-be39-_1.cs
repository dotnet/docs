   // Override the 'OnBeforeInstall' method.
   protected override void OnBeforeInstall(IDictionary savedState)
   {
      base.OnBeforeInstall(savedState);
      // Add steps to be done before the installation starts.
      Console.WriteLine("OnBeforeInstall method of MyInstaller called");
   }