Imports System
Imports System.Data
Imports System.Security.Cryptography
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Public Sub Method()
' <Snippet1>
 Dim random() As Byte = New Byte(100) {}
 'RNGCryptoServiceProvider is an implementation of an RNG
 Dim rng As New RNGCryptoServiceProvider()
 rng.GetNonZeroBytes(random) ' bytes in random are now random and none are zero
' </Snippet1>
    End Sub
End Class
