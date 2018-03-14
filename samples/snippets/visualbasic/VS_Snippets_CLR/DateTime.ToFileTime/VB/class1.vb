Namespace ToFileTime
    _
   Class Class1
      '<Snippet1>
      Public Shared Sub Main()

         System.Console.WriteLine("Enter the file path:")
         Dim filePath As String
         filePath = System.Console.ReadLine()

         If System.IO.File.Exists(filePath) Then
            Dim fileCreationDateTime As System.DateTime
            fileCreationDateTime = System.IO.File.GetCreationTime(filePath)

            Dim fileCreationFileTime As Long
            fileCreationFileTime = fileCreationDateTime.ToFileTime()

            System.Console.WriteLine("{0} in file time is {1}.", _
                                     fileCreationDateTime, _
                                     fileCreationFileTime)
         Else
            System.Console.WriteLine("{0} is an invalid file", filePath)
         End If
      End Sub
      '</Snippet1>
   End Class
End Namespace
