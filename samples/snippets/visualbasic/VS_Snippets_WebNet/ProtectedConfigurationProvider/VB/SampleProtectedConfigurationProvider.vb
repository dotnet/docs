'<Snippet1>
Imports System
Imports System.Xml
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Configuration.Provider
Imports System.Collections.Specialized
Imports System.Configuration


Namespace Samples.AspNet.ProtectedConfiguration

  Public Class TripleDESProtectedConfigurationProvider
    Inherits ProtectedConfigurationProvider

    Private des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
  
    Private pKeyFilePath As String
    Private pName As String

    Public ReadOnly Property KeyFilePath As String
      Get
        Return pKeyFilePath
      End Get
    End Property

    '
    ' ProviderBase.Name
    '

    Public Overrides ReadOnly Property Name As String    
      Get
        Return pName
      End Get
    End Property


    '
    ' ProviderBase.Initialize
    '

    Public Overrides Sub Initialize(name As String, config As NameValueCollection)
      pName = name
      pKeyFilePath = config("keyFilePath")
      ReadKey(KeyFilePath)
    End Sub


    '
    ' ProtectedConfigurationProvider.Encrypt
    '

    Public Overrides Function Encrypt(node As XmlNode ) As XmlNode 
      Dim encryptedData As String = EncryptString(node.OuterXml)

      Dim xmlDoc As XmlDocument = New XmlDocument()
      xmlDoc.PreserveWhitespace = True
      xmlDoc.LoadXml("<EncryptedData>" & encryptedData & "</EncryptedData>")
                  
      Return xmlDoc.DocumentElement
    End Function


    '
    ' ProtectedConfigurationProvider.Decrypt
    '

    Public Overrides Function Decrypt(encryptedNode As XmlNode) As XmlNode
      Dim decryptedData As String = DecryptString(encryptedNode.InnerText)

      Dim xmlDoc As XmlDocument = New XmlDocument()
      xmlDoc.PreserveWhitespace = True
      xmlDoc.LoadXml(decryptedData)  

      Return xmlDoc.DocumentElement
    End Function


    '
    ' EncryptString
    '    Encrypts a configuration section and returns the encrypted
    ' XML as a string.
    '
    
    Private Function EncryptString(encryptValue As String) As String
    
      Dim valBytes() As Byte = Encoding.Unicode.GetBytes(encryptValue)

      Dim transform As ICryptoTransform = des.CreateEncryptor()

      Dim ms As MemoryStream = New MemoryStream()
      Dim cs As CryptoStream = New CryptoStream(ms, transform, CryptoStreamMode.Write)
      cs.Write(valBytes, 0, valBytes.Length)
      cs.FlushFinalBlock()
      Dim returnBytes() As Byte = ms.ToArray()
      cs.Close()

      Return Convert.ToBase64String(returnBytes)
    End Function


    '
    ' DecryptString
    '    Decrypts an encrypted configuration section and returns the
    ' unencrypted XML as a string.
    '

    Private Function DecryptString(encryptedValue As String) As String
      Dim valBytes() As Byte = Convert.FromBase64String(encryptedValue)

      Dim transform As ICryptoTransform = des.CreateDecryptor()

      Dim ms As MemoryStream = New MemoryStream()
      Dim cs As CryptoStream = New CryptoStream(ms, transform, CryptoStreamMode.Write)
      cs.Write(valBytes, 0, valBytes.Length)
      cs.FlushFinalBlock()
      Dim returnBytes() As Byte = ms.ToArray()
      cs.Close()

      Return Encoding.Unicode.GetString(returnBytes)
    End Function


    '
    ' CreateKey
    '    Generates a New TripleDES key and vector and writes them
    ' to the supplied file path.
    '

    Public Sub CreateKey(filePath As String)
      des.GenerateKey()
      des.GenerateIV()

      Dim sw As StreamWriter = New StreamWriter(filePath, false)
      sw.WriteLine(ByteToHex(des.Key))
      sw.WriteLine(ByteToHex(des.IV))
      sw.Close()
    End Sub


    '
    ' ReadKey
    '    Reads in the TripleDES key and vector from the supplied
    ' file path and sets the Key and IV properties of the 
    ' TripleDESCryptoServiceProvider.
    '

    Private Sub ReadKey(filePath As String)
      Dim sr As StreamReader = New StreamReader(filePath)
      Dim keyValue As String = sr.ReadLine()
      Dim ivValue As String = sr.ReadLine()

      des.Key = HexToByte(keyValue)
      des.IV = HexToByte(ivValue)
    End Sub


    '
    ' ByteToHex
    '    Converts a byte array to a hexadecimal string.
    '

    Private Function ByteToHex(byteArray As Byte()) As String
      Dim outString As String = ""

      For Each b As Byte In byteArray
        outString &= b.ToString("X2")
      Next

      Return outString
    End Function


    '
    ' HexToByte
    '    Converts a hexadecimal string to a byte array.
    '

    Private Function HexToByte(hexString As String) As Byte()
      Dim returnBytes() As Byte = New Byte(CInt((hexString.Length / 2) - 1)) {}

      For i As Integer= 0 To returnBytes.Length - 1
        returnBytes(i) = Convert.ToByte(hexString.Substring(i*2, 2), 16)
      Next

      Return returnBytes
    End Function

  End Class
End Namespace
'</Snippet1>