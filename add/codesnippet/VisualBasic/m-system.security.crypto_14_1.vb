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