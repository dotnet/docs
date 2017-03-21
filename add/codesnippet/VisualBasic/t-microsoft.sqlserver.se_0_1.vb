<SqlFunction(FillRowMethodName:="FillFileRow")> _
Public Shared Function GetFileDetails(ByVal directoryPath As String) As IEnumerable

   Try

      Dim di As DirectoryInfo = new DirectoryInfo(directoryPath)
      return di.GetFiles()
   
   Catch dnf As DirectoryNotFoundException

      Dim message As String() = {dnf.ToString() }
      return message

   End Try
End Function