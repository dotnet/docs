Imports System
Imports System.Web
Imports System.Web.UI


Public Class Page1: Inherits Page

' <Snippet1>

Private Sub Page_Load(sender As Object, e As EventArgs)
   Response.Cache.AddValidationCallback(New HttpCacheValidateHandler(AddressOf CacheValidate1), Nothing)
End Sub
   
Public Sub CacheValidate1(context As HttpContext, data As Object, ByRef status As HttpValidationStatus)
   If context.Request.QueryString("Valid") = "false" Then
      status = HttpValidationStatus.Invalid
   Else
      status = HttpValidationStatus.Valid
   End If
End Sub
    
' </Snippet1>

End Class