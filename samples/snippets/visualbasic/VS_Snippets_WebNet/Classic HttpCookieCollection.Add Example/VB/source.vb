Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim MyCookieCollection as New HttpCookieCollection()
 Dim MyCookie As New HttpCookie("LastVisit")
 MyCookie.Value = DateTime.Now().ToString()
 MyCookieCollection.Add(MyCookie)
    
' </Snippet1>
 End Sub
End Class
