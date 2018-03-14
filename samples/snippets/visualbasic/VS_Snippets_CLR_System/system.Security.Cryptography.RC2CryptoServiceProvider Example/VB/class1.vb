'<snippet1>
Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography



Module Crypto

    Sub Main()

        ' Create a new instance of the RC2CryptoServiceProvider class
        ' and automatically generate a Key and IV.
        Dim rc2CSP As New RC2CryptoServiceProvider()

        Console.WriteLine("Effective key size is {0} bits.", rc2CSP.EffectiveKeySize)

        ' Get the key and IV.
        Dim key As Byte() = rc2CSP.Key
        Dim IV As Byte() = rc2CSP.IV

        ' Get an encryptor.
        Dim encryptor As ICryptoTransform = rc2CSP.CreateEncryptor(key, IV)

        ' Encrypt the data as an array of encrypted bytes in memory.
        Dim msEncrypt As New MemoryStream()
        Dim csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)

        ' Convert the data to a byte array.
        Dim original As String = "Here is some data to encrypt."
        Dim toEncrypt As Byte() = Encoding.ASCII.GetBytes(original)

        ' Write all data to the crypto stream and flush it.
        csEncrypt.Write(toEncrypt, 0, toEncrypt.Length)
        csEncrypt.FlushFinalBlock()

        ' Get the encrypted array of bytes.
        Dim encrypted As Byte() = msEncrypt.ToArray()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' This is where the data could be transmitted or saved.          
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Get a decryptor that uses the same key and IV as the encryptor.
        Dim decryptor As ICryptoTransform = rc2CSP.CreateDecryptor(key, IV)

        ' Now decrypt the previously encrypted message using the decryptor
        ' obtained in the above step.
        Dim msDecrypt As New MemoryStream(encrypted)
        Dim csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)

        ' Read the decrypted bytes from the decrypting stream
        ' and place them in a StringBuilder class.
        Dim roundtrip As New StringBuilder()

        Dim b As Integer = 0

        Do
            b = csDecrypt.ReadByte()

            If b <> -1 Then
                roundtrip.Append(ChrW(b))
            End If
        Loop While b <> -1

        ' Display the original data and the decrypted data.
        Console.WriteLine("Original:   {0}", original)
        Console.WriteLine("Round Trip: {0}", roundtrip)

        Console.ReadLine()

    End Sub
End Module
'</snippet1>