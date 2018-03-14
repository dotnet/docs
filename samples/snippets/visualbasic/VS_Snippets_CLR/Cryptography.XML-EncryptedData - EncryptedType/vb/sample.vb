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

        ' Create a new TripleDES key. 
        Dim tDESkey As New TripleDESCryptoServiceProvider()


        Try
            ' Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", tDESkey)

            ' Display the encrypted XML to the console.
            Console.WriteLine("Encrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlDoc.OuterXml)

            ' Decrypt the "creditcard" element.
            Decrypt(xmlDoc, tDESkey)

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

    End Sub


    Sub Encrypt(ByVal Doc As XmlDocument, ByVal ElementToEncryptString As String, ByVal Alg As TripleDESCryptoServiceProvider)

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Find the specified element in the XmlDocument
        ' object and create a new XmlElemnt object.
        ''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim elementToEncrypt As XmlElement = Doc.GetElementsByTagName(ElementToEncryptString)(0)


        ' Throw an XmlException if the element was not found.
        If elementToEncrypt Is Nothing Then
            Throw New XmlException("The specified element was not found")
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Create a new instance of the EncryptedXml class 
        ' and use it to encrypt the XmlElement with the 
        ' symmetric key.
        ''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim eXml As New EncryptedXml()

        Dim encryptedElement As Byte() = eXml.EncryptData(elementToEncrypt, Alg, False)

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Construct an EncryptedData object and populate
        ' it with the desired encryption information.
        ''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim edElement As New EncryptedData()

        edElement.Type = EncryptedXml.XmlEncElementUrl


        ' Create an EncryptionMethod element so that the 
        ' receiver knows which algorithm to use for decryption.
        ' Determine what kind of algorithm is being used and
        ' supply the appropriate URL to the EncryptionMethod element.
        edElement.EncryptionMethod = New EncryptionMethod(EncryptedXml.XmlEncTripleDESUrl)

        ' Add the encrypted element data to the 
        ' EncryptedData object.
        edElement.CipherData.CipherValue = encryptedElement

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Replace the element from the original XmlDocument
        ' object with the EncryptedData element.
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        EncryptedXml.ReplaceElement(elementToEncrypt, edElement, False)

    End Sub


    Sub Decrypt(ByVal Doc As XmlDocument, ByVal Alg As SymmetricAlgorithm)

        ' Find the EncryptedData element in the XmlDocument.
        Dim encryptedElement As XmlElement = Doc.GetElementsByTagName("EncryptedData")(0) 
   

        ' If the EncryptedData element was not found, throw an exception.
        If encryptedElement Is Nothing Then
            Throw New XmlException("The EncryptedData element was not found.")
        End If

        ' Create an EncryptedData object and populate it.
        Dim edElement As New EncryptedData()
        edElement.LoadXml(encryptedElement)

        ' Create a new EncryptedXml object.
        Dim exml As New EncryptedXml()

        ' Decrypt the element using the symmetric key.
        Dim rgbOutput As Byte() = exml.DecryptData(edElement, Alg)

        ' Replace the encryptedData element with the plaintext XML element.
        exml.ReplaceData(encryptedElement, rgbOutput)

    End Sub
End Module

'</snippet1>