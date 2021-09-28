

// System::Web::Services::Discovery.DiscoveryDocumentReference::ReadDocument(stream)
/*
This program demonstrates the 'ReadDocument(stream)' of 'DiscoveryDocumentReference'
class. Read the contents of the discovery document from the stream and returns
discovery document reference. The references of the 'DiscoveryDocumentReference'
are printed.
*/
#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services::Discovery;
using namespace System::IO;
using namespace System::Collections;
int main()
{
   try
   {
      // <Snippet1>
      String^ myUrl = "http://localhost/Sample_cs.vsdisco";
      DiscoveryClientProtocol^ myProtocol = gcnew DiscoveryClientProtocol;
      DiscoveryDocumentReference^ myReference = gcnew DiscoveryDocumentReference( myUrl );
      Stream^ myFileStream = myProtocol->Download( myUrl );
      DiscoveryDocument^ myDiscoveryDocument = dynamic_cast<DiscoveryDocument^>(myReference->ReadDocument( myFileStream ));
      // </Snippet1>

      IEnumerator^ myEnumerator = myDiscoveryDocument->References->GetEnumerator();
      Console::WriteLine( "\nThe references to the discovery document are : \n" );
      while ( myEnumerator->MoveNext() )
      {
         DiscoveryDocumentReference^ myNewReference = dynamic_cast<DiscoveryDocumentReference^>(myEnumerator->Current);

         // Print the discovery document references on the console.
         Console::WriteLine( myNewReference->Url );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
