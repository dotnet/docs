Imports System
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Security.Policy

Public Class Form1
    Inherits Form
    Protected myAssembly As System.Reflection.Assembly    
    
    Protected Sub Method()
' <Snippet1>
 Dim hash As New Hash(myAssembly)
 Dim hashcode As Byte() = hash.SHA1
' </Snippet1>
    End Sub
End Class
