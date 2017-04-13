' <Snippet1>
'
' This example signs a file specified by a URI 
' using a detached signature. It then verifies  
' the signed XML.
'
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
         
         Console.WriteLine("XML Signature was succesfully computed and saved to {0}.", XmlFileName)
         
         ' Verify the signature of the signed XML.
         Console.WriteLine("Verifying signature...")
         
         'Verify the XML signature in the XML file against the key.
         Dim result As Boolean = VerifyDetachedSignature(XmlFileName, Key)
         
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
   
   
   
   ' Sign an XML file and save the signature in a new file. This method does not  
   ' save the public key within the XML file.  This file cannot be verified unless  
   ' the verifying code has the key with which it was signed.
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
    
   
   ' Verify the signature of an XML file against an asymetric 
   ' algorithm and return the result.
   Public Shared Function VerifyDetachedSignature(XmlSigFileName As String, Key As RSA) As [Boolean]
      ' Create a new XML document.
      Dim xmlDocument As New XmlDocument()
      
      ' Load the passedXML file into the document.
      xmlDocument.Load(XmlSigFileName)
      
      ' Create a new SignedXml object.
      Dim signedXml As New SignedXml()
      
      ' Find the "Signature" node and create a new
      ' XmlNodeList object.
      Dim nodeList As XmlNodeList = xmlDocument.GetElementsByTagName("Signature")
      
      ' Load the signature node.
      signedXml.LoadXml(CType(nodeList(0), XmlElement))
      
      ' Check the signature against the passed asymetric key
      ' and return the result.
      Return signedXml.CheckSignature(Key)
   End Function 
End Class
' </Snippet1> 