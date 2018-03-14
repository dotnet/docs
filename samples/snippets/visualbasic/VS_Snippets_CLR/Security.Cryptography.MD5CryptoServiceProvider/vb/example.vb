'<SNIPPET1>
Imports System
Imports System.Security.Cryptography
Imports System.Text

Module Example

    ' Hash an input string and return the hash as
    ' a 32 character hexadecimal string.
    Function getMd5Hash(ByVal input As String) As String
        ' Create a new instance of the MD5CryptoServiceProvider object.
        Dim md5Hasher As New MD5CryptoServiceProvider()

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))

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

    End Function


    ' Verify a hash against a string.
    Function verifyMd5Hash(ByVal input As String, ByVal hash As String) As Boolean
        ' Hash the input.
        Dim hashOfInput As String = getMd5Hash(input)

        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If

    End Function



    Sub Main()
        Dim source As String = "Hello World!"

        Dim hash As String = getMd5Hash(source)

        Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".")

        Console.WriteLine("Verifying the hash...")

        If verifyMd5Hash(source, hash) Then
            Console.WriteLine("The hashes are the same.")
        Else
            Console.WriteLine("The hashes are not same.")
        End If

    End Sub
End Module
' This code example produces the following output:
'
' The MD5 hash of Hello World! is: ed076287532e86365e841e92bfc50d8c.
' Verifying the hash...
' The hashes are the same.
'</SNIPPET1>
