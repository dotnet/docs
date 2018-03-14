Imports System
Imports System.Data
Imports System.Security.Principal
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected Sub Method()
' <Snippet1>

 Dim wi As WindowsIdentity = WindowsIdentity.GetCurrent()
 Dim wp As New WindowsPrincipal(wi)        

' </Snippet1>
    End Sub
End Class
