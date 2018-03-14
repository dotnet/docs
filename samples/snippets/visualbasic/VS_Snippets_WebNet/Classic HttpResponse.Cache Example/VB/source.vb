Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
   Response.Cache.SetExpires(DateTime.Now.AddSeconds(60))
   Response.Cache.SetCacheability(HttpCacheability.Public)
   Response.Cache.SetValidUntilExpires(False)
   Response.Cache.VaryByParams("Category") = True

   If Response.Cache.VaryByParams("Category") Then
      '...
   End If
    
' </Snippet1>
 End Sub
End Class
