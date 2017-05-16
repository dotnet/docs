'<SNIPPET1>
Imports System
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates



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

        ' Create a new X509Certificate2 object by loading
        ' an X.509 certificate file.  To use XML encryption 
        ' with an X.509 certificate, use an X509Certificate2 
        ' object to encrypt, but use a certificate in a certificate
        ' store to decrypt.
        ' You can create a new test certificate file using the 
        ' makecert.exe tool.
        ' Create an X509Certificate2 object for encryption.
        Dim cert As New X509Certificate2("test.pfx")

        ' Put the certificate in certificate store for decryption.  
        Dim store As New X509Store(StoreLocation.CurrentUser)

        store.Open(OpenFlags.ReadWrite)

        store.Add(cert)

        store.Close()


        Try
            ' Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", cert)

            ' Display the encrypted XML to the console.
            Console.WriteLine("Encrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlDoc.OuterXml)

            ' Decrypt the "creditcard" element.
            Decrypt(xmlDoc)

            ' Display the encrypted XML to the console.
            Console.WriteLine()
            Console.WriteLine("Decrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlDoc.OuterXml)
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

    End Sub


    Sub Encrypt(ByVal Doc As XmlDocument, ByVal ElementToEncrypt As String, ByVal Cert As X509Certificate2)
        ' Check the arguments.  
        If Doc Is Nothing Then
            Throw New ArgumentNullException("Doc")
        End If
        If ElementToEncrypt Is Nothing Then
            Throw New ArgumentNullException("ElementToEncrypt")
        End If
        If Cert Is Nothing Then
            Throw New ArgumentNullException("Cert")
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
        ' X.509 Certificate.
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim eXml As New EncryptedXml()

        ' Encrypt the element.
        Dim edElement As EncryptedData = eXml.Encrypt(elementEncrypt, Cert)


        '''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Replace the element from the original XmlDocument
        ' object with the EncryptedData element.
        '''''''''''''''''''''''''''''''''''''''''''''''''''
        EncryptedXml.ReplaceElement(elementEncrypt, edElement, False)

    End Sub


    Sub Decrypt(ByVal Doc As XmlDocument)
        ' Check the arguments.  
        If Doc Is Nothing Then
            Throw New ArgumentNullException("Doc")
        End If
        ' Create a new EncryptedXml object.
        Dim exml As New EncryptedXml(Doc)

        ' Decrypt the XML document.
        exml.DecryptDocument()

    End Sub
End Module

'</SNIPPET1>