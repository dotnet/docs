'<snippet1>
Imports System
Imports System.Security.Cryptography



Public Class DataProtectionSample
    ' Create byte array for additional entropy when using Protect method.
    Private Shared s_aditionalEntropy As Byte() = {9, 8, 7, 6, 5}


    Public Shared Sub Main()
        ' Create a simple byte array containing data to be encrypted.
        Dim secret As Byte() = {0, 1, 2, 3, 4, 1, 2, 3, 4}

        'Encrypt the data.
        Dim encryptedSecret As Byte() = Protect(secret)
        Console.WriteLine("The encrypted byte array is:")
        PrintValues(encryptedSecret)

        ' Decrypt the data and store in a byte array.
        Dim originalData As Byte() = Unprotect(encryptedSecret)
        Console.WriteLine("{0}The original data is:", Environment.NewLine)
        PrintValues(originalData)

    End Sub


    Public Shared Function Protect(ByVal data() As Byte) As Byte()
        Try
            ' Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted
            '  only by the same current user.
            Return ProtectedData.Protect(data, s_aditionalEntropy, DataProtectionScope.CurrentUser)
        Catch e As CryptographicException
            Console.WriteLine("Data was not encrypted. An error occurred.")
            Console.WriteLine(e.ToString())
            Return Nothing
        End Try

    End Function


    Public Shared Function Unprotect(ByVal data() As Byte) As Byte()
        Try
            'Decrypt the data using DataProtectionScope.CurrentUser.
            Return ProtectedData.Unprotect(data, s_aditionalEntropy, DataProtectionScope.CurrentUser)
        Catch e As CryptographicException
            Console.WriteLine("Data was not decrypted. An error occurred.")
            Console.WriteLine(e.ToString())
            Return Nothing
        End Try

    End Function


    Public Shared Sub PrintValues(ByVal myArr() As [Byte])
        Dim i As [Byte]
        For Each i In myArr
            Console.Write(vbTab + "{0}", i)
        Next i
        Console.WriteLine()

    End Sub
End Class
'</snippet1>