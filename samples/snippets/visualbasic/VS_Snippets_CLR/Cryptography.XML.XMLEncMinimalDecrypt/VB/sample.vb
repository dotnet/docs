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
        End Try

        ' Create a new TripleDES key. 
        Dim tDESkey As New TripleDESCryptoServiceProvider()


        Try
            ' Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", tDESkey, "tDesKey")

            ' Display the encrypted XML to the console.
            Console.WriteLine("Encrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlDoc.OuterXml)

            ' Decrypt the "creditcard" element.
            Decrypt(xmlDoc, tDESkey, "tDesKey")

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
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Find the specified element in the XmlDocument
        ' object and create a new XmlElemnt object.
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim elementEncrypt As XmlElement = Doc.GetElementsByTagName(ElementToEncrypt)(0) 


        ' Throw an XmlException if the element was not found.
        If ElementToEncrypt Is Nothing Then
            Throw New XmlException("The specified element was not found")
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Create a new instance of the EncryptedXml class 
        ' and use it to encrypt the XmlElement with the 
        ' symmetric key.
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim eXml As New EncryptedXml()

        ' Add the key mapping.
        eXml.AddKeyNameMapping(KeyName, Alg)

        ' Encrypt the element.
        Dim edElement As EncryptedData = eXml.Encrypt(elementEncrypt, KeyName)


        '''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Replace the element from the original XmlDocument
        ' object with the EncryptedData element.
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        EncryptedXml.ReplaceElement(elementEncrypt, edElement, False)

    End Sub 'Encrypt


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

        ' Add the key name mapping.
        exml.AddKeyNameMapping(KeyName, Alg)

        ' Decrypt the XML document.
        exml.DecryptDocument()

    End Sub
End Module

'</SNIPPET1>