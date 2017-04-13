Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Security.Cryptography

Public Class Sample
    Protected DATA_SIZE As Integer = 1024
        
    Protected Sub Method()
' <Snippet1>
 Dim data(DATA_SIZE) As Byte
        
 Dim result() As Byte
        
 Dim sha As New SHA1CryptoServiceProvider()
 ' This is one implementation of the abstract class SHA1.
 result = sha.ComputeHash(data)
' </Snippet1>
    End Sub
End Class
