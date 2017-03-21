// Sign an XML file and save the signature in a new file.
void SignDetachedResource( String^ URIString, String^ XmlSigFileName, RSA^ Key, String^ Certificate )
{
   
   // Create a SignedXml object.
   SignedXml^ signedXml = gcnew SignedXml;
   
   // Assign the key to the SignedXml object.
   signedXml->SigningKey = Key;
   
   // Create a reference to be signed.
   Reference^ reference = gcnew Reference;
   
   // Add the passed URI to the reference object.
   reference->Uri = URIString;
   
   // Add the reference to the SignedXml object.
   signedXml->AddReference( reference );
   
   // Create a new KeyInfo object.
   KeyInfo^ keyInfo = gcnew KeyInfo;
   
   // Load the X509 certificate.
   X509Certificate^ MSCert = X509Certificate::CreateFromCertFile( Certificate );
   
   // Load the certificate into a KeyInfoX509Data object
   // and add it to the KeyInfo object.
   keyInfo->AddClause( gcnew KeyInfoX509Data( MSCert ) );
   
   // Add the KeyInfo object to the SignedXml object.
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

