'<SNIPPET1>
' This example signs a URL using an
' envelope signature. It then verifies the 
' signed XML.
'
Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Text
Imports System.Xml



Module SignVerifyEnvelope


    Sub Main(ByVal args() As String)
        ' Generate a signing key.
        Dim Key As New RSACryptoServiceProvider()

        Try

            ' Sign the detached resource and save the signature in an XML file.
            SignDetachedResource("http://www.microsoft.com", "SignedExample.xml", Key)

            Console.WriteLine("XML file signed.")

            ' Verify the signature of the signed XML.
            Console.WriteLine("Verifying signature...")

            Dim result As Boolean = VerifyXmlFile("SignedExample.xml")

            ' Display the results of the signature verification to \
            ' the console.
            If result Then
                Console.WriteLine("The XML signature is valid.")
            Else
                Console.WriteLine("The XML signature is not valid.")
            End If
        Catch e As CryptographicException
            Console.WriteLine(e.Message)
        Finally
            ' Clear resources associated with the 
            ' RSACryptoServiceProvider.
            Key.Clear()
        End Try

    End Sub


    ' Sign an XML file and save the signature in a new file.
    Sub SignDetachedResource(ByVal URIString As String, ByVal XmlSigFileName As String, ByVal Key As RSA)
        ' Check the arguments.  
        If URIString Is Nothing Then
            Throw New ArgumentNullException("URIString")
        End If
        If XmlSigFileName Is Nothing Then
            Throw New ArgumentNullException("XmlSigFileName")
        End If
        If Key Is Nothing Then
            Throw New ArgumentNullException("Key")
        End If
        ' Create a SignedXml object.
        Dim signedXml As New SignedXml()

        ' Assign the key to the SignedXml object.
        signedXml.SigningKey = Key

        ' Get the signature object from the SignedXml object.
        Dim XMLSignature As Signature = signedXml.Signature

        ' Create a reference to be signed.
        Dim reference As New Reference()

        ' Add the passed URI to the reference object.
        reference.Uri = URIString

        ' Add the Reference object to the Signature object.
        XMLSignature.SignedInfo.AddReference(reference)

        ' Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
        Dim keyInfo As New KeyInfo()
        keyInfo.AddClause(New RSAKeyValue(CType(Key, RSA)))

        ' Add the KeyInfo object to the Reference object.
        XMLSignature.KeyInfo = keyInfo

        ' Compute the signature.
        signedXml.ComputeSignature()

        ' Get the XML representation of the signature and save
        ' it to an XmlElement object.
        Dim xmlDigitalSignature As XmlElement = signedXml.GetXml()

        ' Save the signed XML document to a file specified
        ' using the passed string.
        Dim xmltw As New XmlTextWriter(XmlSigFileName, New UTF8Encoding(False))
        xmlDigitalSignature.WriteTo(xmltw)
        xmltw.Close()

    End Sub



    ' Verify the signature of an XML file and return the result.
    Function VerifyXmlFile(ByVal Name As String) As [Boolean]
        ' Check the arguments.  
        If Name Is Nothing Then
            Throw New ArgumentNullException("Name")
        End If
        ' Create a new XML document.
        Dim xmlDocument As New XmlDocument()

        ' Format using white spaces.
        xmlDocument.PreserveWhitespace = True

        ' Load the passed XML file into the document. 
        xmlDocument.Load(Name)

        ' Create a new SignedXml object and pass it
        ' the XML document class.
        Dim signedXml As New SignedXml(xmlDocument)

        ' Find the "Signature" node and create a new
        ' XmlNodeList object.
        Dim nodeList As XmlNodeList = xmlDocument.GetElementsByTagName("Signature")

        ' Load the signature node.
        signedXml.LoadXml(CType(nodeList(0), XmlElement))

        ' Check the signature and return the result.
        Return signedXml.CheckSignature()

    End Function
End Module
'</SNIPPET1>