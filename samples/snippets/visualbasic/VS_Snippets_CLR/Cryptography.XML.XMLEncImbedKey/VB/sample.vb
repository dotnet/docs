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

        ' Create a new RSA key.  This key will encrypt a symmetric key,
        ' which will then be imbedded in the XML document.  
        Dim rsaKey = New RSACryptoServiceProvider()


        Try
            ' Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", rsaKey, "rsaKey")

            ' Display the encrypted XML to the console.
            Console.WriteLine("Encrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlDoc.OuterXml)
            xmlDoc.Save("test.xml")

            ' Decrypt the "creditcard" element.
            Decrypt(xmlDoc, rsaKey, "rsaKey")

            ' Display the encrypted XML to the console.
            Console.WriteLine()
            Console.WriteLine("Decrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlDoc.OuterXml)
            xmlDoc.Save("test.xml")
        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            ' Clear the RSA key.
            rsaKey.Clear()
        End Try

    End Sub


    Sub Encrypt(ByVal Doc As XmlDocument, ByVal ElementToEncrypt As String, ByVal Alg As RSA, ByVal KeyName As String)
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
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Find the specified element in the XmlDocument
        ' object and create a new XmlElemnt object.
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim elementEncrypt As XmlElement = Doc.GetElementsByTagName(ElementToEncrypt)(0)

        ' Throw an XmlException if the element was not found.
        If elementToEncrypt Is Nothing Then
            Throw New XmlException("The specified element was not found")
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Create a new instance of the EncryptedXml class 
        ' and use it to encrypt the XmlElement with the 
        ' a new random symmetric key.
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Create a 256 bit Rijndael key.
        Dim sessionKey As New RijndaelManaged()
        sessionKey.KeySize = 256

        Dim eXml As New EncryptedXml()

        Dim encryptedElement As Byte() = eXml.EncryptData(elementEncrypt, sessionKey, False)

        '''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Construct an EncryptedData object and populate
        ' it with the desired encryption information.
        '''''''''''''''''''''''''''''''''''''''''''''''''''

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

        '''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Replace the element from the original XmlDocument
        ' object with the EncryptedData element.
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        EncryptedXml.ReplaceElement(elementEncrypt, edElement, False)

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
End Module
'</SNIPPET1>