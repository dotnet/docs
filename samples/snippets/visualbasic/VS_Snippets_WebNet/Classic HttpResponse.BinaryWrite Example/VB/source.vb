Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim MyFileStream As FileStream
 Dim FileSize As Long
 
 MyFileStream = New FileStream("sometext.txt", FileMode.Open)
 FileSize = MyFileStream.Length
 
 Dim Buffer(CInt(FileSize)) As Byte
 MyFileStream.Read(Buffer, 0, CInt(FileSize))
 MyFileStream.Close()
 
 Response.Write("<b>File Contents: </b>")
 Response.BinaryWrite(Buffer)
    
' </Snippet1>
 End Sub
End Class
