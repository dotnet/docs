

// System::Web::Services::Discovery.DiscoveryDocumentReference
// System::Web::Services::Discovery.DiscoveryDocumentReference::DiscoveryDocumentReference()
// System::Web::Services::Discovery.DiscoveryDocumentReference::WriteDocument(Object*, Stream)
/*
This program demonstrates the 'DiscoveryDocumentReference' class, default constructor and
'WriteDocument(Object*, Stream)' method of the 'DiscoveryDocumentReference' class.
Discovery file is read by using 'DiscoveryDocument' instance. Write this discovery
document into a file stream and print its contents on the console.
*/
// <Snippet1>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Web::Services::Discovery;
using namespace System::IO;
using namespace System::Collections;
int main()
{
   try
   {
      DiscoveryDocument^ myDiscoveryDocument;
      XmlTextReader^ myXmlTextReader = gcnew XmlTextReader( "http://localhost/Sample_cs::vsdisco" );
      myDiscoveryDocument = DiscoveryDocument::Read( myXmlTextReader );
      
      // <Snippet2>
      // Create a new instance of DiscoveryDocumentReference.
      DiscoveryDocumentReference^ myDiscoveryDocumentReference = gcnew DiscoveryDocumentReference;
      
      // </Snippet2>
      // <Snippet3>
      FileStream^ myFileStream = gcnew FileStream( "Temp::vsdisco",FileMode::OpenOrCreate,FileAccess::Write );
      myDiscoveryDocumentReference->WriteDocument( myDiscoveryDocument, myFileStream );
      myFileStream->Close();
      
      // </Snippet3>
      FileStream^ myFileStream1 = gcnew FileStream( "Temp::vsdisco",FileMode::OpenOrCreate,FileAccess::Read );
      StreamReader^ myStreamReader = gcnew StreamReader( myFileStream1 );
      
      // Initialize the file pointer.
      myStreamReader->BaseStream->Seek( 0, SeekOrigin::Begin );
      Console::WriteLine( "The contents of the discovery document are: \n" );
      while ( myStreamReader->Peek() > -1 )
      {
         
         // Display the contents of the discovery document.
         Console::WriteLine( myStreamReader->ReadLine() );
      }
      myStreamReader->Close();
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }

}

// </Snippet1>
