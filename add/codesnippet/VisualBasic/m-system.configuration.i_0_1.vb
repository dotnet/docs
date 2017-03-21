      ' Override the 'Install' method of the Installer class.
      Public Overrides Sub Install(mySavedState As IDictionary)
         MyBase.Install(mySavedState)
         ' Code maybe written for installation of an application.
         Console.WriteLine("The Install method of 'MyInstallerSample' has been called")
      End Sub 'Install