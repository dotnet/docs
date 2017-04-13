

//<snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Xsl;
using namespace System::Xml::XPath;
int main()
{
   String^ filename = "books.xml";
   String^ stylesheet = "titles.xsl";
   
   // Create the reader to load the stylesheet. 
   // Move the reader to the xsl:stylesheet node.
   XmlTextReader^ reader = gcnew XmlTextReader( stylesheet );
   reader->Read();
   reader->Read();
   
   // Create the XslTransform object and load the stylesheet.
   XslTransform^ xslt = gcnew XslTransform;
   xslt->Load( reader );
   
   // Load the file to transform.
   XPathDocument^ doc = gcnew XPathDocument( filename );
   
   // Create an XmlTextWriter which outputs to the console.
   XmlTextWriter^ writer = gcnew XmlTextWriter( Console::Out );
   
   // Transform the file and send the output to the console.
   xslt->Transform(doc,nullptr,writer);
   writer->Close();
}

//</snippet1>
