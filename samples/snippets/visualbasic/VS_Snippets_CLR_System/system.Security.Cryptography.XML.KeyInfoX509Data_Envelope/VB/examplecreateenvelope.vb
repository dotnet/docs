' <Snippet1>
'
' This example signs an XML file using an
' envelope signature. It then verifies the 
' signed XML.
'
Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Xml



Public Class SignVerifyEnvelope
   
   
   Overloads Public Shared Sub Main(args() As [String])
      
      Dim Certificate As String = "microsoft.cer"
      
      Try
         ' Generate a signing key.
         Dim Key As New RSACryptoServiceProvider()
         
         ' Create an XML file to sign.
         CreateSomeXml("Example.xml")
         Console.WriteLine("New XML file created.")
         
         ' Sign the XML that was just created and save it in a 
         ' new file.
         SignXmlFile("Example.xml", "SignedExample.xml", Key, Certificate)
         Console.WriteLine("XML file signed.")
      Catch e As CryptographicException
         Console.WriteLine(e.Message)
      End Try
   End Sub 
   
   
   ' <Snippet2>
   ' Sign an XML file and save the signature in a new file.
   Public Shared Sub SignXmlFile(FileName As String, SignedFileName As String, Key As RSA, Certificate As String)
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
   
   ' </Snippet2>
   
   ' Create example data to sign.
   Public Shared Sub CreateSomeXml(FileName As String)
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
      document.WriteTo(xmltw)
      xmltw.Close()
   End Sub 
End Class 
' </Snippet1>