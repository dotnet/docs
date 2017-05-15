//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
int main()
{
   
   // Create a writer to write XML to the console.
   XmlWriterSettings^ settings = gcnew XmlWriterSettings;
   settings->Indent = true;
   settings->OmitXmlDeclaration = true;
   XmlWriter^ writer = XmlWriter::Create( Console::Out, settings );
   
   // Write the book element.
   writer->WriteStartElement( L"book" );
   
   // Write the title element.
   writer->WriteStartElement( L"title" );
   writer->WriteString( L"Pride And Prejudice" );
   writer->WriteEndElement();
   
   // Write the close tag for the root element.
   writer->WriteEndElement();
   
   // Write the XML and close the writer.
   writer->Close();
   return 1;
}

//</snippet1>
