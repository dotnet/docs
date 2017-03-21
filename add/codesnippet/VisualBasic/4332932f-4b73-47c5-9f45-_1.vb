   ' Override the 'OnCommitting' method.
   Protected Overrides Sub OnCommitting(savedState As IDictionary)
      MyBase.OnCommitting(savedState)
      ' Add steps to be done before committing an application.
      Console.WriteLine("The OnCommitting method of MyInstaller called")
   End Sub 'OnCommitting
   