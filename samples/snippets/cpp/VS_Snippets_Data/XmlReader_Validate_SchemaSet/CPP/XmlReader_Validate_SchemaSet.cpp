
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
   // Create the XmlSchemaSet class.
   XmlSchemaSet^ sc = gcnew XmlSchemaSet;

   // Add the schema to the collection.
   sc->Add( L"urn:bookstore-schema", L"books.xsd" );

   // Set the validation settings.
   XmlReaderSettings^ settings = gcnew XmlReaderSettings;
   settings->ValidationType = ValidationType::Schema;
   settings->Schemas = sc;
   settings->ValidationEventHandler += gcnew ValidationEventHandler( ValidationCallBack );

   // Create the XmlReader object.
   XmlReader^ reader = XmlReader::Create( L"booksSchemaFail.xml", settings );

   // Parse the file. 
   while ( reader->Read() )
      ;

   return 1;
}
//</snippet1>
