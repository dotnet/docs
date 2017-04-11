'<snippet1>
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
        End Try

        ' Create a new RSA key.  This key will encrypt a symmetric key,
        ' which will then be imbedded in the XML document.  
        Dim rsaKey As New RSACryptoServiceProvider()


        Try
            ' Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", rsaKey, "rsaKey")

            ' Inspect the EncryptedKey element.
            InspectElement(xmlDoc)

            ' Decrypt the "creditcard" element.
            Decrypt(xmlDoc, rsaKey, "rsaKey")

        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            ' Clear the RSA key.
            rsaKey.Clear()
        End Try

    End Sub


    Sub Encrypt(ByVal Doc As XmlDocument, ByVal ElementToEncryptParam As String, ByVal Alg As RSA, ByVal KeyName As String)
        ' Check the arguments.  
        If Doc Is Nothing Then
            Throw New ArgumentNullException("Doc")
        End If
        If ElementToEncryptParam Is Nothing Then
            Throw New ArgumentNullException("ElementToEncrypt")
        End If
        If Alg Is Nothing Then
            Throw New ArgumentNullException("Alg")
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''
        ' Find the specified element in the XmlDocument
        ' object and create a new XmlElemnt object.
        ''''''''''''''''''''''''''''''''''''''''''''''''
        Dim elementToEncrypt As XmlElement = Doc.GetElementsByTagName(ElementToEncryptParam)(0)


        ' Throw an XmlException if the element was not found.
        If elementToEncrypt Is Nothing Then
            Throw New XmlException("The specified element was not found")
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''
        ' Create a new instance of the EncryptedXml class 
        ' and use it to encrypt the XmlElement with the 
        ' a new random symmetric key.
        ''''''''''''''''''''''''''''''''''''''''''''''''
        ' Create a 256 bit Rijndael key.
        Dim sessionKey As New RijndaelManaged()
        sessionKey.KeySize = 256

        Dim eXml As New EncryptedXml()

        Dim encryptedElement As Byte() = eXml.EncryptData(elementToEncrypt, sessionKey, False)

        ''''''''''''''''''''''''''''''''''''''''''''''''
        ' Construct an EncryptedData object and populate
        ' it with the desired encryption information.
        ''''''''''''''''''''''''''''''''''''''''''''''''

        Dim edElement As New EncryptedData()
        edElement.Type = EncryptedXml.XmlEncElementUrl

        ' Create an EncryptionMethod element so that the 
        ' receiver knows which algorithm to use for decryption.
        edElement.EncryptionMethod = New EncryptionMethod(EncryptedXml.XmlEncAES256Url)

        ' Encrypt the session key and add it to an EncryptedKey element.
        Dim ek As New EncryptedKey()

        Dim encryptedKey As Byte() = EncryptedXml.EncryptKey(sessionKey.Key, Alg, False)

        ek.CipherData = New CipherData(encryptedKey)

        ek.EncryptionMethod = New EncryptionMethod(EncryptedXml.XmlEncRSA15Url)

        ' Set the KeyInfo element to specify the
        ' name of the RSA key.
        ' Create a new KeyInfo element.
        edElement.KeyInfo = New KeyInfo()

        ' Create a new KeyInfoName element.
        Dim kin As New KeyInfoName()

        ' Specify a name for the key.
        kin.Value = KeyName

        ' Add the KeyInfoName element to the 
        ' EncryptedKey object.
        ek.KeyInfo.AddClause(kin)

        ' Add the encrypted key to the 
        ' EncryptedData object.
        edElement.KeyInfo.AddClause(New KeyInfoEncryptedKey(ek))

        ' Add the encrypted element data to the 
        ' EncryptedData object.
        edElement.CipherData.CipherValue = encryptedElement

        ''''''''''''''''''''''''''''''''''''''''''''''''
        ' Replace the element from the original XmlDocument
        ' object with the EncryptedData element.
        ''''''''''''''''''''''''''''''''''''''''''''''''
        EncryptedXml.ReplaceElement(elementToEncrypt, edElement, False)

    End Sub


    Sub Decrypt(ByVal Doc As XmlDocument, ByVal Alg As RSA, ByVal KeyName As String)
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


    Sub InspectElement(ByVal Doc As XmlDocument)
        ' Get the EncryptedData element from the XMLDocument object.
        Dim encryptedData As XmlElement = Doc.GetElementsByTagName("EncryptedData")(0)

        ' Create a new EncryptedData object.
        Dim encData As New EncryptedData()

        ' Load the XML from the document to
        ' initialize the EncryptedData object.
        encData.LoadXml(encryptedData)

        ' Display the properties.
        ' Most values are Null by default.


        Console.WriteLine("EncryptedData.CipherData: " + encData.CipherData.GetXml().InnerXml)
        Console.WriteLine("EncryptedData.Encoding: " + encData.Encoding)
        Console.WriteLine("EncryptedData.EncryptionMethod: " + encData.EncryptionMethod.GetXml().InnerXml)
        If encData.EncryptionProperties.Count >= 1 Then
            Console.WriteLine("EncryptedData.EncryptionProperties: " + encData.EncryptionProperties(0).GetXml().InnerXml)
        End If

        Console.WriteLine("EncryptedData.Id: " + encData.Id)
        Console.WriteLine("EncryptedData.KeyInfo: " + encData.KeyInfo.GetXml().InnerXml)
        Console.WriteLine("EncryptedData.MimeType: " + encData.MimeType)

    End Sub
End Module
'</snippet1>