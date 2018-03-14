Imports System
Imports System.Data
Imports System.Security.Cryptography
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Public Shared Sub Main()
' <Snippet1>
 Dim random() As Byte = New Byte(100) {}
        
 'RNGCryptoServiceProvider is an implementation of an RNG
 Dim rng As New RNGCryptoServiceProvider()
 rng.GetBytes(random) ' bytes in random are now random
' </Snippet1>
    End Sub
End Class
