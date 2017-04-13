

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   String^ filename = "sampledata.xml";
   XmlTextWriter^ writer = gcnew XmlTextWriter( filename, nullptr );
   
   //Use indenting for readability.
   writer->Formatting = Formatting::Indented;
   writer->WriteComment( "sample XML fragment" );
   
   //Write an element (this one is the root).
   writer->WriteStartElement( "bookstore" );
   
   //Write the namespace declaration.
   writer->WriteAttributeString( "xmlns", "bk", nullptr, "urn:samples" );
   writer->WriteStartElement( "book" );
   
   //Lookup the prefix and then write the ISBN attribute.
   String^ prefix = writer->LookupPrefix( "urn:samples" );
   writer->WriteStartAttribute( prefix, "ISBN", "urn:samples" );
   writer->WriteString( "1-861003-78" );
   writer->WriteEndAttribute();
   
   //Write the title.
   writer->WriteStartElement( "title" );
   writer->WriteString( "The Handmaid's Tale" );
   writer->WriteEndElement();
   
   //Write the price.
   writer->WriteElementString( "price", "19.95" );
   
   //Write the style element.
   writer->WriteStartElement( prefix, "style", "urn:samples" );
   writer->WriteString( "hardcover" );
   writer->WriteEndElement();
   
   //Write the end tag for the book element.
   writer->WriteEndElement();
   
   //Write the close tag for the root element.
   writer->WriteEndElement();
   
   //Write the XML to file and close the writer.
   writer->Flush();
   writer->Close();
   
   //Read the file back in and parse to ensure well formed XML.
   XmlDocument^ doc = gcnew XmlDocument;
   
   //Preserve white space for readability.
   doc->PreserveWhitespace = true;
   
   //Load the file
   doc->Load( filename );
   
   //Write the XML content to the console.
   Console::Write( doc->InnerXml );
}

// </Snippet1>
