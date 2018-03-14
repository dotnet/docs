Imports System
Imports System.Data
Imports System.Security.Principal
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected Sub Method()
' <Snippet1>
 Dim myUri As New Uri("http://www.contoso.com/Hello%20World.htm", True)

' </Snippet1>
    End Sub
End Class
