      ' Override the 'Commit' method of the Installer class.
      Public Overrides Sub Commit(mySavedState As IDictionary)
         MyBase.Commit(mySavedState)
         Console.WriteLine("The Commit method of 'MyInstallerSample'" + _
                                                      "has been called")
      End Sub 'Commit