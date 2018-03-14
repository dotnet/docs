' <Snippet1>
Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

 Protected Loop1 As Integer
 Protected MyString As String

  Protected Sub Page_Load(sender As Object, e As EventArgs)

    Dim MyFileCollection As HttpFileCollection
    Dim MyFile As HttpPostedFile
    Dim FileLen As Integer
    Dim MyString As String
    Dim MyStream As System.IO.Stream
 
    MyFileCollection = Request.Files
    MyFile = MyFileCollection(0)
 
    FileLen = MyFile.ContentLength
    Dim Input(FileLen) As Byte
 
    ' Initialize the stream.
    MyStream = MyFile.InputStream
 
    ' Read the file into the byte array.
    MyStream.Read(input, 0, FileLen)
 
    ' Copy the byte array into a string.
    For Loop1 = 0 To FileLen-1
      MyString = MyString & Input(Loop1).ToString()
    Next Loop1
    
 End Sub

End Class
' </Snippet1>
