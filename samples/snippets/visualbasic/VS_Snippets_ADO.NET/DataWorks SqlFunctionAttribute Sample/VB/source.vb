Option Explicit On
Option Strict On

Imports System
Imports System.IO
Imports System.Collections
Imports Microsoft.SqlServer.Server

Public Class Class1

'<Snippet1>
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
'</Snippet1>




End Class