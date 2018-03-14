Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
Dim MyCookieCollection as New HttpCookieCollection()
' <Snippet1>
MyCookieCollection.Clear()
    
' </Snippet1>
 End Sub
End Class
