' <snippet1>
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml

Class Program

    Shared Sub Main(ByVal args() As String)
        ' <snippet4>
        ' Create an XmlDocument object.
        Dim xmlDoc As New XmlDocument()

        ' Load an XML file into the XmlDocument object.
        Try
            xmlDoc.PreserveWhitespace = True
            xmlDoc.Load("test.xml")
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
        ' </snippet4>
        ' Create a new CspParameters object to specify
        ' a key container.
        ' <snippet2>
        Dim cspParams As New CspParameters()
        cspParams.KeyContainerName = "XML_ENC_RSA_KEY"
        ' </snippet2>
        ' Create a new RSA key and save it in the container.  This key will encrypt
        ' a symmetric key, which will then be encryped in the XML document.
        ' <snippet3>
        Dim rsaKey As New RSACryptoServiceProvider(cspParams)
        ' </snippet3>
        Try
            ' Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", "EncryptedElement1", rsaKey, "rsaKey")


            ' Save the XML document.
            ' <snippet16>
            xmlDoc.Save("test.xml")
            ' </snippet16>
            ' Display the encrypted XML to the console.
            Console.WriteLine("Encrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlDoc.OuterXml)
            Decrypt(xmlDoc, rsaKey, "rsaKey")
            xmlDoc.Save("test.xml")
            ' Display the encrypted XML to the console.
            Console.WriteLine()
            Console.WriteLine("Decrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlDoc.OuterXml)

        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            ' Clear the RSA key.
            rsaKey.Clear()
        End Try


        Console.ReadLine()

    End Sub


    Public Shared Sub Encrypt(ByVal Doc As XmlDocument, ByVal EncryptionElement As String, ByVal EncryptionElementID As String, ByVal Alg As RSA, ByVal KeyName As String)
        ' Check the arguments.
        ArgumentNullException.ThrowIfNull(Doc)
        ArgumentNullException.ThrowIfNull(EncryptionElement)
        ArgumentNullException.ThrowIfNull(EncryptionElementID)
        ArgumentNullException.ThrowIfNull(Alg)
        ArgumentNullException.ThrowIfNull(KeyName)
        '//////////////////////////////////////////////
        ' Find the specified element in the XmlDocument
        ' object and create a new XmlElement object.
        '//////////////////////////////////////////////
        ' <snippet5>
        Dim elementToEncrypt As XmlElement = Doc.GetElementsByTagName(EncryptionElement)(0)

        ' Throw an XmlException if the element was not found.
        If elementToEncrypt Is Nothing Then
            Throw New XmlException("The specified element was not found")
        End If
        ' </snippet5>
        Dim sessionKey As Aes = Nothing

        Try
            '////////////////////////////////////////////////
            ' Create a new instance of the EncryptedXml class
            ' and use it to encrypt the XmlElement with the
            ' a new random symmetric key.
            '////////////////////////////////////////////////
            ' <snippet6>
            ' Create an AES key.
            sessionKey = Aes.Create()
            ' </snippet6>
            ' <snippet7>
            Dim eXml As New EncryptedXml()

            Dim encryptedElement As Byte() = eXml.EncryptData(elementToEncrypt, sessionKey, False)
            ' </snippet7>
            '//////////////////////////////////////////////
            ' Construct an EncryptedData object and populate
            ' it with the desired encryption information.
            '//////////////////////////////////////////////
            ' <snippet8>
            Dim edElement As New EncryptedData()
            edElement.Type = EncryptedXml.XmlEncElementUrl
            edElement.Id = EncryptionElementID
            ' </snippet8>
            ' Create an EncryptionMethod element so that the
            ' receiver knows which algorithm to use for decryption.
            ' <snippet9>
            edElement.EncryptionMethod = New EncryptionMethod(EncryptedXml.XmlEncAES256Url)
            ' </snippet9>
            ' Encrypt the session key and add it to an EncryptedKey element.
            ' <snippet10>
            Dim ek As New EncryptedKey()

            Dim encryptedKey As Byte() = EncryptedXml.EncryptKey(sessionKey.Key, Alg, False)

            ek.CipherData = New CipherData(encryptedKey)

            ek.EncryptionMethod = New EncryptionMethod(EncryptedXml.XmlEncRSA15Url)
            ' </snippet10>
            ' Create a new DataReference element
            ' for the KeyInfo element.  This optional
            ' element specifies which EncryptedData
            ' uses this key.  An XML document can have
            ' multiple EncryptedData elements that use
            ' different keys.
            ' <snippet11>
            Dim dRef As New DataReference()

            ' Specify the EncryptedData URI.
            dRef.Uri = "#" + EncryptionElementID

            ' Add the DataReference to the EncryptedKey.
            ek.AddReference(dRef)
            ' </snippet11>
            ' Add the encrypted key to the
            ' EncryptedData object.
            ' <snippet12>
            edElement.KeyInfo.AddClause(New KeyInfoEncryptedKey(ek))
            ' </snippet12>
            ' Set the KeyInfo element to specify the
            ' name of the RSA key.
            ' <snippet13>
            ' Create a new KeyInfoName element.
            Dim kin As New KeyInfoName()

            ' Specify a name for the key.
            kin.Value = KeyName

            ' Add the KeyInfoName element to the
            ' EncryptedKey object.
            ek.KeyInfo.AddClause(kin)
            ' </snippet13>
            ' Add the encrypted element data to the
            ' EncryptedData object.
            ' <snippet14>
            edElement.CipherData.CipherValue = encryptedElement
            ' </snippet14>
            '//////////////////////////////////////////////////
            ' Replace the element from the original XmlDocument
            ' object with the EncryptedData element.
            '//////////////////////////////////////////////////
            ' <snippet15>
            EncryptedXml.ReplaceElement(elementToEncrypt, edElement, False)
            ' </snippet15>
        Catch e As Exception
            ' re-throw the exception.
            Throw
        Finally
            If Not (sessionKey Is Nothing) Then
                sessionKey.Clear()
            End If
        End Try

    End Sub



    Public Shared Sub Decrypt(ByVal Doc As XmlDocument, ByVal Alg As RSA, ByVal KeyName As String)
        ' Check the arguments.  
        ArgumentNullException.ThrowIfNull(Doc)
        ArgumentNullException.ThrowIfNull(Alg)
        ArgumentNullException.ThrowIfNull(KeyName)
        ' Create a new EncryptedXml object.
        Dim exml As New EncryptedXml(Doc)

        ' Add a key-name mapping.
        ' This method can only decrypt documents
        ' that present the specified key name.
        exml.AddKeyNameMapping(KeyName, Alg)

        ' Decrypt the element.
        exml.DecryptDocument()

    End Sub
End Class


' </Snippet1>
