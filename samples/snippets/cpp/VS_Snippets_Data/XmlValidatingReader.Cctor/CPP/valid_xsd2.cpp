

//<snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Schema;
public ref class Sample
{
private:
   static Boolean m_success = true;

public:
   Sample()
   {
      
      // Validate the document using an external XSD schema.  Validation should fail.
      Validate( "notValidXSD.xml" );
      
      // Validate the document using an inline XSD. Validation should succeed.
      Validate( "inlineXSD.xml" );
   }


private:

   // Display the validation error.
   void ValidationCallBack( Object^ /*sender*/, ValidationEventArgs^ args )
   {
      m_success = false;
      Console::WriteLine( "\r\n\tValidation error: {0}", args->Message );
   }

   void Validate( String^ filename )
   {
      m_success = true;
      Console::WriteLine( "\r\n******" );
      Console::WriteLine( "Validating XML file {0}", filename );
      XmlTextReader^ txtreader = gcnew XmlTextReader( filename );
      XmlValidatingReader^ reader = gcnew XmlValidatingReader( txtreader );
      
      // Set the validation event handler
      reader->ValidationEventHandler += gcnew ValidationEventHandler( this, &Sample::ValidationCallBack );
      
      // Read XML data
      while ( reader->Read() )
      {}

      Console::WriteLine( "Validation finished. Validation {0}", (m_success == true ? (String^)"successful!" : "failed.") );
      
      // Close the reader.
      reader->Close();
   }

};

int main()
{
   Sample^ validation = gcnew Sample;
}

//</snippet1>
