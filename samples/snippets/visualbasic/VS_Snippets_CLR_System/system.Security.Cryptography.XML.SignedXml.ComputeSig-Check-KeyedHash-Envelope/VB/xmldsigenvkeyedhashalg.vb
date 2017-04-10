' <Snippet1>
'
' This example signs an XML file using an
' envelope signature. It then verifies the 
' signed XML.
'
Imports System
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Xml
Imports System.Text
Imports System.Xml



Public Class SignVerifyEnvelope
   
   
   Overloads Public Shared Sub Main(args() As [String])
      Try
         
         ' Generate a signing key.
         Dim Key As New HMACSHA1()
         
         ' Create an XML file to sign.
         CreateSomeXml("Example.xml")
         Console.WriteLine("New XML file created.")
         
         ' Sign the XML that was just created and save it in a 
         ' new file.
         SignXmlFile("Example.xml", "SignedExample.xml", Key)
         Console.WriteLine("XML file signed.")
         
         ' Verify the signature of the signed XML.
         Console.WriteLine("Verifying Signature...")
         Dim result As Boolean = VerifyXmlFile("SignedExample.xml", Key)
         
         ' Display the results of the signature verification to \
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
   
   
   
   ' Sign an XML file and save the signature in a new file.
   Public Shared Sub SignXmlFile(FileName As String, SignedFileName As String, Key As KeyedHashAlgorithm)
      ' Create a new XML document.
      Dim doc As New XmlDocument()
      
      ' Format the document to ignore white spaces.
      doc.PreserveWhitespace = False
      
      ' Load the passed XML file using it's name.
      doc.Load(New XmlTextReader(FileName))
      
      ' Create a SignedXml object.
      Dim signedXml As New SignedXml(doc)
      
      ' Create a reference to be signed.
      Dim reference As New Reference()
      reference.Uri = ""
      
      ' Add an enveloped transformation to the reference.
      Dim env As New XmlDsigEnvelopedSignatureTransform()
      reference.AddTransform(env)
      
      ' Add the reference to the SignedXML object.
      signedXml.AddReference(reference)
      
      ' Compute the signature.
      signedXml.ComputeSignature(Key)
      
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
   Public Shared Function VerifyXmlFile(Name As [String], Key As KeyedHashAlgorithm) As [Boolean]
      ' Create a new XML document.
      Dim xmlDocument As New XmlDocument()
      
      ' Format using whitespaces.
      xmlDocument.PreserveWhitespace = True
      
      ' Load the passed XML file into the document. 
      xmlDocument.Load(Name)
      
      ' Create a new SignedXMl object and pass it
      ' the XMl document class.
      Dim signedXml As New SignedXml(xmlDocument)
      
      ' Find the "Signature" node and create a new
      ' XmlNodeList object.
      Dim nodeList As XmlNodeList = xmlDocument.GetElementsByTagName("Signature")
      
      ' Load the signature node.
      signedXml.LoadXml(CType(nodeList(0), XmlElement))
      
      ' Check the signature and return the result.
      Return signedXml.CheckSignature(Key)
   End Function
   
   
   
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
      
      ' Save the XML document to the filename specified.
      Dim xmltw As New XmlTextWriter(FileName, New UTF8Encoding(False))
      document.WriteTo(xmltw)
      xmltw.Close()
   End Sub 
End Class 
' </Snippet1>