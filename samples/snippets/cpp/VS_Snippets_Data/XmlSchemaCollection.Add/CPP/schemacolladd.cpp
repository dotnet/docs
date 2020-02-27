#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;

public ref class Sample
{
private:
   // Display any errors.
   static void ValidationCallBack( Object^ /*sender*/, ValidationEventArgs^ e )
   {
      Console::WriteLine( "Validation Error: {0}", e->Message );
   }

public:
   static void main()
   {
      array<String^>^ args = Environment::GetCommandLineArgs();
      String^ UserName = args[ 1 ];
      String^ SecurelyStoredPassword = args[ 2 ];
      String^ Domain = args[ 3 ];

      //<snippet1>
      XmlSchemaCollection^ sc = gcnew XmlSchemaCollection;
      sc->ValidationEventHandler += gcnew ValidationEventHandler( Sample::ValidationCallBack );

      // Create a resolver with the necessary credentials.
      XmlUrlResolver^ resolver = gcnew XmlUrlResolver;
      System::Net::NetworkCredential^ nc;
      nc = gcnew System::Net::NetworkCredential( UserName,SecurelyStoredPassword,Domain );
      resolver->Credentials = nc;

      // Add the new schema to the collection.
      sc->Add( nullptr, gcnew XmlTextReader( "sample.xsd" ), resolver );
      //</snippet1>

      if ( sc->Count > 0 )
      {
         XmlTextReader^ tr = gcnew XmlTextReader( "notValidXSD.xml" );
         XmlValidatingReader^ rdr = gcnew XmlValidatingReader( tr );

         rdr->ValidationType = ValidationType::Schema;
         rdr->Schemas->Add( sc );
         rdr->ValidationEventHandler += gcnew ValidationEventHandler( Sample::ValidationCallBack );
         while ( rdr->Read() );
      }
   }
};

int main()
{
   Sample::main();
}