Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
Response.Cache.AppendCacheExtension("post-check=900,pre-check=3600")
    
' </Snippet1>
 End Sub
End Class
