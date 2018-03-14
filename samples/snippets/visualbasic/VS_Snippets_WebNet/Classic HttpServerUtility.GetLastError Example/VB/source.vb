Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim LastError As Exception
Dim ErrMessage As String

LastError = Server.GetLastError()

If Not LastError Is Nothing Then
   ErrMessage = LastError.Message
Else
   ErrMessage = "No Errors"
End If
 
Response.Write("Last Error = " & ErrMessage)
   
' </Snippet1>
 End Sub
End Class
