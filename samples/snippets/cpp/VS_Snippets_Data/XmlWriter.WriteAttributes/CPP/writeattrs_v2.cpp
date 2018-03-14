//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
void main()
{
   XmlReader^ reader = XmlReader::Create( L"test1.xml" );
   XmlWriterSettings^ settings = gcnew XmlWriterSettings;
   settings->Indent = true;
   XmlWriter^ writer = XmlWriter::Create( Console::Out );
   while ( reader->Read() )
   {
      if ( reader->NodeType == XmlNodeType::Element )
      {
         writer->WriteStartElement( reader->Name->ToUpper() );
         writer->WriteAttributes( reader, false );
         if ( reader->IsEmptyElement )
                  writer->WriteEndElement();
      }
      else
      if ( reader->NodeType == XmlNodeType::EndElement )
      {
         writer->WriteEndElement();
      }
   }

   writer->Close();
   reader->Close();
}
//</snippet1>
