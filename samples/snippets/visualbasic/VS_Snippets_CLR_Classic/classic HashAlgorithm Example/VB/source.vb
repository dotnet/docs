Imports System
Imports System.Windows.Forms
Imports System.Security.Policy
Imports System.Security.Cryptography

Public Class Form1
    Inherits Form
    Protected dataArray() As Byte    
    
    Protected Sub Method()
' <Snippet1>
 Dim sha As New SHA1CryptoServiceProvider()
 Dim result As Byte() = sha.ComputeHash(dataArray)
' </Snippet1>
    End Sub
End Class
