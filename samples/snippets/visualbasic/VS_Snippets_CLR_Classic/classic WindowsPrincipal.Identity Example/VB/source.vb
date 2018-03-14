Imports System
Imports System.Data
Imports System.Security.Principal
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    Protected Sub Method()
' <Snippet1>
 Dim wp As New WindowsPrincipal(WindowsIdentity.GetCurrent())
 Dim username As String = wp.Identity.Name

' </Snippet1>
    End Sub
End Class
