//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
void main()
{
   XmlWriter^ writer = nullptr;
   writer = XmlWriter::Create( L"sampledata.xml" );
   
   // Write the root element.
   writer->WriteStartElement( L"book" );
   
   // Write the xmlns:bk="urn:book" namespace declaration.
   writer->WriteAttributeString( L"xmlns", L"bk", nullptr, L"urn:book" );
   
   // Write the bk:ISBN="1-800-925" attribute.
   writer->WriteAttributeString( L"ISBN", L"urn:book", L"1-800-925" );
   writer->WriteElementString( L"price", L"19.95" );
   
   // Write the close tag for the root element.
   writer->WriteEndElement();
   
   // Write the XML to file and close the writer.
   writer->Flush();
   writer->Close();
}
//</snippet1>
