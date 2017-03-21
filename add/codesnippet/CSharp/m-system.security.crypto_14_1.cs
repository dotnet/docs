    // Verify the signature of an XML file and return the result.
    public static Boolean VerifyDetachedSignature(string XmlSigFileName)
    {	
        // Create a new XML document.
        XmlDocument xmlDocument = new XmlDocument();

        // Load the passed XML file into the document.
        xmlDocument.Load(XmlSigFileName);
	
        // Create a new SignedXMl object.
        SignedXml signedXml = new SignedXml();

        // Find the "Signature" node and create a new
        // XmlNodeList object.
        XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");

        // Load the signature node.
        signedXml.LoadXml((XmlElement)nodeList[0]);

        // Check the signature and return the result.
        return signedXml.CheckSignature();
    }