   ' Override the 'OnBeforeInstall' method.
   Protected Overrides Sub OnBeforeInstall(savedState As IDictionary)
      MyBase.OnBeforeInstall(savedState)
      ' Add steps to be done before the installation starts.
      Console.WriteLine("OnBeforeInstall method of MyInstaller called")
   End Sub 'OnBeforeInstall