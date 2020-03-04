

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
int main()
{
   
   // Create the XmlDocument.
   XmlDocument^ doc = gcnew XmlDocument;
   doc->LoadXml( "<item><name>wrench</name></item>" );
   
   // Add a price element.
   XmlElement^ newElem = doc->CreateElement( "price" );
   newElem->InnerText = "10.95";
   doc->DocumentElement->AppendChild( newElem );
   
   // Save the document to a file and auto-indent the output.
   XmlTextWriter^ writer = gcnew XmlTextWriter( "data.xml", nullptr );
   writer->Formatting = Formatting::Indented;
   doc->Save( writer );
}

// </Snippet1>
