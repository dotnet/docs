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
        ' <snippet39>
        Private TripleDes As New TripleDESCryptoServiceProvider
        ' </snippet39>

        ' <snippet40>
        Sub New(ByVal key As String)
            ' Initialize the crypto provider.
            TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
            TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
        End Sub
        ' </snippet40>

        ' <snippet41>
        Private Function TruncateHash( 
            ByVal key As String, 
            ByVal length As Integer) As Byte()

            Dim sha1 As New SHA1CryptoServiceProvider

            ' Hash the key.
            Dim keyBytes() As Byte = 
                System.Text.Encoding.Unicode.GetBytes(key)
            Dim hash() As Byte = sha1.ComputeHash(keyBytes)

            ' Truncate or pad the hash.
            ReDim Preserve hash(length - 1)
            Return hash
        End Function
        ' </snippet41>

        ' <snippet42>
        Public Function EncryptData( 
            ByVal plaintext As String) As String

            ' Convert the plaintext string to a byte array.
            Dim plaintextBytes() As Byte = 
                System.Text.Encoding.Unicode.GetBytes(plaintext)

            ' Create the stream.
            Dim ms As New System.IO.MemoryStream
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

            ' Create the stream.
            Dim ms As New System.IO.MemoryStream
            ' Create the decoder to write to the stream.
            Dim decStream As New CryptoStream(ms, 
                TripleDes.CreateDecryptor(), 
                System.Security.Cryptography.CryptoStreamMode.Write)

            ' Use the crypto stream to write the byte array to the stream.
            decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
            decStream.FlushFinalBlock()

            ' Convert the plaintext stream to a string.
            Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
        End Function
        ' </snippet43>

    End Class
End Class