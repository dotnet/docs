

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   XmlTextWriter^ writer = gcnew XmlTextWriter( Console::Out );
   
   // Use indenting for readability
   writer->Formatting = Formatting::Indented;
   
   // Write an XML fragment.
   writer->WriteStartElement( "book" );
   writer->WriteElementString( "title", "Pride And Prejudice" );
   writer->WriteEndElement();
   writer->Flush();
   
   // Write another XML fragment.
   writer->WriteStartElement( "cd" );
   writer->WriteElementString( "title", "Americana" );
   writer->WriteEndElement();
   writer->Flush();
   
   // Close the writer.
   writer->Close();
}

//</snippet1>
