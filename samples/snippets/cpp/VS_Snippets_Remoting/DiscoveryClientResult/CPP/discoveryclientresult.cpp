

// System.Web.Services.DiscoveryClientResult
/*
The following example demonstrates 'DiscoveryClientResult' class.
A 'DiscoveryClientResultCollection' object is obtained by reading a
'.discomap' file which contains the 'DiscoveryClientResult' objects,
representing the details of discovery references. The contents of this
collection are displayed..
*/
// <Snippet1>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Discovery;
int main()
{
   try
   {
      DiscoveryClientProtocol^ myDiscoveryClientProtocol = gcnew DiscoveryClientProtocol;
      
      // Get the collection holding DiscoveryClientResult objects.
      DiscoveryClientResultCollection^ myDiscoveryClientResultCollection = myDiscoveryClientProtocol->ReadAll( "results.discomap" );
      Console::WriteLine( "The number of DiscoveryClientResult objects: {0}", myDiscoveryClientResultCollection->Count );
      Console::WriteLine( "Displaying the items in the collection:" );
      
      // Iterate through the collection and display the properties
      // of each DiscoveryClientResult in it.
      System::Collections::IEnumerator^ myEnum = myDiscoveryClientResultCollection->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DiscoveryClientResult^ myDiscoveryClientResult = safe_cast<DiscoveryClientResult^>(myEnum->Current);
         Console::WriteLine( "Type of reference in the discovery document: {0}", myDiscoveryClientResult->ReferenceTypeName );
         Console::WriteLine( "Url for the reference: {0}", myDiscoveryClientResult->Url );
         Console::WriteLine( "File for saving the reference: {0}", myDiscoveryClientResult->Filename );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Error is {0}", e->Message );
   }

}

// </Snippet1>
