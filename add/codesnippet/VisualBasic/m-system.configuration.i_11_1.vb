   Public Overrides Sub Uninstall(savedState As IDictionary)
      MyBase.Uninstall(savedState)
      Console.WriteLine("UnInstall ...")
      ' Throw an error if a particular file doesn't exist.
      If Not File.Exists("FileDoesNotExist.txt") Then
         Throw New InstallException("The file 'FileDoesNotExist'" + " does not exist")
      End If
      ' Perform the uninstall activites if the file exists.
   End Sub