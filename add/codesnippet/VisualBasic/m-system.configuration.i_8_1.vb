   Public Overrides Sub Commit(savedState As IDictionary)
      MyBase.Commit(savedState)
      Console.WriteLine("Commit ...")
      ' Throw an error if a particular file doesn't exist.
      If Not File.Exists("FileDoesNotExist.txt") Then
         Throw New InstallException()
      End If
      ' Perform the final installation if the file exists.
   End Sub