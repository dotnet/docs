// <Snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Xsl;
using namespace System::Xml::XPath;

int main()
{
   String^ filename = "books.xml";
   String^ stylesheet = "output.xsl";

   //Load the stylesheet.
   XslTransform^ xslt = gcnew XslTransform;
   xslt->Load( stylesheet );

   //Load the file to transform.
   XPathDocument^ doc = gcnew XPathDocument( filename );

   //Create an XmlTextWriter which outputs to the console.
   XmlTextWriter^ writer = gcnew XmlTextWriter( Console::Out );

   //Transform the file and send the output to the console.
   xslt->Transform(doc,nullptr,writer,nullptr);
   writer->Close();
}
// </Snippet1>
