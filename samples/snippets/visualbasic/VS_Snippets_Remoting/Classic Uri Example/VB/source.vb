Imports System
Imports System.Data
Imports System.Net
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected Sub Method()
' <Snippet1>
Dim siteUri As New Uri("http://www.contoso.com/")
        
Dim wr As WebRequest = WebRequest.Create(siteUri)

' </Snippet1>
    End Sub
End Class
