      ' Override 'Rollback' method of Installer class.
      Public Overrides Sub Rollback(mySavedState As IDictionary)
         MyBase.Rollback(mySavedState)
         Console.WriteLine("The Rollback method of 'MyInstallerSample'" + _
                                                      " has been called")
      End Sub 'Rollback