' <Snippet1>
' This example signs a file specified by a URI 
' using a detached signature. It then verifies  
' the signed XML.

Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Text
Imports System.Xml

Class XMLDSIGDetached

   
   <STAThread()>  _
   Overloads Shared Sub Main(args() As String)
      ' The URI to sign.
      Dim resourceToSign As String = "http://www.microsoft.com"
      
      ' The name of the file to which to save the XML signature.
      Dim XmlFileName As String = "xmldsig.xml"
      
      Try
         
         ' Generate a signing key.
         Dim Key As New RSACryptoServiceProvider()
         
         Console.WriteLine("Signing: {0}", resourceToSign)
         
         ' Sign the detached resourceand save the signature in an XML file.
         SignDetachedResource(resourceToSign, XmlFileName, Key)
         
         Console.WriteLine("XML signature was succesfully computed and saved to {0}.", XmlFileName)
         
         ' Verify the signature of the signed XML.
         Console.WriteLine("Verifying signature...")
         
         'Verify the XML signature in the XML file.
         Dim result As Boolean = VerifyDetachedSignature(XmlFileName)
         
         ' Display the results of the signature verification to 
         ' the console.
         If result Then
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
   Public Shared Sub SignDetachedResource(URIString As String, XmlSigFileName As String, Key As RSA)
      ' Create a SignedXml object.
      Dim signedXml As New SignedXml()
      
      ' Assign the key to the SignedXml object.
      signedXml.SigningKey = Key
      
      ' Create a reference to be signed.
      Dim reference As New Reference()
      
      ' Add the passed URI to the reference object.
      reference.Uri = URIString
      
      ' Add the reference to the SignedXml object.
      signedXml.AddReference(reference)
      
      ' Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
      Dim keyInfo As New KeyInfo()
      keyInfo.AddClause(New RSAKeyValue(CType(Key, RSA)))
      signedXml.KeyInfo = keyInfo
      
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
   
   ' </Snippet2>
   ' <Snippet3>
   ' Verify the signature of an XML file and return the result.
   Public Shared Function VerifyDetachedSignature(XmlSigFileName As String) As [Boolean]
      ' Create a new XML document.
      Dim xmlDocument As New XmlDocument()
      
      ' Load the passed XML file into the document.
      xmlDocument.Load(XmlSigFileName)
      
      ' Create a new SignedXMl object.
      Dim signedXml As New SignedXml()
      
      ' Find the "Signature" node and create a new
      ' XmlNodeList object.
      Dim nodeList As XmlNodeList = xmlDocument.GetElementsByTagName("Signature")
      
      ' Load the signature node.
      signedXml.LoadXml(CType(nodeList(0), XmlElement))
      
      ' Check the signature and return the result.
      Return signedXml.CheckSignature()
   End Function
   ' </snippet3>
End Class

' </Snippet1>