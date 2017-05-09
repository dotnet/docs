Imports System
Imports System.Windows.Forms
Imports System.Security.Policy
Imports System.Security.Cryptography


Public Class Form1
    Inherits Form
    
' <Snippet1>
 Function MD5hash(data() As Byte) As Byte()
     ' This is one implementation of the abstract class MD5.
     Dim md5 As New MD5CryptoServiceProvider()
        
     Dim result As Byte() = md5.ComputeHash(data)
        
     Return result
 End Function
' </Snippet1>
End Class
