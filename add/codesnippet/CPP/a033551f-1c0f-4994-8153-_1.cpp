void TransformFile( XmlReader^ xsltReader, String^ secureURL )
{
   
   // Load the stylesheet using a default XmlUrlResolver and Evidence 
   // created using the trusted URL.
   XslTransform^ xslt = gcnew XslTransform;
   xslt->Load( xsltReader, gcnew XmlUrlResolver, XmlSecureResolver::CreateEvidenceForUrl( secureURL ) );
   
   // Transform the file.
   xslt->Transform("books.xml","books.html",gcnew XmlUrlResolver);
}
