   ' Sign an XML file and save the signature in a new file.
   Public Shared Sub SignXmlFile(FileName As String, SignedFileName As String, Key As RSA)
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
      
      
      ' Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
      Dim keyInfo As New KeyInfo()
      keyInfo.AddClause(New RSAKeyValue(CType(Key, RSA)))
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