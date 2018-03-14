#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Xsl;
using namespace System::Xml::XPath;

int main()
{
//<snippet1>
   XmlDocument^ doc = gcnew XmlDocument;
   doc->Load( "books.xml" );
   
   // Modify the XML file.
   XmlElement^ root = doc->DocumentElement;
   root->FirstChild->LastChild->InnerText = "12.95";
   
   // Create an XPathNavigator to use for the transform.
   XPathNavigator^ nav = root->CreateNavigator();
   
   // Transform the file.
   XslTransform^ xslt = gcnew XslTransform;
   xslt->Load( "output.xsl" );
   XmlTextWriter^ writer = gcnew XmlTextWriter( "books.html", nullptr );
   xslt->Transform( nav, nullptr, writer, nullptr);
//</snippet1>
}
