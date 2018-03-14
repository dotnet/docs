 ' <SNIPPET1>
Imports System
Imports System.IO
Imports System.Security.Cryptography



Public Class StoreKey
    
    Public Shared Sub Main()
        ' creates the CspParameters object and sets the key container name used to store the RSA key pair
        Dim cp As New CspParameters()
        cp.KeyContainerName = "MyKeyContainerName"
        
        ' instantiates the rsa instance accessing the key container MyKeyContainerName
        Dim rsa As New RSACryptoServiceProvider(cp)
        ' add the below line to delete the key entry in MyKeyContainerName
        ' rsa.PersistKeyInCsp = false;
        'writes out the current key pair used in the rsa instance
        Console.WriteLine("Key is : "  & rsa.ToXmlString(True))
    End Sub 'Main
End Class 'StoreKey
' </SNIPPET1>