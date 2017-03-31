Imports System
Imports System.Net
Imports System.Web
Imports System.Web.UI

Public Class Page1
    Inherits Page
    
    Private Sub Page_Load(sender As Object, e As EventArgs)
        Dim req As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com/"), HttpWebRequest)
' <Snippet1>
 Dim hasChanged As Boolean = _
    (req.RequestUri.ToString() <> req.Address.ToString())

' </Snippet1>
    End Sub
End Class
