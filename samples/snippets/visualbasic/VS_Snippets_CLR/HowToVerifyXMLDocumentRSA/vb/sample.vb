' <snippet1>
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Xml

Module VerifyXML
    Sub Main(ByVal args() As String)
        Try
            ' Create a new CspParameters object to specify
            ' a key container.
            ' <snippet2>
            Dim cspParams As New CspParameters()
            cspParams.KeyContainerName = "XML_DSIG_RSA_KEY"
            ' </snippet2>
            ' Create a new RSA signing key and save it in the container. 
            ' <snippet3>
            Dim rsaKey As New RSACryptoServiceProvider(cspParams)
            ' </snippet3>
            ' Create a new XML document.
            ' <snippet4>
            Dim xmlDoc As New XmlDocument()

            ' Load an XML file into the XmlDocument object.
            xmlDoc.PreserveWhitespace = True
            xmlDoc.Load("test.xml")
            ' </snippet4>
            ' Verify the signature of the signed XML.
            Console.WriteLine("Verifying signature...")
            Dim result As Boolean = VerifyXml(xmlDoc, rsaKey)

            ' Display the results of the signature verification to 
            ' the console.
            If result Then
                Console.WriteLine("The XML signature is valid.")
            Else
                Console.WriteLine("The XML signature is not valid.")
            End If

        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub

    ' Verify the signature of an XML file against an asymmetric 
    ' algorithm and return the result.
    Function VerifyXml(ByVal xmlDoc As XmlDocument, ByVal key As RSA) As [Boolean]
        ' Check arguments.
        If xmlDoc Is Nothing Then
            Throw New ArgumentException(
                "The XML doc cannot be nothing.", NameOf(xmlDoc))
        End If
        If key Is Nothing Then
            Throw New ArgumentException(
                "The key cannot be nothing.", NameOf(key))
        End If
        ' Create a new SignedXml object and pass it
        ' the XML document class.
        ' <snippet5>
        Dim signedXml As New SignedXml(xmlDoc)
        ' </snippet5>
        ' Find the "Signature" node and create a new
        ' XmlNodeList object.
        ' <snippet6>
        Dim nodeList As XmlNodeList = xmlDoc.GetElementsByTagName("Signature")
        ' </snippet6>
        ' Throw an exception if no signature was found.
        If nodeList.Count <= 0 Then
            Throw New CryptographicException("Verification failed: No Signature was found in the document.")
        End If

        ' This example only supports one signature for
        ' the entire XML document.  Throw an exception 
        ' if more than one signature was found.
        If nodeList.Count >= 2 Then
            Throw New CryptographicException("Verification failed: More that one signature was found for the document.")
        End If

        ' Load the first <signature> node.  
        ' <snippet7>
        signedXml.LoadXml(CType(nodeList(0), XmlElement))
        ' </snippet7>
        ' Check the signature and return the result.
        ' <snippet8>
        Return signedXml.CheckSignature(key)
        ' </snippet8>
    End Function
End Module
' </snippet1>
