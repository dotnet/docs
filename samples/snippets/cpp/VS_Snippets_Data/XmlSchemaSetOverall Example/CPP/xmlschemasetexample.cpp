//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

static void booksSettingsValidationEventHandler( Object^ /*sender*/, ValidationEventArgs^ e )
{
   if ( e->Severity == XmlSeverityType::Warning )
   {
      Console::Write( L"WARNING: " );
      Console::WriteLine( e->Message );
   }
   else
   if ( e->Severity == XmlSeverityType::Error )
   {
      Console::Write( L"ERROR: " );
      Console::WriteLine( e->Message );
   }
}

int main()
{
   XmlReaderSettings^ booksSettings = gcnew XmlReaderSettings;
   booksSettings->Schemas->Add( L"http://www.contoso.com/books", L"books.xsd" );
   booksSettings->ValidationType = ValidationType::Schema;
   booksSettings->ValidationEventHandler += gcnew ValidationEventHandler( booksSettingsValidationEventHandler );
   XmlReader^ books = XmlReader::Create( L"books.xml", booksSettings );
   while ( books->Read() )
   {}

   return 0;
}

//</snippet1>
