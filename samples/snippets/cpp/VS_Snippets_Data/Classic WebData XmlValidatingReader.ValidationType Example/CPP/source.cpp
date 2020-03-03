

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
      String^ doc1 = "notValid.xml";
      String^ doc2 = "cdDTD.xml";
      String^ doc3 = "book1.xml";
      
      //Parse the files and validate when requested.
      Validate( doc1, ValidationType::XDR ); //Validation should fail.
      Validate( doc2, ValidationType::DTD ); //Validation should fail.
      Validate( doc3, ValidationType::None ); //No validation performed.
   }


private:
   void Validate( String^ filename, ValidationType vt )
   {
      try
      {
         
         //Implement the readers.  Set the ValidationType.
         txtreader = gcnew XmlTextReader( filename );
         reader = gcnew XmlValidatingReader( txtreader );
         reader->ValidationType = vt;
         
         //If the reader is set to validate, set the event handler.
         if ( vt == ValidationType::None )
                  Console::WriteLine( "\nParsing XML file {0}", filename );
         else
         {
            Console::WriteLine( "\nValidating XML file {0}", filename );
            m_success = true;
            
            //Set the validation event handler.
            reader->ValidationEventHandler += gcnew ValidationEventHandler( this, &Sample::ValidationCallBack );
         }
         
         // Read XML data
         while ( reader->Read() )
         {}
         if ( vt == ValidationType::None )
                  Console::WriteLine( "Finished parsing file." );
         else
                  Console::WriteLine( "Validation finished. Validation {0}", m_success ? (String^)"successful" : "failed" );
      }
      finally
      {
         
         //Close the reader.
         if ( reader != nullptr )
                  reader->Close();
      }

   }


   //Display the validation errors.
   void ValidationCallBack( Object^ /*sender*/, ValidationEventArgs^ args )
   {
      m_success = false;
      Console::Write( "\r\n\tValidation error: {0}", args->Message );
   }

};

int main()
{
   gcnew Sample;
}

// </Snippet1>
