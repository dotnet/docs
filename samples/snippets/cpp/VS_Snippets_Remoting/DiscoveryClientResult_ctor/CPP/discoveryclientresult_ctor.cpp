// System.Web.Services.Discovery.DiscoveryClientResult(Type,String,String)

/*
The following example demonstrates the DiscoveryClientResult(Type,String,String)
constructor of 'DiscoveryClientResult' class.
A 'DiscoveryClientResultCollection' object is obtained by reading a '.discomap' file 
which contains the 'DiscoveryClientResult' objects, representing the details of 
discovery references. A 'DiscoveryClientProtocol' object from the collection is 
removed. Then a 'DiscoveryClientProtocol' is created suppling the type of reference
in the discovery document, URL for the reference and  name of the file in which the
reference is saved.and programmatically added to it. The contents of this collection 
are displayed.
*/

#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Web::Services::Discovery;

int main()
{
   try
   {
      DiscoveryClientProtocol^ myDiscoveryClientProtocol = gcnew DiscoveryClientProtocol;

      // Get the collection of DiscoveryClientResult objects.
      DiscoveryClientResultCollection^ myDiscoveryClientResultCollection =
         myDiscoveryClientProtocol->ReadAll( "results.discomap" );
      Console::WriteLine( "The number of DiscoveryClientResult objects: {0}", myDiscoveryClientResultCollection->Count );
      Console::WriteLine( "Removing a DiscoveryClientResult "
      "from the collection..." );

      // Remove first DiscoveryClientResult from the collection.
      myDiscoveryClientResultCollection->Remove( myDiscoveryClientResultCollection[ 0 ] );
      Console::WriteLine( "Adding a DiscoveryClientResult "
      "to the collection..." );

      // <Snippet1>
      // Initialize a new instance of the DiscoveryClientResult class.
      DiscoveryClientResult^ myDiscoveryClientResult =
         gcnew DiscoveryClientResult( System::Web::Services::Discovery::DiscoveryDocumentReference::typeid,
         "http://localhost/Discovery/Service1_cs.asmx?disco","Service1_cs.disco" );

      // Add the DiscoveryClientResult to the collection.
      myDiscoveryClientResultCollection->Add( myDiscoveryClientResult );
      // </Snippet1>

      Console::WriteLine( "Displaying the items in the collection" );
      for ( int i = 0; i < myDiscoveryClientResultCollection->Count; i++ )
      {
         DiscoveryClientResult^ myClientResult = myDiscoveryClientResultCollection[ i ];
         Console::WriteLine( "DiscoveryClientResult Object {0}", (i + 1) );
         Console::WriteLine( "Type of reference in the discovery document: {0}", myClientResult->ReferenceTypeName );
         Console::WriteLine( "URL for reference: {0}", myClientResult->Url );
         Console::WriteLine( "File for saving the reference: {0}", myClientResult->Filename );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Error is {0}", e->Message );
   }
}
