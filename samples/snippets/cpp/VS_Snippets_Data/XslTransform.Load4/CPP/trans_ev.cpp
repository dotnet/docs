

#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Xsl;
void TransformFile( XmlReader^ xsltReader, String^ secureURL );
int main()
{
   String^ stylesheet = "c:\\tmp\\output.xsl";
   String^ myURL = "http://localhost/data";
   XmlTextReader^ reader = gcnew XmlTextReader( stylesheet );
   TransformFile( reader, myURL );
}


// Perform an XSLT transformation where xsltReader is an XmlReader containing
// a stylesheet and secureURI is a trusted URI that can be used to create Evidence.
//<snippet1>
void TransformFile( XmlReader^ xsltReader, String^ secureURL )
{
   
   // Load the stylesheet using a default XmlUrlResolver and Evidence 
   // created using the trusted URL.
   XslTransform^ xslt = gcnew XslTransform;
   xslt->Load( xsltReader, gcnew XmlUrlResolver, XmlSecureResolver::CreateEvidenceForUrl( secureURL ) );
   
   // Transform the file.
   xslt->Transform("books.xml","books.html",gcnew XmlUrlResolver);
}

//</snippet1> 
