Imports System
Imports System.Net
Imports System.Web
Imports System.Web.UI

Public Class Page1
    Inherits Page
    
    Private Sub Page_Load(sender As Object, e As EventArgs)
' <Snippet1>
 Dim HttpWReq As HttpWebRequest = _
    CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
        
 Dim HttpWResp As HttpWebResponse = _
    CType(HttpWReq.GetResponse(), HttpWebResponse)
 ' Insert code that uses the response object.
 HttpWResp.Close()
' </Snippet1>
    End Sub
End Class
