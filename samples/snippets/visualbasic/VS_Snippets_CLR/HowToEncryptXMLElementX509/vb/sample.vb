' <snippet1>
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates

Module Program

    Sub Main(ByVal args() As String)
        Try
            ' Create an XmlDocument object.
            ' <snippet7>
            Dim xmlDoc As New XmlDocument()
            ' </snippet7>
            ' Load an XML file into the XmlDocument object.
            xmlDoc.PreserveWhitespace = True
            xmlDoc.Load("test.xml")

            ' Open the X.509 "Current User" store in read only mode.
            ' <snippet2>
            Dim store As New X509Store(StoreLocation.CurrentUser)
            ' </snippet2>
            ' <snippet3>
            store.Open(OpenFlags.ReadOnly)
            ' </snippet3>
            ' Place all certificates in an X509Certificate2Collection object.
            ' <snippet4>
            Dim certCollection As X509Certificate2Collection = store.Certificates
            ' </snippet4>
            ' <snippet5>
            Dim cert As X509Certificate2 = Nothing

            ' Loop through each certificate and find the certificate 
            ' with the appropriate name.
            Dim c As X509Certificate2
            For Each c In certCollection
                If c.Subject = "CN=XML_ENC_TEST_CERT" Then
                    cert = c

                    Exit For
                End If
            Next c
            ' </snippet5>
            If cert Is Nothing Then
                Throw New CryptographicException("The X.509 certificate could not be found.")
            End If

            ' Close the store.
            ' <snippet6>
            store.Close()
            ' </snippet6>
            ' Encrypt the "creditcard" element.
            Encrypt(xmlDoc, "creditcard", cert)

            ' Save the XML document.
            ' <snippet11>
            xmlDoc.Save("test.xml")
            ' </snippet11>
            ' Display the encrypted XML to the console.
            Console.WriteLine("Encrypted XML:")
            Console.WriteLine()
            Console.WriteLine(xmlDoc.OuterXml)

        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

    End Sub


    Sub Encrypt(ByVal Doc As XmlDocument, ByVal ElementToEncryptName As String, ByVal Cert As X509Certificate2)
        ' Check the arguments.  
        ArgumentNullException.ThrowIfNull(Doc)
        ArgumentNullException.ThrowIfNull(ElementToEncryptName)
        ArgumentNullException.ThrowIfNull(Cert)
        ''''''''''''''''''''''''''''''''''''''''''''''''
        ' Find the specified element in the XmlDocument
        ' object and create a new XmlElemnt object.
        ''''''''''''''''''''''''''''''''''''''''''''''''
        ' <snippet8>
        Dim elementToEncrypt As XmlElement = Doc.GetElementsByTagName(ElementToEncryptName)(0)

        ' </snippet8>
        ' Throw an XmlException if the element was not found.
        If elementToEncrypt Is Nothing Then
            Throw New XmlException("The specified element was not found")
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''
        ' Create a new instance of the EncryptedXml class 
        ' and use it to encrypt the XmlElement with the 
        ' X.509 Certificate.
        ''''''''''''''''''''''''''''''''''''''''''''''''
        ' <snippet9>
        Dim eXml As New EncryptedXml()

        ' Encrypt the element.
        Dim edElement As EncryptedData = eXml.Encrypt(elementToEncrypt, Cert)
        ' </snippet9>
        ''''''''''''''''''''''''''''''''''''''''''''''''
        ' Replace the element from the original XmlDocument
        ' object with the EncryptedData element.
        ''''''''''''''''''''''''''''''''''''''''''''''''
        ' <snippet10>
        EncryptedXml.ReplaceElement(elementToEncrypt, edElement, False)
        ' </snippet10>
    End Sub
End Module
' </snippet1>
