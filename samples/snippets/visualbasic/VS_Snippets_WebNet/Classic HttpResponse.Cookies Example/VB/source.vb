Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim MyCookie As New HttpCookie("LastVisit")
Dim now As DateTime = DateTime.Now

MyCookie.Value = now.ToString()
MyCookie.Expires = now.AddHours(1)

Response.Cookies.Add(MyCookie)
   
' </Snippet1>
 End Sub
End Class
