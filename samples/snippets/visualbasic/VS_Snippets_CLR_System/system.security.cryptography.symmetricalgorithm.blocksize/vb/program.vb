'<Snippet1>
Imports System
Imports System.Security.Cryptography


Class Program

    Shared Sub Main(ByVal args() As String)
        Dim aes As New AesManaged()
        Console.WriteLine("AesManaged ")
        Dim ks As KeySizes() = aes.LegalKeySizes
        Dim k As KeySizes
        For Each k In ks
            Console.WriteLine(vbTab + "Legal min key size = " + k.MinSize)
            Console.WriteLine(vbTab + "Legal max key size = " + k.MaxSize)
        Next k
        ks = aes.LegalBlockSizes

        For Each k In ks
            Console.WriteLine(vbTab + "Legal min block size = " + k.MinSize)
            Console.WriteLine(vbTab + "Legal max block size = " + k.MaxSize)
        Next k

        Dim des As New DESCryptoServiceProvider()
        Console.WriteLine("DESCryptoServiceProvider ")
        ks = des.LegalKeySizes

        For Each k In ks
            Console.WriteLine(vbTab + "Legal min key size = " + k.MinSize)
            Console.WriteLine(vbTab + "Legal max key size = " + k.MaxSize)
        Next k
        ks = des.LegalBlockSizes

        For Each k In ks
            Console.WriteLine(vbTab + "Legal min block size = " + k.MinSize)
            Console.WriteLine(vbTab + "Legal max block size = " + k.MaxSize)
        Next k

        Dim rc2 As New RC2CryptoServiceProvider()
        Console.WriteLine("RC2CryptoServiceProvider ")
        ks = rc2.LegalKeySizes

        For Each k In ks
            Console.WriteLine(vbTab + "Legal min key size = " + k.MinSize)
            Console.WriteLine(vbTab + "Legal max key size = " + k.MaxSize)
        Next k
        ks = rc2.LegalBlockSizes

        For Each k In ks
            Console.WriteLine(vbTab + "Legal min block size = " + k.MinSize)
            Console.WriteLine(vbTab + "Legal max block size = " + k.MaxSize)
        Next k

        Dim rij As New RijndaelManaged()
        Console.WriteLine("RijndaelManaged ")
        ks = rij.LegalKeySizes

        For Each k In ks
            Console.WriteLine(vbTab + "Legal min key size = " + k.MinSize)
            Console.WriteLine(vbTab + "Legal max key size = " + k.MaxSize)
        Next k
        ks = rij.LegalBlockSizes

        For Each k In ks
            Console.WriteLine(vbTab + "Legal min block size = " + k.MinSize)
            Console.WriteLine(vbTab + "Legal max block size = " + k.MaxSize)
        Next k

        Dim tsp As New TripleDESCryptoServiceProvider()
        Console.WriteLine("TripleDESCryptoServiceProvider ")
        ks = tsp.LegalKeySizes

        For Each k In ks
            Console.WriteLine(vbTab + "Legal min key size = " + k.MinSize)
            Console.WriteLine(vbTab + "Legal max key size = " + k.MaxSize)
        Next k
        ks = tsp.LegalBlockSizes

        For Each k In ks
            Console.WriteLine(vbTab + "Legal min block size = " + k.MinSize)
            Console.WriteLine(vbTab + "Legal max block size = " + k.MaxSize)
        Next k

    End Sub 'Main 
End Class 'Program
'This sample produces the following output:
'AesManaged
'        Legal min key size = 128
'        Legal max key size = 256
'        Legal min block size = 128
'        Legal max block size = 128
'DESCryptoServiceProvider
'        Legal min key size = 64
'        Legal max key size = 64
'        Legal min block size = 64
'        Legal max block size = 64
'RC2CryptoServiceProvider
'        Legal min key size = 40
'        Legal max key size = 128
'        Legal min block size = 64
'        Legal max block size = 64
'RijndaelManaged
'        Legal min key size = 128
'        Legal max key size = 256
'        Legal min block size = 128
'        Legal max block size = 256
'TripleDESCryptoServiceProvider
'        Legal min key size = 128
'        Legal max key size = 192
'        Legal min block size = 64
'        Legal max block size = 64
'</Snippet1>