'<Snippet1>
Imports System
Imports System.Security.Cryptography
Imports System.Text


Class Program

    Shared Sub Main(ByVal args() As String)
        Dim [source] As String = "Hello World!"
        Using md5Hash As MD5 = MD5.Create()

            Dim hash As String = GetMd5Hash(md5Hash, source)

            Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".")

            Console.WriteLine("Verifying the hash...")

            If VerifyMd5Hash(md5Hash, [source], hash) Then
                Console.WriteLine("The hashes are the same.")
            Else
                Console.WriteLine("The hashes are not same.")
            End If
        End Using
    End Sub 'Main



    Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function 'GetMd5Hash


    ' Verify a hash against a string.
    Shared Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
        ' Hash the input.
        Dim hashOfInput As String = GetMd5Hash(md5Hash, input)

        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If

    End Function 'VerifyMd5Hash
End Class 'Program 
' This code example produces the following output:
'
' The MD5 hash of Hello World! is: ed076287532e86365e841e92bfc50d8c.
' Verifying the hash...
' The hashes are the same.
'</Snippet1>