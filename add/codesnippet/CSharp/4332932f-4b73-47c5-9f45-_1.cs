   // Override the 'OnCommitting' method.
   protected override void OnCommitting(IDictionary savedState)
   {
      base.OnCommitting(savedState);
      // Add steps to be done before committing an application.
      Console.WriteLine("The OnCommitting method of MyInstaller called");
   }