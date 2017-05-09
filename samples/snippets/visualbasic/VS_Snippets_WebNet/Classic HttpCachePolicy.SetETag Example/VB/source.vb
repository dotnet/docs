Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
        Response.Cache.SetETag("""50f59e42f4d8bc1:cd7""")
 
' </Snippet1>
 End Sub
End Class
