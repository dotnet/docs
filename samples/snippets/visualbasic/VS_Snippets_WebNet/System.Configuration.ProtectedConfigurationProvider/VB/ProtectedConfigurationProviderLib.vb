'<Snippet1>
Imports System
Imports System.Xml
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Configuration.Provider
Imports System.Collections.Specialized
Imports System.Configuration


' Shows how to create a custom protected configuration
' provider.
Namespace Samples.AspNet

    Public Class TripleDESProtectedConfigurationProvider
        Inherits ProtectedConfigurationProvider

        Private des _
        As New TripleDESCryptoServiceProvider()

        Private pKeyFilePath As String
        Private pName As String

        ' Gets the path of the file
        ' containing the key used to
        ' encrypt/decrypt.

        Public ReadOnly Property KeyFilePath() As String
            Get
                Return pKeyFilePath
            End Get
        End Property

        ' Gets the provider name.

        Public Overrides ReadOnly Property Name() As String
            Get
                Return pName
            End Get
        End Property


        ' Performs provider initialization.
        Public Overrides Sub Initialize( _
        ByVal name As String, _
        ByVal config As NameValueCollection)
            pName = name
            pKeyFilePath = config("keyContainerName")
            ReadKey(KeyFilePath)
        End Sub 'Initialize


        '<Snippet3> 
        ' Performs encryption.
        Public Overrides Function Encrypt( _
        ByVal node As XmlNode) As XmlNode
            Dim encryptedData As String = _
            EncryptString(node.OuterXml)

            Dim xmlDoc As New XmlDocument()
            xmlDoc.PreserveWhitespace = True
            xmlDoc.LoadXml( _
            ("<EncryptedData>" + encryptedData + _
            "</EncryptedData>"))

            Return xmlDoc.DocumentElement
        End Function 'Encrypt
        '</Snippet3> 

        '<Snippet2> 
        ' Performs decryption.
        Public Overrides Function Decrypt( _
        ByVal encryptedNode As XmlNode) As XmlNode
            Dim decryptedData As String = _
            DecryptString(encryptedNode.InnerText)

            Dim xmlDoc As New XmlDocument()
            xmlDoc.PreserveWhitespace = True
            xmlDoc.LoadXml(decryptedData)

            Return xmlDoc.DocumentElement
        End Function 'Decrypt
        '</Snippet2> 



        ' Encrypts a configuration section and returns 
        ' the encrypted XML as a string.
        Private Function EncryptString( _
        ByVal encryptValue As String) As String
            Dim valBytes As Byte() = _
            Encoding.Unicode.GetBytes(encryptValue)

            Dim transform As ICryptoTransform = _
            des.CreateEncryptor()

            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, _
            transform, CryptoStreamMode.Write)
            cs.Write(valBytes, 0, valBytes.Length)
            cs.FlushFinalBlock()
            Dim returnBytes As Byte() = ms.ToArray()
            cs.Close()

            Return Convert.ToBase64String(returnBytes)
        End Function 'EncryptString



        ' Decrypts an encrypted configuration section and 
        ' returns the unencrypted XML as a string.
        Private Function DecryptString( _
        ByVal encryptedValue As String) As String
            Dim valBytes As Byte() = _
            Convert.FromBase64String(encryptedValue)

            Dim transform As ICryptoTransform = _
            des.CreateDecryptor()

            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, _
            transform, CryptoStreamMode.Write)
            cs.Write(valBytes, 0, valBytes.Length)
            cs.FlushFinalBlock()
            Dim returnBytes As Byte() = ms.ToArray()
            cs.Close()

            Return Encoding.Unicode.GetString(returnBytes)
        End Function 'DecryptString


        ' Generates a new TripleDES key and vector and 
        ' writes them to the supplied file path.
        Public Sub CreateKey(ByVal filePath As String)
            des.GenerateKey()
            des.GenerateIV()

            Dim sw As New StreamWriter(filePath, False)
            sw.WriteLine(ByteToHex(des.Key))
            sw.WriteLine(ByteToHex(des.IV))
            sw.Close()
        End Sub 'CreateKey



        ' Reads in the TripleDES key and vector from 
        ' the supplied file path and sets the Key 
        ' and IV properties of the 
        ' TripleDESCryptoServiceProvider.
        Private Sub ReadKey(ByVal filePath As String)
            Dim sr As New StreamReader(filePath)
            Dim keyValue As String = sr.ReadLine()
            Dim ivValue As String = sr.ReadLine()
            des.Key = HexToByte(keyValue)
            des.IV = HexToByte(ivValue)
        End Sub 'ReadKey



        ' Converts a byte array to a hexadecimal string.
        Private Function ByteToHex( _
        ByVal byteArray() As Byte) As String
            Dim outString As String = ""

            Dim b As [Byte]
            For Each b In byteArray
                outString += b.ToString("X2")
            Next b
            Return outString
        End Function 'ByteToHex


        ' Converts a hexadecimal string to a byte array.
        Private Function HexToByte(ByVal hexString As String) As Byte()
            Dim returnBytes(hexString.Length / 2) As Byte
            Dim i As Integer
            For i = 0 To returnBytes.Length - 1
                returnBytes(i) = _
                Convert.ToByte(hexString.Substring(i * 2, 2), 16)
            Next i
            Return returnBytes
        End Function 'HexToByte
    End Class 'TripleDESProtectedConfigurationProvider 

End Namespace

' </Snippet1>
