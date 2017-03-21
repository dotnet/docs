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