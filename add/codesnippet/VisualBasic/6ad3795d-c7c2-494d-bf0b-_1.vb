      ' Override 'Uninstall' method of Installer class.
      Public Overrides Sub Uninstall(mySavedState As IDictionary)
         If mySavedState Is Nothing Then
            Console.WriteLine("Uninstallation Error !")
         Else
            MyBase.Uninstall(mySavedState)
            Console.WriteLine("The Uninstall method of 'MyInstallerSample' has been called")
         End If
      End Sub 'Uninstall