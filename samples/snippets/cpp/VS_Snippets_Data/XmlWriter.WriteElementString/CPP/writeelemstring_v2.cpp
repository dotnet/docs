//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
public ref class Sample
{
private:
   static String^ m_Document = L"sampledata.xml";

public:
   static void Main()
   {
      XmlWriter^ writer = nullptr;
      try
      {
         XmlWriterSettings^ settings = gcnew XmlWriterSettings;
         settings->Indent = true;
         writer = XmlWriter::Create( m_Document,settings );
         writer->WriteComment( L"sample XML fragment" );
         
         // Write an element (this one is the root).
         writer->WriteStartElement( L"book" );
         
         // Write the namespace declaration.
         writer->WriteAttributeString( L"xmlns", L"bk", nullptr, L"urn:samples" );
         
         // Write the genre attribute.
         writer->WriteAttributeString( L"genre", L"novel" );
         
         // Write the title.
         writer->WriteStartElement( L"title" );
         writer->WriteString( L"The Handmaid's Tale" );
         writer->WriteEndElement();
         
         // Write the price.
         writer->WriteElementString( L"price", L"19.95" );
         
         // Lookup the prefix and write the ISBN element.
         String^ prefix = writer->LookupPrefix( L"urn:samples" );
         writer->WriteStartElement( prefix, L"ISBN", L"urn:samples" );
         writer->WriteString( L"1-861003-78" );
         writer->WriteEndElement();
         
         // Write the style element (shows a different way to handle prefixes).
         writer->WriteElementString( L"style", L"urn:samples", L"hardcover" );
         
         // Write the close tag for the root element.
         writer->WriteEndElement();
         
         // Write the XML to file and close the writer.
         writer->Flush();
         writer->Close();
      }
      finally
      {
         if ( writer != nullptr )
                  writer->Close();
      }

   }

};

void main()
{
   Sample::Main();
}

//</snippet1>
