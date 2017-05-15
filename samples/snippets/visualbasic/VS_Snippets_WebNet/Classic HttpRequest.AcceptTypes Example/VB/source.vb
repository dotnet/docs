Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim MyType() As String
 Dim Indx As Integer
 
 MyType = Request.AcceptTypes
 For Indx = 0 To MyType.GetUpperBound(0)
    Response.Write("Accept Type " & Cstr(Indx) & ": " & Cstr(MyType(Indx)) & "<br>")
 Next Indx
   
' </Snippet1>
 End Sub
End Class
