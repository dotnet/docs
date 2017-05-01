'<SNIPPET1>
Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography



Public Class rfc2898test
    ' Generate a key k1 with password pwd1 and salt salt1.
    ' Generate a key k2 with password pwd1 and salt salt1.
    ' Encrypt data1 with key k1 using symmetric encryption, creating edata1.
    ' Decrypt edata1 with key k2 using symmetric decryption, creating data2.
    ' data2 should equal data1.
    Private Const usageText As String = "Usage: RFC2898 <password>" + vbLf + "You must specify the password for encryption." + vbLf

    Public Shared Sub Main(ByVal passwordargs() As String)
        'If no file name is specified, write usage text.
        If passwordargs.Length = 0 Then
            Console.WriteLine(usageText)
        Else
            '<SNIPPET6>
            Dim pwd1 As String = passwordargs(0)

            Dim salt1(8) As Byte
            Using rngCsp As New RNGCryptoServiceProvider()
                rngCsp.GetBytes(salt1)
            End Using
            'data1 can be a string or contents of a file.
            Dim data1 As String = "Some test data"
            '<SNIPPET3>
            'The default iteration count is 1000 so the two methods use the same iteration count.
            Dim myIterations As Integer = 1000
            '</SNIPPET6>		
            '<SNIPPET2>
            Try
                '<SNIPPET4>
                Dim k1 As New Rfc2898DeriveBytes(pwd1, salt1, myIterations)
                Dim k2 As New Rfc2898DeriveBytes(pwd1, salt1)
                '</SNIPPET4>
                ' Encrypt the data.
                Dim encAlg As TripleDES = TripleDES.Create()
                encAlg.Key = k1.GetBytes(16)
                Dim encryptionStream As New MemoryStream()
                Dim encrypt As New CryptoStream(encryptionStream, encAlg.CreateEncryptor(), CryptoStreamMode.Write)
                Dim utfD1 As Byte() = New System.Text.UTF8Encoding(False).GetBytes(data1)
                '</SNIPPET2>
                encrypt.Write(utfD1, 0, utfD1.Length)
                encrypt.FlushFinalBlock()
                encrypt.Close()
                Dim edata1 As Byte() = encryptionStream.ToArray()
                k1.Reset()

                ' Try to decrypt, thus showing it can be round-tripped.
                Dim decAlg As TripleDES = TripleDES.Create()
                decAlg.Key = k2.GetBytes(16)
                decAlg.IV = encAlg.IV
                Dim decryptionStreamBacking As New MemoryStream()
                Dim decrypt As New CryptoStream(decryptionStreamBacking, decAlg.CreateDecryptor(), CryptoStreamMode.Write)
                '<SNIPPET5>
                decrypt.Write(edata1, 0, edata1.Length)
                decrypt.Flush()
                decrypt.Close()
                k2.Reset()
                '</SNIPPET5>
                Dim data2 As String = New UTF8Encoding(False).GetString(decryptionStreamBacking.ToArray())

                If Not data1.Equals(data2) Then
                    Console.WriteLine("Error: The two values are not equal.")
                Else
                    Console.WriteLine("The two values are equal.")
                    Console.WriteLine("k1 iterations: {0}", k1.IterationCount)
                    Console.WriteLine("k2 iterations: {0}", k2.IterationCount)
                End If
                '</SNIPPET3>
            Catch e As Exception
                Console.WriteLine("Error: ", e)
            End Try
        End If

    End Sub
End Class
'</SNIPPET1>