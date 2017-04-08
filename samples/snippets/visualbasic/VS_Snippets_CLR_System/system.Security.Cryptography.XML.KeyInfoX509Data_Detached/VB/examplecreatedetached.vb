' <Snippet1>
'
' This example signs a file specified by a URI 
' using a detached signature. It then verifies  
' the signed XML.
'
Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Xml





Class XMLDSIGDetached
   
  
   <STAThread()>  _
   Overloads Shared Sub Main(args() As String)
      ' The URI to sign.
      Dim resourceToSign As String = "http://www.microsoft.com"
      
      ' The name of the file to which to save the XML signature.
      Dim XmlFileName As String = "xmldsig.xml"
      
      ' The name of the X509 certificate
      Dim Certificate As String = "microsoft.cer"
      
      Try
         
         ' Generate a signing key. This key should match the 
         ' certificate.
         Dim Key As New RSACryptoServiceProvider()
         
         Console.WriteLine("Signing: {0}", resourceToSign)
         
         ' Sign the detached resourceand save the signature in an XML file.
         SignDetachedResource(resourceToSign, XmlFileName, Key, Certificate)
         
         Console.WriteLine("XML signature was succesfully computed and saved to {0}.", XmlFileName)
      
      Catch e As CryptographicException
         Console.WriteLine(e.Message)
      End Try 
   End Sub 
   
   
   
   ' <Snippet2>
   ' Sign an XML file and save the signature in a new file.
   Public Shared Sub SignDetachedResource(URIString As String, XmlSigFileName As String, Key As RSA, Certificate As String)
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
      
      ' Create a new KeyInfo object.
      Dim keyInfo As New KeyInfo()
      
      ' Load the X509 certificate.
      Dim MSCert As X509Certificate = X509Certificate.CreateFromCertFile(Certificate)
      
      ' Load the certificate into a KeyInfoX509Data object
      ' and add it to the KeyInfo object.
      keyInfo.AddClause(New KeyInfoX509Data(MSCert))
      
      ' Add the KeyInfo object to the SignedXml object.
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
End Class 
' </Snippet2>
' </Snippet1>