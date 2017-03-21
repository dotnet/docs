#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Xml;
using namespace System::IO;
using namespace System::Web::Services::Discovery;
using namespace System::Collections;
int main()
{
   try
   {
      
      // Create an Object* of the 'DiscoveryDocument'.
      DiscoveryDocument^ myDiscoveryDocument = gcnew DiscoveryDocument;
      
      // Create an XmlTextReader with the sample file.
      XmlTextReader^ myXmlTextReader = gcnew XmlTextReader( "http://localhost/example_cs.disco" );
      
      // Read the given XmlTextReader.
      myDiscoveryDocument = DiscoveryDocument::Read( myXmlTextReader );
      
      // Write the DiscoveryDocument into the 'TextWriter'.
      FileStream^ myFileStream = gcnew FileStream( "log.txt",FileMode::OpenOrCreate,FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myDiscoveryDocument->Write( myStreamWriter );
      myStreamWriter->Flush();
      myStreamWriter->Close();
      
      // Display the contents of the DiscoveryDocument onto the console.
      FileStream^ myFileStream1 = gcnew FileStream( "log.txt",FileMode::OpenOrCreate,FileAccess::Read );
      StreamReader^ myStreamReader = gcnew StreamReader( myFileStream1 );
      
      // Set the file pointer to the begin.
      myStreamReader->BaseStream->Seek( 0, SeekOrigin::Begin );
      Console::WriteLine( "The contents of the DiscoveryDocument are-" );
      while ( myStreamReader->Peek() > -1 )
      {
         Console::WriteLine( myStreamReader->ReadLine() );
      }
      myStreamReader->Close();
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception raised : {0}", e->Message );
   }

}
