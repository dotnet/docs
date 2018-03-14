Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim Loop1 As Integer
 Dim TempFileName As String
 Dim MyFileCollection As HttpFileCollection = Request.Files
 
 For Loop1 = 0 To MyFileCollection.Count - 1
    ' Create a new file name.
    TempFileName = "C:\TempFiles\File_" & CStr(Loop1)
    ' Save the file.
    MyFileCollection(Loop1).SaveAs(TempFileName)
 Next Loop1
   
' </Snippet1>
 End Sub
End Class
