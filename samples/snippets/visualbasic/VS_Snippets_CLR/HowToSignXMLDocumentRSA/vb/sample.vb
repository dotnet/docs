' <snippet1>
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Xml

Module SignXML
    Sub Main(ByVal args() As String)
        Try
            ' Create a new CspParameters object to specify
            ' a key container.
            ' <snippet2>
            Dim cspParams As New CspParameters With {
                .KeyContainerName = "XML_DSIG_RSA_KEY"
            }
            ' </snippet2>
            ' Create a new RSA signing key and save it in the container. 
            ' <snippet3>
            Dim rsaKey As New RSACryptoServiceProvider(cspParams)
            ' </snippet3>
            ' Create a new XML document.
            ' <snippet4>
            ' Load an XML file into the XmlDocument object.
            Dim xmlDoc As New XmlDocument With {
                .PreserveWhitespace = True
            }
            xmlDoc.Load("test.xml")
            ' </snippet4>
            ' Sign the XML document. 
            SignXml(xmlDoc, rsaKey)

            Console.WriteLine("XML file signed.")

            ' Save the document.
            ' <snippet13>
            xmlDoc.Save("test.xml")
            ' </snippet13>
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub

    ' Sign an XML file. 
    ' This document cannot be verified unless the verifying 
    ' code has the key with which it was signed.
    Sub SignXml(ByVal xmlDoc As XmlDocument, ByVal rsaKey As RSA)
        ' Check arguments.
        If xmlDoc Is Nothing Then
            Throw New ArgumentException(
                "The XML doc cannot be nothing.", NameOf(xmlDoc))
        End If
        If rsaKey Is Nothing Then
            Throw New ArgumentException(
                "The RSA key cannot be nothing.", NameOf(rsaKey))
        End If
        ' Create a SignedXml object.
        ' <snippet5>
        Dim signedXml As New SignedXml(xmlDoc)
        ' </snippet5>
        ' Add the key to the SignedXml document.
        ' <snippet6>
        signedXml.SigningKey = rsaKey
        ' </snippet6>
        ' <snippet7>
        ' Create a reference to be signed.
        Dim reference As New Reference()
        reference.Uri = ""
        ' </snippet7>
        ' Add an enveloped transformation to the reference.
        ' <snippet8>
        Dim env As New XmlDsigEnvelopedSignatureTransform()
        reference.AddTransform(env)
        ' </snippet8>
        ' Add the reference to the SignedXml object.
        ' <snippet9>
        signedXml.AddReference(reference)
        ' </snippet9>
        ' Compute the signature.
        ' <snippet10>
        signedXml.ComputeSignature()
        ' </snippet10>
        ' Get the XML representation of the signature and save
        ' it to an XmlElement object.
        ' <snippet11>
        Dim xmlDigitalSignature As XmlElement = signedXml.GetXml()
        ' </snippet11>
        ' Append the element to the XML document.
        ' <snippet12>
        xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, True))
        ' </snippet12>
    End Sub
End Module
' </snippet1>
