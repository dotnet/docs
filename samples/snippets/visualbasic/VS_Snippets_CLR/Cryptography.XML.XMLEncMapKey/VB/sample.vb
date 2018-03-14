'<SNIPPET1>
Imports System
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml



Module Program

    Sub Main(ByVal args() As String)

        ' Create an XmlDocument object.
        Dim xmlDoc As New XmlDocument()

        ' Load an XML file into the XmlDocument object.
        Try
            xmlDoc.PreserveWhitespace = True
            xmlDoc.Load("test.xml")
        Catch e As Exception
            Console.WriteLine(e.Message)
            Return
        End Try

        ' Create a new TripleDES key. 
        Dim tDESkey As New TripleDESCryptoServiceProvider()


        Try
            ' Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", tDESkey, "tDESKey")

            ' Display the encrypted XML to the console.
            Console.WriteLine("Encrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlDoc.OuterXml)

            ' Decrypt the "creditcard" element.
            Decrypt(xmlDoc, tDESkey, "tDESKey")

            ' Display the encrypted XML to the console.
            Console.WriteLine()
            Console.WriteLine("Decrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlDoc.OuterXml)
        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            ' Clear the TripleDES key.
            tDESkey.Clear()
        End Try

    End Sub 'Main


    Sub Encrypt(ByVal Doc As XmlDocument, ByVal ElementToEncrypt As String, ByVal Alg As SymmetricAlgorithm, ByVal KeyName As String)
        ' Check the arguments.  
        If Doc Is Nothing Then
            Throw New ArgumentNullException("Doc")
        End If
        If ElementToEncrypt Is Nothing Then
            Throw New ArgumentNullException("ElementToEncrypt")
        End If
        If Alg Is Nothing Then
            Throw New ArgumentNullException("Alg")
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''
        ' Find the specified element in the XmlDocument
        ' object and create a new XmlElemnt object.
        '''''''''''''''''''''''''''''''''''''''''''''''''
        Dim elementEncrypt As XmlElement = Doc.GetElementsByTagName(ElementToEncrypt)(0)
 

        ' Throw an XmlException if the element was not found.
        If elementToEncrypt Is Nothing Then
            Throw New XmlException("The specified element was not found")
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''
        ' Create a new instance of the EncryptedXml class 
        ' and use it to encrypt the XmlElement with the 
        ' symmetric key.
        '''''''''''''''''''''''''''''''''''''''''''''''''
        Dim eXml As New EncryptedXml()

        Dim encryptedElement As Byte() = eXml.EncryptData(elementEncrypt, Alg, False)

        '''''''''''''''''''''''''''''''''''''''''''''''''
        ' Construct an EncryptedData object and populate
        ' it with the desired encryption information.
        '''''''''''''''''''''''''''''''''''''''''''''''''

        Dim edElement As New EncryptedData()
        edElement.Type = EncryptedXml.XmlEncElementUrl

        ' Create an EncryptionMethod element so that the 
        ' receiver knows which algorithm to use for decryption.
        ' Determine what kind of algorithm is being used and
        ' supply the appropriate URL to the EncryptionMethod element.
        Dim encryptionMethod As String = Nothing

        If TypeOf Alg Is TripleDES Then
            encryptionMethod = EncryptedXml.XmlEncTripleDESUrl
        ElseIf TypeOf Alg Is DES Then
            encryptionMethod = EncryptedXml.XmlEncDESUrl
        ElseIf TypeOf Alg Is Rijndael Then
            Select Case Alg.KeySize
                Case 128
                    encryptionMethod = EncryptedXml.XmlEncAES128Url
                Case 192
                    encryptionMethod = EncryptedXml.XmlEncAES192Url
                Case 256
                    encryptionMethod = EncryptedXml.XmlEncAES256Url
            End Select
        Else
            ' Throw an exception if the transform is not in the previous categories
            Throw New CryptographicException("The specified algorithm is not supported for XML Encryption.")
        End If

        edElement.EncryptionMethod = New EncryptionMethod(encryptionMethod)

        ' Set the KeyInfo element to specify the
        ' name of a key.
        ' Create a new KeyInfo element.
        edElement.KeyInfo = New KeyInfo()

        ' Create a new KeyInfoName element.
        Dim kin As New KeyInfoName()

        ' Specify a name for the key.
        kin.Value = KeyName

        ' Add the KeyInfoName element.
        edElement.KeyInfo.AddClause(kin)

        ' Add the encrypted element data to the 
        ' EncryptedData object.
        edElement.CipherData.CipherValue = encryptedElement

        '''''''''''''''''''''''''''''''''''''''''''''''''
        ' Replace the element from the original XmlDocument
        ' object with the EncryptedData element.
        '''''''''''''''''''''''''''''''''''''''''''''''''
        EncryptedXml.ReplaceElement(elementEncrypt, edElement, False)

    End Sub


    Sub Decrypt(ByVal Doc As XmlDocument, ByVal Alg As SymmetricAlgorithm, ByVal KeyName As String)
        ' Check the arguments.  
        If Doc Is Nothing Then
            Throw New ArgumentNullException("Doc")
        End If
        If Alg Is Nothing Then
            Throw New ArgumentNullException("Alg")
        End If
        If KeyName Is Nothing Then
            Throw New ArgumentNullException("KeyName")
        End If
        ' Create a new EncryptedXml object.
        Dim exml As New EncryptedXml(Doc)

        ' Add a key-name mapping.
        ' This method can only decrypt documents
        ' that present the specified key name.
        exml.AddKeyNameMapping(KeyName, Alg)

        ' Decrypt the element.
        exml.DecryptDocument()

    End Sub
End Module
'</SNIPPET1>
