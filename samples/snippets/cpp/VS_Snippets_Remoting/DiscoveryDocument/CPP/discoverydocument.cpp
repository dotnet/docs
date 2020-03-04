

// System::Web::Services::Discovery.DiscoveryDocument
// System::Web::Services::Discovery.DiscoveryDocument::Write(TextWriter)
/* The following example deomonstrates DiscoveryDocument class and the 'Write(Stream)' method 
of the 'DiscoveryDocument' class.
A XmlTextReader Object* is created with a sample discovery file and this
is passed to the Read method to create a DiscoveryDocument. The contents
of this document is displayed onto the console using the Write(TextWriter)
method.
*/
// <Snippet1>
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
      
      // <Snippet2>
      // Write the DiscoveryDocument into the 'TextWriter'.
      FileStream^ myFileStream = gcnew FileStream( "log.txt",FileMode::OpenOrCreate,FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );
      myDiscoveryDocument->Write( myStreamWriter );
      myStreamWriter->Flush();
      myStreamWriter->Close();
      
      // </Snippet2>
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

// </Snippet1>
