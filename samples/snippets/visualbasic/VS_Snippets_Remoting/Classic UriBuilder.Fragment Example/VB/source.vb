Imports System
Imports System.Data
Imports System.Security.Principal
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected Sub Method()
' <Snippet1>
Dim uBuild As New UriBuilder("http://www.contoso.com/")
uBuild.Path = "index.htm"
uBuild.Fragment = "main"
        
Dim myUri As Uri = uBuild.Uri

' </Snippet1>
    End Sub
End Class
