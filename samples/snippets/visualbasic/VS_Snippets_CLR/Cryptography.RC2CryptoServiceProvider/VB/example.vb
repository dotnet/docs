'<SNIPPET1>
Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography



Module MyMainModule

    Sub Main()
        Dim originalBytes As Byte() = ASCIIEncoding.ASCII.GetBytes("Here is some data.")

        'Create a new RC2CryptoServiceProvider.
        Dim rc2CSP As New RC2CryptoServiceProvider()

        rc2CSP.UseSalt = True

        rc2CSP.GenerateKey()
        rc2CSP.GenerateIV()

        'Encrypt the data.
        Dim msEncrypt As New MemoryStream()
        Dim csEncrypt As New CryptoStream(msEncrypt, rc2CSP.CreateEncryptor(rc2CSP.Key, rc2CSP.IV), CryptoStreamMode.Write)

        'Write all data to the crypto stream and flush it.
        csEncrypt.Write(originalBytes, 0, originalBytes.Length)
        csEncrypt.FlushFinalBlock()

        'Get encrypted array of bytes.
        Dim encryptedBytes As Byte() = msEncrypt.ToArray()

        'Decrypt the previously encrypted message.
        Dim msDecrypt As New MemoryStream(encryptedBytes)
        Dim csDecrypt As New CryptoStream(msDecrypt, rc2CSP.CreateDecryptor(rc2CSP.Key, rc2CSP.IV), CryptoStreamMode.Read)

        Dim unencryptedBytes(originalBytes.Length) As Byte

        'Read the data out of the crypto stream.
        csDecrypt.Read(unencryptedBytes, 0, unencryptedBytes.Length)

        'Convert the byte array back into a string.
        Dim plaintext As String = ASCIIEncoding.ASCII.GetString(unencryptedBytes)

        'Display the results.
        Console.WriteLine("Unencrypted text: {0}", plaintext)

        Console.ReadLine()

    End Sub
End Module
'</SNIPPET1>