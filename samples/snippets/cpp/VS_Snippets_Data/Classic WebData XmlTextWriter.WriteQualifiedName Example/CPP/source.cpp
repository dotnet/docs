

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlTextWriter^ writer = nullptr;
   String^ filename = "sampledata.xml";
   writer = gcnew XmlTextWriter( filename, nullptr );
   
   // Use indenting for readability.
   writer->Formatting = Formatting::Indented;
   
   // Write the root element.
   writer->WriteStartElement( "schema" );
   
   // Write the namespace declarations.
   writer->WriteAttributeString( "xmlns", nullptr, "http://www.w3.org/2001/XMLSchema" );
   writer->WriteAttributeString( "xmlns", "po", nullptr, "http://contoso.com/po" );
   writer->WriteStartElement( "element" );
   writer->WriteAttributeString( "name", "purchaseOrder" );
   
   // Write the type attribute.
   writer->WriteStartAttribute( nullptr, "type", nullptr );
   writer->WriteQualifiedName( "PurchaseOrder", "http://contoso.com/po" );
   writer->WriteEndAttribute();
   writer->WriteEndElement();
   
   // Write the close tag for the root element.
   writer->WriteEndElement();
   
   // Write the XML to file and close the writer.
   writer->Flush();
   writer->Close();
   
   // Read the file back in and parse to ensure well formed XML.
   XmlDocument^ doc = gcnew XmlDocument;
   
   // Preserve white space for readability.
   doc->PreserveWhitespace = true;
   
   // Load the file.
   doc->Load( filename );
   
   // Write the XML content to the console.
   Console::Write( doc->InnerXml );
}

// </Snippet1>
