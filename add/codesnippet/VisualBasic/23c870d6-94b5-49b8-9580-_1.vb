   ' Sign an XML file and save the signature in a new file.
   Public Shared Sub SignDetachedResource(URIString As String, XmlSigFileName As String, DSAKey As DSA)
      ' Create a SignedXml object.
      Dim signedXml As New SignedXml()
      
      ' Assign the DSA key to the SignedXml object.
      signedXml.SigningKey = DSAKey
      
      ' Create a reference to be signed.
      Dim reference As New Reference()
      
      ' Add the passed URI to the reference object.
      reference.Uri = URIString
      
      ' Add the reference to the SignedXml object.
      signedXml.AddReference(reference)
      
      ' Add a DSAKeyValue to the KeyInfo (optional; helps recipient find key to validate).
      Dim keyInfo As New KeyInfo()
      keyInfo.AddClause(New DSAKeyValue(CType(DSAKey, DSA)))
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
   