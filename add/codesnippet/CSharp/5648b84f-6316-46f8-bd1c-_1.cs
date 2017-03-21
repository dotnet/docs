   // Override the 'OnCommitted' method.
   protected override void OnCommitted(IDictionary savedState)
   {
      base.OnCommitted(savedState);
      // Add steps to be done after committing an application.
      Console.WriteLine("The OnCommitted method of MyInstaller called");
   }