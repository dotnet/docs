

// <Snippet1>
#using <System.Xml.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Xml::Schema;
public ref class Sample
{
private:
   XmlTextReader^ txtreader;
   XmlValidatingReader^ reader;
   Boolean m_success;

public:
   Sample()
   {
      txtreader = nullptr;
      reader = nullptr;
      m_success = true;
      
      //Validate file against the XSD schema. 
      //The validation should fail.
      Validate( "notValidXSD.xml" );
   }


private:
   void Validate( String^ filename )
   {
      try
      {
         Console::WriteLine( "Validating XML file {0}", filename );
         txtreader = gcnew XmlTextReader( filename );
         reader = gcnew XmlValidatingReader( txtreader );
         
         // Set the validation event handler
         reader->ValidationEventHandler += gcnew ValidationEventHandler( this, &Sample::ValidationEventHandle );
         
         // Read XML data
         while ( reader->Read() )
         {}
         Console::WriteLine( "Validation finished. Validation {0}", (m_success == true ? (String^)"successful" : "failed") );
      }
      finally
      {
         
         //Close the reader.
         if ( reader != nullptr )
                  reader->Close();
      }

   }


   //Display the validation error.
   void ValidationEventHandle( Object^ /*sender*/, ValidationEventArgs^ args )
   {
      m_success = false;
      Console::WriteLine( "\r\n\tValidation error: {0}", args->Message );
   }

};

int main()
{
   gcnew Sample;
}

// </Snippet1>
