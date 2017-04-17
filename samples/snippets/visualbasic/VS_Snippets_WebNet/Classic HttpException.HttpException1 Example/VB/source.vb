Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
  
Dim Num as Integer
' <Snippet1>
If Num = 0 Then
   Throw New HttpException("No value entered")
end if
   
' </Snippet1>
 End Sub
End Class
