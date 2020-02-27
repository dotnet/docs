
//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::IO;

// Display any validation errors.
static void ValidationCallBack( Object^ /*sender*/, ValidationEventArgs^ e )
{
   Console::WriteLine( L"Validation Error:\n   {0}", e->Message );
   Console::WriteLine();
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
   settings->ValidationEventHandler += gcnew ValidationEventHandler(ValidationCallBack);

   // Create the XmlReader object.
   XmlReader^ reader = XmlReader::Create( L"booksSchemaFail.xml", settings );

   // Parse the file. 
   while ( reader->Read() )
      ;

   return 1;
}
// The example displays output like the following:
//   Validation Error: 
//        The element 'book' in namespace 'urn:bookstore-schema' has invalid child element 'author' 
//        in namespace 'urn:bookstore-schema'. List of possible elements expected: 'title' in 
//        namespace 'urn:bookstore-schema'.
//
//    Validation Error: 
//       The element 'author' in namespace 'urn:bookstore-schema' has invalid child element 'name' 
//       in namespace 'urn:bookstore-schema'. List of possible elements expected: 'first-name' in 
//       namespace 'urn:bookstore-schema'.
//</snippet1>
