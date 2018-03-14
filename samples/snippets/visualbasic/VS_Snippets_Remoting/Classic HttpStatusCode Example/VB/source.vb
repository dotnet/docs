Imports System
Imports System.Net
Imports System.Web
Imports System.Web.UI

Public Class Page1
    Inherits Page
    
    Private Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
 Dim httpReq As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
 httpReq.AllowAutoRedirect = False
        
 Dim httpRes As HttpWebResponse = CType(httpReq.GetResponse(), HttpWebResponse)
        
 If httpRes.StatusCode = HttpStatusCode.Moved Then
     ' Code for moved resources goes here.
 End If

 httpRes.Close()

' </Snippet1>
    End Sub
End Class


