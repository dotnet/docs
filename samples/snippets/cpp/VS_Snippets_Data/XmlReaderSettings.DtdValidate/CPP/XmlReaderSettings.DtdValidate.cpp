//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::IO;

// Display any validation errors.
static void ValidationCallBack( Object^ /*sender*/, ValidationEventArgs^ e )
{
   Console::WriteLine( L"Validation Error: {0}", e->Message );
}

int main()
{
   // Set the validation settings.
   XmlReaderSettings^ settings = gcnew XmlReaderSettings;
   settings->DtdProcessing = DtdProcessing::Parse;
   settings->ValidationType = ValidationType::DTD;
   settings->ValidationEventHandler += gcnew ValidationEventHandler( ValidationCallBack );

   // Create the XmlReader object.
   XmlReader^ reader = XmlReader::Create( L"itemDTD.xml", settings );

   // Parse the file. 
   while ( reader->Read() )
      ;

   return 1;
}
//</snippet1>

