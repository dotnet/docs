'<SNIPPET1>
' This example signs an XML file using an
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

            ' Sign an XML file and save the signature to a 
            ' new file.
            SignXmlFile("Test.xml", "SignedExample.xml", Key)
            Console.WriteLine("XML file signed.")

            ' Verify the signature of the signed XML.
            Console.WriteLine("Verifying signature...")

            Dim result As Boolean = VerifyXmlFile("SignedExample.xml")

            ' Display the results of the signature verification to 
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
    Sub SignXmlFile(ByVal FileName As String, ByVal SignedFileName As String, ByVal Key As RSA)
        ' Check the arguments.  
        If FileName Is Nothing Then
            Throw New ArgumentNullException("FileName")
        End If
        If SignedFileName Is Nothing Then
            Throw New ArgumentNullException("SignedFileName")
        End If
        If Key Is Nothing Then
            Throw New ArgumentNullException("Key")
        End If

        ' Create a new XML document.
        Dim doc As New XmlDocument()

        ' Format the document to ignore white spaces.
        doc.PreserveWhitespace = False

        ' Load the passed XML file using it's name.
        doc.Load(New XmlTextReader(FileName))

        ' Create a SignedXml object.
        Dim signedXml As New SignedXml(doc)

        ' Add the key to the SignedXml document. 
        signedXml.SigningKey = Key

        ' Get the signature object from the SignedXml object.
        Dim XMLSignature As Signature = signedXml.Signature

        ' Create a reference to be signed.  Pass "" 
        ' to specify that all of the current XML
        ' document should be signed.
        Dim reference As New Reference("")

        ' Add an enveloped transformation to the reference.
        Dim env As New XmlDsigEnvelopedSignatureTransform()
        reference.AddTransform(env)

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

        ' Append the element to the XML document.
        doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, True))


        If TypeOf doc.FirstChild Is XmlDeclaration Then
            doc.RemoveChild(doc.FirstChild)
        End If

        ' Save the signed XML document to a file specified
        ' using the passed string.
        Dim xmltw As New XmlTextWriter(SignedFileName, New UTF8Encoding(False))
        doc.WriteTo(xmltw)
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