Option Explicit On
Option Strict On

' <snippet77>
Imports System.Security.Cryptography
' </snippet77>

'Public Class Form1

'    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Dim x As New Class1f51e40a2f8843e2a83e28a0b5c0d6fd

'        x.TestEncoding()
'        x.TestDecoding()

'    End Sub


'End Class

' 1f51e40a-2f88-43e2-a83e-28a0b5c0d6fd
' Walkthrough: Encrypting and Decrypting Strings in Visual Basic
Class Class1f51e40a2f8843e2a83e28a0b5c0d6fd

    ' <snippet78>
    Sub TestEncoding()
        Dim plainText As String = InputBox("Enter the plain text:")
        Dim password As String = InputBox("Enter the password:")

        Dim wrapper As New Simple3Des(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)

        MsgBox("The cipher text is: " & cipherText)
        My.Computer.FileSystem.WriteAllText( 
            My.Computer.FileSystem.SpecialDirectories.MyDocuments & 
            "\cipherText.txt", cipherText, False)
    End Sub
    ' </snippet78>

    ' <snippet79>
    Sub TestDecoding()
        Dim cipherText As String = My.Computer.FileSystem.ReadAllText( 
            My.Computer.FileSystem.SpecialDirectories.MyDocuments & 
                "\cipherText.txt")
        Dim password As String = InputBox("Enter the password:")
        Dim wrapper As New Simple3Des(password)

        ' DecryptData throws if the wrong password is used.
        Try
            Dim plainText As String = wrapper.DecryptData(cipherText)
            MsgBox("The plain text is: " & plainText)
        Catch ex As System.Security.Cryptography.CryptographicException
            MsgBox("The data could not be decrypted with the password.")
        End Try
    End Sub
    ' </snippet79>

    Class test
        ' <snippet38>
        Public NotInheritable Class Simple3Des
        End Class
        ' </snippet38>
    End Class

    Public NotInheritable Class Simple3Des
        Implements IDisposable

        ' <snippet39>
        Private TripleDes As TripleDES = TripleDES.Create()

        Private Const SaltSize As Integer = 16
        Private Const Iterations As Integer = 600000
        Private ReadOnly Key As String
        ' </snippet39>

        ' <snippet40>
        Sub New(ByVal key As String)
            ' Store the key. The encryption key and IV are created per message.
            Me.Key = key
        End Sub
        ' </snippet40>

        ' <snippet41>
        Private Function DeriveKey(ByVal salt() As Byte) As Byte()
            ' Derive a key from the specified key and the salt.
            Using kdf As New Rfc2898DeriveBytes(
                Key, salt, Iterations, HashAlgorithmName.SHA256)

                Return kdf.GetBytes(TripleDes.KeySize \ 8)
            End Using
        End Function
        ' </snippet41>

        ' <snippet42>
        Public Function EncryptData( 
            ByVal plaintext As String) As String

            ' Create a new salt and initialization vector for this message.
            Dim salt(SaltSize - 1) As Byte
            Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()
                rng.GetBytes(salt)
            End Using

            TripleDes.Key = DeriveKey(salt)
            TripleDes.GenerateIV()

            ' Convert the plaintext string to a byte array.
            Dim plaintextBytes() As Byte = 
                System.Text.Encoding.Unicode.GetBytes(plaintext)

            ' Create the stream.
            Dim ms As New System.IO.MemoryStream
            ' Write the salt and initialization vector in front of the cipher text.
            ms.Write(salt, 0, salt.Length)
            ms.Write(TripleDes.IV, 0, TripleDes.IV.Length)

            ' Create the encoder to write to the stream.
            Dim encStream As New CryptoStream(ms, 
                TripleDes.CreateEncryptor(), 
                System.Security.Cryptography.CryptoStreamMode.Write)

            ' Use the crypto stream to write the byte array to the stream.
            encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
            encStream.FlushFinalBlock()

            ' Convert the encrypted stream to a printable string.
            Return Convert.ToBase64String(ms.ToArray)
        End Function
        ' </snippet42>

        ' <snippet43>
        Public Function DecryptData( 
            ByVal encryptedtext As String) As String

            ' Convert the encrypted text string to a byte array.
            Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

            ' Read the salt and initialization vector that precede the cipher text.
            Dim ivSize As Integer = TripleDes.BlockSize \ 8
            If encryptedBytes.Length < SaltSize + ivSize Then
                Throw New CryptographicException(
                    "The encrypted data is not in the expected format.")
            End If

            Dim salt(SaltSize - 1) As Byte
            Dim iv(ivSize - 1) As Byte
            Array.Copy(encryptedBytes, 0, salt, 0, SaltSize)
            Array.Copy(encryptedBytes, SaltSize, iv, 0, ivSize)

            TripleDes.Key = DeriveKey(salt)
            TripleDes.IV = iv

            ' Create the stream.
            Dim ms As New System.IO.MemoryStream
            ' Create the decoder to write to the stream.
            Dim decStream As New CryptoStream(ms, 
                TripleDes.CreateDecryptor(), 
                System.Security.Cryptography.CryptoStreamMode.Write)

            ' Use the crypto stream to write the byte array to the stream.
            decStream.Write(encryptedBytes, SaltSize + ivSize, 
                encryptedBytes.Length - SaltSize - ivSize)
            decStream.FlushFinalBlock()

            ' Convert the plaintext stream to a string.
            Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
        End Function
        ' </snippet43>

        Public Sub Dispose() Implements IDisposable.Dispose
            TripleDes?.Dispose()
        End Sub

    End Class
End Class