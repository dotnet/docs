Imports System
Imports System.Web
Imports System.Web.UI

Imports System.Collections.Specialized

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
  Dim MyCookieCollection As HttpCookieCollection
  Dim MyCookie As HttpCookie
  Dim MyKeyNames() As String
  Dim MyValues() As String
  Dim loop1 As Integer

  MyCookieCollection = Request.Cookies
  For loop1 = 0 To MyCookieCollection.Count - 1
      MyCookie = MyCookieCollection(loop1)
      If MyCookie.HasKeys Then
          Dim MyCookieValues As NameValueCollection = _
              New NameValueCollection(MyCookie.Values)
          MyKeyNames = MyCookieValues.AllKeys
          For Each KeyName As String In MyKeyNames
              MyValues = MyCookieValues.GetValues(KeyName)
          Next
      End If
  Next loop1

' </Snippet1>
 End Sub
End Class
