'<snippet1>
Imports System
Imports System.Security.Cryptography
Imports System.Text

Class EncryptorExample
     Private Shared quote As String = _
         "Things may come to those who wait, but only the " + _
         "things left by those who hustle. -- Abraham Lincoln"

     Public Shared Sub Main()
         Dim aesCSP As New AesCryptoServiceProvider()

         aesCSP.GenerateKey()
         aesCSP.GenerateIV()
         Dim encQuote() As Byte = EncryptString(aesCSP, quote)

         Console.WriteLine("Encrypted Quote:" + vbNewLine)
         Console.WriteLine(Convert.ToBase64String(encQuote))

         Console.WriteLine(vbNewLine + "Decrypted Quote:" + vbNewLine)
         Console.WriteLine(DecryptBytes(aesCSP, encQuote))
     End Sub

     '<snippet2>
     Public Shared Function EncryptString(symAlg As SymmetricAlgorithm, inString As String) As Byte()
         Dim inBlock() As Byte = UnicodeEncoding.Unicode.GetBytes(inString)
         Dim xfrm As ICryptoTransform = symAlg.CreateEncryptor()
         Dim outBlock() As Byte = xfrm.TransformFinalBlock(inBlock, 0, inBlock.Length)

         Return outBlock
     End Function
     '</snippet2>

     '<snippet3>
     Public Shared Function DecryptBytes(symAlg As SymmetricAlgorithm, inBytes() As Byte) As String
         Dim xfrm As ICryptoTransform = symAlg.CreateDecryptor()
         Dim outBlock() As Byte = xfrm.TransformFinalBlock(inBytes, 0, inBytes.Length)

         return UnicodeEncoding.Unicode.GetString(outBlock)
     End Function
     '</snippet3>
End Class
'</snippet1>
