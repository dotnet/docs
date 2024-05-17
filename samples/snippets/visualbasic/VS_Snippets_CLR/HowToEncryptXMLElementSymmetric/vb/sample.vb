'<snippet1>
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml

Module Program

    Sub Main(ByVal args() As String)
        '<snippet2>
        Dim key As Aes = Nothing

        Try
            ' Create a new Aes key.
            key = Aes.Create()
            '</snippet2>
            '<snippet3>
            ' Load an XML document.
            Dim xmlDoc As New XmlDocument()
            xmlDoc.PreserveWhitespace = True
            xmlDoc.Load("test.xml")
            '</snippet3>
            ' Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", key)

            Console.WriteLine("The element was encrypted")
            Console.WriteLine(xmlDoc.InnerXml)

            Decrypt(xmlDoc, key)

            Console.WriteLine("The element was decrypted")
            Console.WriteLine(xmlDoc.InnerXml)


        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            ' Clear the key.
            If Not (key Is Nothing) Then
                key.Clear()
            End If
        End Try

    End Sub


    Sub Encrypt(ByVal Doc As XmlDocument, ByVal ElementName As String, ByVal Key As SymmetricAlgorithm)
        ' Check the arguments.  
        ArgumentNullException.ThrowIfNull(Doc)
        ArgumentNullException.ThrowIfNull(ElementName)
        ArgumentNullException.ThrowIfNull(Key)

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Find the specified element in the XmlDocument
        ' object and create a new XmlElemnt object.
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        '<snippet4>
        Dim elementToEncrypt As XmlElement = Doc.GetElementsByTagName(ElementName)(0)
        '</snippet4>

        ' Throw an XmlException if the element was not found.
        If elementToEncrypt Is Nothing Then
            Throw New XmlException("The specified element was not found")
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Create a new instance of the EncryptedXml class 
        ' and use it to encrypt the XmlElement with the 
        ' symmetric key.
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        '<snippet5>
        Dim eXml As New EncryptedXml()

        Dim encryptedElement As Byte() = eXml.EncryptData(elementToEncrypt, Key, False)
        '</snippet5>
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Construct an EncryptedData object and populate
        ' it with the desired encryption information.
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        '<snippet6>
        Dim edElement As New EncryptedData()
        edElement.Type = EncryptedXml.XmlEncElementUrl
        '</snippet6>
        ' Create an EncryptionMethod element so that the 
        ' receiver knows which algorithm to use for decryption.
        ' Determine what kind of algorithm is being used and
        ' supply the appropriate URL to the EncryptionMethod element.
        '<snippet7>
        Dim encryptionMethod As String = Nothing

        If TypeOf Key Is Aes Then
            encryptionMethod = EncryptedXml.XmlEncAES256Url
        Else
            ' Throw an exception if the transform is not in the previous categories
            Throw New CryptographicException("The specified algorithm is not supported or not recommended for XML Encryption.")
        End If

        edElement.EncryptionMethod = New EncryptionMethod(encryptionMethod)
        '</snippet7>
        ' Add the encrypted element data to the 
        ' EncryptedData object.
        '<snippet8>
        edElement.CipherData.CipherValue = encryptedElement
        '</snippet8>
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Replace the element from the original XmlDocument
        ' object with the EncryptedData element.
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        '<snippet9>
        EncryptedXml.ReplaceElement(elementToEncrypt, edElement, False)
        '</snippet9>

    End Sub


    Sub Decrypt(ByVal Doc As XmlDocument, ByVal Alg As SymmetricAlgorithm)
        ' Check the arguments.  
        If Doc Is Nothing Then
            Throw New ArgumentNullException("Doc")
        End If
        If Alg Is Nothing Then
            Throw New ArgumentNullException("Alg")
        End If
        ' Find the EncryptedData element in the XmlDocument.
        ' <snippet10>
        Dim encryptedElement As XmlElement = Doc.GetElementsByTagName("EncryptedData")(0)
        ' </snippet10>

        ' If the EncryptedData element was not found, throw an exception.
        If encryptedElement Is Nothing Then
            Throw New XmlException("The EncryptedData element was not found.")
        End If


        ' Create an EncryptedData object and populate it.
        ' <snippet11>
        Dim edElement As New EncryptedData()
        edElement.LoadXml(encryptedElement)
        ' </snippet11>
        ' Create a new EncryptedXml object.
        ' <snippet12>
        Dim exml As New EncryptedXml()


        ' Decrypt the element using the symmetric key.
        Dim rgbOutput As Byte() = exml.DecryptData(edElement, Alg)
        ' </snippet12>
        ' Replace the encryptedData element with the plaintext XML element.
        ' <snippet13>
        exml.ReplaceData(encryptedElement, rgbOutput)
        ' </snippet13>
    End Sub
End Module

'</snippet1>
