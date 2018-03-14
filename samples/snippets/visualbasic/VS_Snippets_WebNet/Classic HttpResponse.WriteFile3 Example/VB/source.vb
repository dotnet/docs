Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI

Public Class Page1
  Inherits Page

  Private Sub Page_Load(sender As Object, e As EventArgs)
'<Snippet1>
 Dim FileName As String
 Dim MyFileStream As FileStream
 Dim FileHandle As IntPtr
 Dim StartPos As Long = 0
 Dim FileSize As Long
 
 FileName = "c:\\temp\\Login.txt"
 
 MyFileStream = New FileStream(FileName, FileMode.Open)
 FileHandle = MyFileStream.Handle
 FileSize = MyFileStream.Length
 
 Response.Write("<b>Login: </b>")
 Response.Write("<input type=text id=user /> ")
 Response.Write("<input type=submit value=Submit /><br><br>")
 
 Response.WriteFile(FileHandle, StartPos, FileSize)
    
 MyFileStream.Close()
'</Snippet1>
  End Sub
End Class
