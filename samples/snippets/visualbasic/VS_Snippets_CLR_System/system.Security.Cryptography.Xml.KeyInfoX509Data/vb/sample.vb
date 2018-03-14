' <Snippet1>
'
' This example signs an XML file using an
' envelope signature. It then verifies the 
' signed XML.
'
' You must have a certificate with a subject name
' of "CN=XMLDSIG_Test" in the "My" certificate store. 
'
' Run the following command to create a certificate
' and place it in the store.
' makecert -r -pe -n "CN=XMLDSIG_Test" -b 01/01/2005 -e 01/01/2010 -sky signing -ss my
Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Xml



Module SignVerifyEnvelope


    Sub Main(ByVal args() As String)

        Dim Certificate As String = "CN=XMLDSIG_Test"

        Try

            ' Create an XML file to sign.
            CreateSomeXml("Example.xml")
            Console.WriteLine("New XML file created.")

            ' Sign the XML that was just created and save it in a 
            ' new file.
            SignXmlFile("Example.xml", "SignedExample.xml", Certificate)
            Console.WriteLine("XML file signed.")

            If VerifyXmlFile("SignedExample.xml", Certificate) Then
                Console.WriteLine("The XML signature is valid.")
            Else
                Console.WriteLine("The XML signature is not valid.")
            End If
        Catch e As CryptographicException
            Console.WriteLine(e.Message)
        End Try

    End Sub


    ' <Snippet2>
    ' Sign an XML file and save the signature in a new file.
    Sub SignXmlFile(ByVal FileName As String, ByVal SignedFileName As String, ByVal SubjectName As String)
        If Nothing = FileName Then
            Throw New ArgumentNullException("FileName")
        End If
        If Nothing = SignedFileName Then
            Throw New ArgumentNullException("SignedFileName")
        End If
        If Nothing = SubjectName Then
            Throw New ArgumentNullException("SubjectName")
        End If
        ' Load the certificate from the certificate store.
        Dim cert As X509Certificate2 = GetCertificateBySubject(SubjectName)

        ' Create a new XML document.
        Dim doc As New XmlDocument()

        ' Format the document to ignore white spaces.
        doc.PreserveWhitespace = False

        ' Load the passed XML file using it's name.
        doc.Load(New XmlTextReader(FileName))

        ' Create a SignedXml object.
        Dim signedXml As New SignedXml(doc)

        ' Add the key to the SignedXml document. 
        signedXml.SigningKey = cert.PrivateKey

        ' Create a reference to be signed.
        Dim reference As New Reference()
        reference.Uri = ""

        ' Add an enveloped transformation to the reference.
        Dim env As New XmlDsigEnvelopedSignatureTransform()
        reference.AddTransform(env)

        ' Add the reference to the SignedXml object.
        signedXml.AddReference(reference)

        ' Create a new KeyInfo object.
        Dim keyInfo As New KeyInfo()

        ' Load the certificate into a KeyInfoX509Data object
        ' and add it to the KeyInfo object.
        Dim X509KeyInfo As New KeyInfoX509Data(cert, X509IncludeOption.WholeChain)

        keyInfo.AddClause(X509KeyInfo)

        ' Add the KeyInfo object to the SignedXml object.
        signedXml.KeyInfo = keyInfo

        ' Compute the signature.
        signedXml.ComputeSignature()

        ' Get the XML representation of the signature and save
        ' it to an XmlElement object.
        Dim xmlDigitalSignature As XmlElement = signedXml.GetXml()

        ' Append the element to the XML document.
        doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, True))


        If TypeOf doc.FirstChild Is XmlDeclaration Then
            doc.RemoveChild(doc.FirstChild)
        End If

        ' Save the signed XML document to a file specified
        ' using the passed string.
        Dim xmltw As New XmlTextWriter(SignedFileName, New UTF8Encoding(False))
        Try
            doc.WriteTo(xmltw)

        Finally
            xmltw.Close()
        End Try

    End Sub

    ' </Snippet2>
    ' Verify the signature of an XML file against an asymetric 
    ' algorithm and return the result.
    Function VerifyXmlFile(ByVal FileName As String, ByVal CertificateSubject As String) As [Boolean]
        ' Check the args.
        If Nothing = FileName Then
            Throw New ArgumentNullException("FileName")
        End If
        If Nothing = CertificateSubject Then
            Throw New ArgumentNullException("CertificateSubject")
        End If
        ' Load the certificate from the store.
        Dim cert As X509Certificate2 = GetCertificateBySubject(CertificateSubject)

        ' Create a new XML document.
        Dim xmlDocument As New XmlDocument()

        ' Load the passed XML file into the document. 
        xmlDocument.Load(FileName)

        ' Create a new SignedXml object and pass it
        ' the XML document class.
        Dim signedXml As New SignedXml(xmlDocument)

        ' Find the "Signature" node and create a new
        ' XmlNodeList object.
        Dim nodeList As XmlNodeList = xmlDocument.GetElementsByTagName("Signature")

        ' Load the signature node.
        signedXml.LoadXml(CType(nodeList(0), XmlElement))

        ' Check the signature and return the result.
        Return signedXml.CheckSignature(cert, True)

    End Function



    Function GetCertificateBySubject(ByVal CertificateSubject As String) As X509Certificate2
        ' Check the args.
        If Nothing = CertificateSubject Then
            Throw New ArgumentNullException("CertificateSubject")
        End If

        ' Load the certificate from the certificate store.
        Dim cert As X509Certificate2 = Nothing

        Dim store As New X509Store("My", StoreLocation.CurrentUser)

        Try
            ' Open the store.
            store.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

            ' Get the certs from the store.
            Dim CertCol As X509Certificate2Collection = store.Certificates

            ' Find the certificate with the specified subject.
            Dim c As X509Certificate2
            For Each c In CertCol
                If c.Subject = CertificateSubject Then
                    cert = c
                    Exit For
                End If
            Next c

            ' Throw an exception of the certificate was not found.
            If cert Is Nothing Then
                Throw New CryptographicException("The certificate could not be found.")
            End If
        Finally
            ' Close the store even if an exception was thrown.
            store.Close()
        End Try

        Return cert

    End Function


    ' Create example data to sign.
    Sub CreateSomeXml(ByVal FileName As String)
        ' Check the args.
        If Nothing = FileName Then
            Throw New ArgumentNullException("FileName")
        End If
        ' Create a new XmlDocument object.
        Dim document As New XmlDocument()

        ' Create a new XmlNode object.
        Dim node As XmlNode = document.CreateNode(XmlNodeType.Element, "", "MyElement", "samples")

        ' Add some text to the node.
        node.InnerText = "Example text to be signed."

        ' Append the node to the document.
        document.AppendChild(node)

        ' Save the XML document to the file name specified.
        Dim xmltw As New XmlTextWriter(FileName, New UTF8Encoding(False))
        Try
            document.WriteTo(xmltw)

        Finally
            xmltw.Close()
        End Try

    End Sub
End Module
' This code example displays the following to the console:
'
' New XML file created.
' XML file signed.
' The XML signature is valid.
' </Snippet1>