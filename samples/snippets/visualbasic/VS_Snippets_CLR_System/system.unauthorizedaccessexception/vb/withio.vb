' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.IO

Module Example
   Public Sub Main()
      Dim filePath As String = ".\ROFile.txt"
      If Not File.Exists(filePath) Then File.Create(filePath)
      ' Keep existing attributes, and set ReadOnly attribute.
      File.SetAttributes(filePath, 
                        (New FileInfo(filePath)).Attributes Or FileAttributes.ReadOnly)

      Dim sw As StreamWriter = Nothing
      Try
         sw = New StreamWriter(filePath)
         sw.Write("Test")
      Catch e As UnauthorizedAccessException
         Dim attr As FileAttributes = (New FileInfo(filePath)).Attributes
         Console.Write("UnAuthorizedAccessException: Unable to access file. ")
         If (attr And FileAttributes.ReadOnly) > 0 Then
            Console.Write("The file is read-only.") 
         End If
       Finally
         If sw IsNot Nothing Then sw.Close()
      End Try   
   End Sub
End Module
' The example displays the following output:
'   UnAuthorizedAccessException: Unable to access file. The file is read-only.
' </Snippet1>
