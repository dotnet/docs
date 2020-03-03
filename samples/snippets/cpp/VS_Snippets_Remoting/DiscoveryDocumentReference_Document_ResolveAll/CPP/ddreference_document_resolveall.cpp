

// System::Web::Services::Discovery.DiscoveryDocumentReference::Document
// System::Web::Services::Discovery.DiscoveryDocumentReference::ResolveAll()
/*
This program demonstrates the 'Document' property and 'ResolveAll()' method of
'DiscoveryDocumentReference' class. Set the 'ClientProtocol' of
'DiscoveryDocumentReference' class. The validity of the documents within the discovery
document is verified using the 'ResolveAll' method and the valid references to the
discovery documents are displayed on the console using the 'Document' property.
*/
// <Snippet12>
#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services::Discovery;
using namespace System::Collections;
int main()
{
   try
   {
      // <Snippet11>
      String^ myUrl = "http://localhost/Sample_cs.vsdisco";
      DiscoveryClientProtocol^ myProtocol = gcnew DiscoveryClientProtocol;

      // Get the discovery document myDiscoveryDocument.
      DiscoveryDocument^ myDiscoveryDocument = myProtocol->Discover( myUrl );

      // Get the references of myDiscoveryDocument.
      IEnumerator^ myEnumerator = myDiscoveryDocument->References->GetEnumerator();
      while ( myEnumerator->MoveNext() )
      {
         DiscoveryDocumentReference^ myNewReference = dynamic_cast<DiscoveryDocumentReference^>(myEnumerator->Current);

         // Set the ClientProtocol of myNewReference.
         DiscoveryClientProtocol^ myNewProtocol = myNewReference->ClientProtocol;

         // Verify for all the valid references.
         myNewReference->ResolveAll();

         // Get the document of myNewReference.
         DiscoveryDocument^ myNewDiscoveryDocument = myNewReference->Document;
         IEnumerator^ myNewEnumerator = myNewDiscoveryDocument->References->GetEnumerator();
         Console::WriteLine( "The valid discovery document is : \n" );
         while ( myNewEnumerator->MoveNext() )
         {
            // Display the references of myNewDiscoveryDocument on the console.
            Console::WriteLine( (dynamic_cast<DiscoveryDocumentReference^>(myNewEnumerator->Current))->Ref );
         }
      }
      // </Snippet11>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
   }
}
// </Snippet12>
