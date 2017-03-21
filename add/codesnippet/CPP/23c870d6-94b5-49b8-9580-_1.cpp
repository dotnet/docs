// Sign an XML file and save the signature in a new file.
void SignDetachedResource( String^ URIString, String^ XmlSigFileName, DSA^ DSAKey )
{
   
   // Create a SignedXml Object*.
   SignedXml^ signedXml = gcnew SignedXml;
   
   // Assign the DSA key to the SignedXml object.
   signedXml->SigningKey = DSAKey;
   
   // Create a reference to be signed.
   Reference^ reference = gcnew Reference;
   
   // Add the passed URI to the reference object.
   reference->Uri = URIString;
   
   // Add the reference to the SignedXml object.
   signedXml->AddReference( reference );
   
   // Add a DSAKeyValue to the KeyInfo (optional; helps recipient find key to validate).
   KeyInfo^ keyInfo = gcnew KeyInfo;
   keyInfo->AddClause( gcnew DSAKeyValue( safe_cast<DSA^>(DSAKey) ) );
   signedXml->KeyInfo = keyInfo;
   
   // Compute the signature.
   signedXml->ComputeSignature();
   
   // Get the XML representation of the signature and save
   // it to an XmlElement object.
   XmlElement^ xmlDigitalSignature = signedXml->GetXml();
   
   // Save the signed XML document to a file specified
   // using the passed string.
   XmlTextWriter^ xmltw = gcnew XmlTextWriter( XmlSigFileName,gcnew UTF8Encoding( false ) );
   xmlDigitalSignature->WriteTo( xmltw );
   xmltw->Close();
}

