

// <Snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Schema;

public ref class SchemaCollectionSample
{
private:
   XmlTextReader^ reader;
   XmlValidatingReader^ vreader;
   Boolean m_success;

public:
   SchemaCollectionSample()
   {
      reader = nullptr;
      vreader = nullptr;
      m_success = true;

      //Load the schema collection.
      XmlSchemaCollection^ xsc = gcnew XmlSchemaCollection;
      String^ schema = "books.xsd";
      String^ schema1 = "schema1.xdr";
      xsc->Add( "urn:bookstore-schema", schema ); //XSD schema
      xsc->Add( "urn:newbooks-schema", schema1 ); //XDR schema
      String^ doc1 = "booksSchema.xml";
      String^ doc2 = "booksSchemaFail.xml";
      String^ doc3 = "newbooks.xml";

      //Validate the files using schemas stored in the collection.
      Validate( doc1, xsc ); //Should pass.
      Validate( doc2, xsc ); //Should fail.   
      Validate( doc3, xsc ); //Should fail. 
   }


private:
   void Validate( String^ filename, XmlSchemaCollection^ xsc )
   {
      m_success = true;
      Console::WriteLine();
      Console::WriteLine( "Validating XML file {0}...", filename );
      reader = gcnew XmlTextReader( filename );

      //Create a validating reader.
      vreader = gcnew XmlValidatingReader( reader );

      //Validate using the schemas stored in the schema collection.
      vreader->Schemas->Add( xsc );

      //Set the validation event handler
      vreader->ValidationEventHandler += gcnew ValidationEventHandler( this, &SchemaCollectionSample::ValidationCallBack );

      //Read and validate the XML data.
      while ( vreader->Read() )
      {}

      Console::WriteLine( "Validation finished. Validation {0}", (m_success == true ? (String^)"successful" : "failed") );
      Console::WriteLine();

      //Close the reader.
      vreader->Close();
   }

   void ValidationCallBack( Object^ /*sender*/, ValidationEventArgs^ args )
   {
      m_success = false;
      Console::Write( "\r\n\tValidation error: {0}", args->Message );
   }

};

int main()
{
   gcnew SchemaCollectionSample;
}
// </Snippet1>
