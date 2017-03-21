   ' Override the 'OnAfterInstall' method.
   Protected Overrides Sub OnAfterInstall(savedState As IDictionary)
      MyBase.OnAfterInstall(savedState)
      ' Add steps to be done after the installation is over.
      Console.WriteLine("OnAfterInstall method of MyInstaller called")
   End Sub 'OnAfterInstall