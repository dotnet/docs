Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

 Protected MyCookie As HttpCookie

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Dim dt As DateTime = DateTime.Now()
 Dim ts As New TimeSpan(0,0,10,0)
 
 MyCookie.Expires = dt.Add(ts)
    
' </Snippet1>
 End Sub
End Class
