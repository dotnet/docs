

//<snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::IO;
public ref class ValidXSD
{
public:
   static void main()
   {
      XmlSchemaCollection^ sc = gcnew XmlSchemaCollection;
      sc->ValidationEventHandler += gcnew ValidationEventHandler( ValidationCallBack );
      sc->Add( nullptr, "books.xsd" );
      if ( sc->Count > 0 )
      {
         XmlTextReader^ tr = gcnew XmlTextReader( "notValidXSD.xml" );
         XmlValidatingReader^ rdr = gcnew XmlValidatingReader( tr );
         rdr->ValidationType = ValidationType::Schema;
         rdr->Schemas->Add( sc );
         rdr->ValidationEventHandler += gcnew ValidationEventHandler( ValidationCallBack );
         while ( rdr->Read() )
                  ;
      }
   }


private:
   static void ValidationCallBack( Object^ /*sender*/, ValidationEventArgs^ e )
   {
      Console::WriteLine( "Validation Error: {0}", e->Message );
   }

};

int main()
{
   ValidXSD::main();
}

//</snippet1>
