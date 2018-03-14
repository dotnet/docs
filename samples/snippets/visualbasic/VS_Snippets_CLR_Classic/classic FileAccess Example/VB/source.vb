Imports System
Imports System.IO
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected Sub Method(name As String)
' <Snippet1>
 Dim s2 As New FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read)
' </Snippet1>
    End Sub
End Class
