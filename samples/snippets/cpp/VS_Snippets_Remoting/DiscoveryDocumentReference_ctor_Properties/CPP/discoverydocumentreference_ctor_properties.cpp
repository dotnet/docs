

// System::Web::Services::Discovery.DiscoveryDocumentReference::DiscoveryDocumentReference(String*)
// System::Web::Services::Discovery.DiscoveryDocumentReference::Ref
// System::Web::Services::Discovery.DiscoveryDocumentReference::Url
// System::Web::Services::Discovery.DiscoveryDocumentReference::DefaultFileName
/*
This program demonstrates the 'DiscoveryDocumentReference(String*)' Constructor, 'Ref',
'Url', and 'DefaultFileName' properties of the 'DiscoveryDocumentReference' class.
It creates an instance of 'DiscoveryDocumentReference' and displays the 'Ref', 'Url' and
'DefaultFilename' properties.
*/
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Web::Services::Discovery;

int main()
{
   try
   {
      
// <Snippet1>
      DiscoveryDocumentReference^ myDiscoveryDocumentReference = 
         gcnew DiscoveryDocumentReference( 
         "http://localhost/Sample_cpp.disco" );
// </Snippet1>

      Console::WriteLine( "The reference to the discovery document is:" );
      
// <Snippet2>
      // Display the discovery document reference.
      Console::WriteLine( myDiscoveryDocumentReference->Ref );
// </Snippet2>
      Console::WriteLine();
      Console::WriteLine( 
         "The URL of the referenced discovery document is:" );
      
// <Snippet3>
      // Display the URL of the referenced discovery document.
      Console::WriteLine( myDiscoveryDocumentReference->Url );
// </Snippet3>
      Console::WriteLine();
      Console::WriteLine( "The name of the default disco file is:" );
      
// <Snippet4>
      // Display the name of the default file used for reference.
      Console::WriteLine( 
         myDiscoveryDocumentReference->DefaultFilename );
// </Snippet4>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}

