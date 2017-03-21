   ' Override the 'OnCommitted' method.
   Protected Overrides Sub OnCommitted(savedState As IDictionary)
      MyBase.OnCommitted(savedState)
      ' Add steps to be done after committing an application.
      Console.WriteLine("The OnCommitted method of MyInstaller called")
   End Sub 'OnCommitted