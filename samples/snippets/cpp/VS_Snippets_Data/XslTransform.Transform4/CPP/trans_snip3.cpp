#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Xsl;
using namespace System::Xml::XPath;

int main()
{
   array<String^>^ args = Environment::GetCommandLineArgs();
   String^ UserName = args[ 1 ];
   String^ SecurelyStoredPassword = args[ 2 ];
   String^ Domain = args[ 3 ];
   
   //<snippet1>
   // Create the XslTransform object.
   XslTransform^ xslt = gcnew XslTransform;
   
   // Load the stylesheet.
   xslt->Load( "titles.xsl" );
   
   // Create a resolver and specify the necessary credentials.
   XmlUrlResolver^ resolver = gcnew XmlUrlResolver;
   System::Net::NetworkCredential^ myCred;
   myCred = gcnew System::Net::NetworkCredential( UserName, SecurelyStoredPassword, Domain );
   resolver->Credentials = myCred;
   
   // Transform the file using the resolver. The resolver is used
   // to process the XSLT document() function.
   XPathDocument^ doc = gcnew XPathDocument( "books.xml" );
   XmlReader^ reader = xslt->Transform( doc, nullptr, resolver );
   
   // Load the reader into a new document for more processing.
   XmlDocument^ xmldoc = gcnew XmlDocument;
   xmldoc->Load( reader );
   //</snippet1>

   Console::WriteLine( xmldoc->OuterXml );
}
