

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   // Create the writer.
   XmlTextWriter^ writer = nullptr;
   writer = gcnew XmlTextWriter( "ws.html", nullptr );
   
   // Write an element (this one is the root).
   writer->WriteStartElement( "p" );
   
   // Write the xml:space attribute.
   writer->WriteAttributeString( "xml", "space", nullptr, "preserve" );
   
   // Verify that xml:space is set properly.
   if ( writer->XmlSpace == XmlSpace::Preserve )
      Console::WriteLine( "xmlspace is correct!" );

   
   // Write out the HTML elements.  Insert white space
   // between 'something' and 'Big'
   writer->WriteString( "something" );
   writer->WriteWhitespace( "  " );
   writer->WriteElementString( "b", "B" );
   writer->WriteString( "ig" );
   
   // Write the root end element.
   writer->WriteEndElement();
   
   // Write the XML to file and close the writer.
   writer->Close();
}

// </Snippet1>
