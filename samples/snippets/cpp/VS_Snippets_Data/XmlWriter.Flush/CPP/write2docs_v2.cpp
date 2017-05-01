
//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
void main()
{
   
   // Create an XmlWriter to write XML fragments.
   XmlWriterSettings^ settings = gcnew XmlWriterSettings;
   settings->ConformanceLevel = ConformanceLevel::Fragment;
   settings->Indent = true;
   XmlWriter^ writer = XmlWriter::Create( Console::Out, settings );
   
   // Write an XML fragment.
   writer->WriteStartElement( L"book" );
   writer->WriteElementString( L"title", L"Pride And Prejudice" );
   writer->WriteEndElement();
   writer->Flush();
   
   // Write another XML fragment.
   writer->WriteStartElement( L"cd" );
   writer->WriteElementString( L"title", L"Americana" );
   writer->WriteEndElement();
   writer->Flush();
   
   // Close the writer.
   writer->Close();
}

//</snippet1>
