'<Snippet1>
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Class Alice

    Public Shared Sub Main(ByVal args() As String)
        Dim bob As New Bob()
        If (True) Then
            Using dsa As New ECDsaCng()
                    dsa.HashAlgorithm = CngAlgorithm.Sha256
                    bob.key = dsa.Key.Export(CngKeyBlobFormat.EccPublicBlob)
                    Dim data() As Byte = {21, 5, 8, 12, 207}
                    Dim signature As Byte() = dsa.SignData(data)
                    bob.Receive(data, signature)
            End Using
        End If

    End Sub 'Main
End Class 'Alice 


Public Class Bob
    Public key() As Byte

    Public Sub Receive(ByVal data() As Byte, ByVal signature() As Byte)
        Using ecsdKey As New ECDsaCng(CngKey.Import(key, CngKeyBlobFormat.EccPublicBlob))
                If ecsdKey.VerifyData(data, signature) Then
                    Console.WriteLine("Data is good")
                Else
                    Console.WriteLine("Data is bad")
                End If
        End Using

    End Sub 'Receive
End Class 'Bob 
'</Snippet1>