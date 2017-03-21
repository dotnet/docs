// Verify the signature of an XML file and return the result.
Boolean VerifyDetachedSignature( String^ XmlSigFileName )
{
   
   // Create a new XML document.
   XmlDocument^ xmlDocument = gcnew XmlDocument;
   
   // Load the passed XML file into the document.
   xmlDocument->Load( XmlSigFileName );
   
   // Create a new SignedXMl object.
   SignedXml^ signedXml = gcnew SignedXml;
   
   // Find the "Signature" node and create a new
   // XmlNodeList object.
   XmlNodeList^ nodeList = xmlDocument->GetElementsByTagName( "Signature" );
   
   // Load the signature node.
   signedXml->LoadXml( safe_cast<XmlElement^>(nodeList->Item( 0 )) );
   
   // Check the signature and return the result.
   return signedXml->CheckSignature();
}

