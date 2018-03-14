//<snippet1>
#using <System.Xml.dll>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Schema;

public ref class Sample
{
private:
   //Display the schema error information.
   static void ValidationCallBack( Object^ sender, ValidationEventArgs^ args )
   {
      Console::WriteLine( "Invalid XSD schema: {0}", args->Exception->Message );
   }

public:
   static void main()
   {
      // Create the schema collection.
      XmlSchemaCollection^ xsc = gcnew XmlSchemaCollection;

      //Set an event handler to manage invalid schemas.
      xsc->ValidationEventHandler += gcnew ValidationEventHandler( Sample::ValidationCallBack );

      //Add the schema to the collection.  
      xsc->Add( nullptr, "invalid.xsd" );
   }
};

int main()
{
   Sample::main();
}
//</snippet1>
