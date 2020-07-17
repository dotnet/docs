// System::Web::Services::Discovery.DiscoveryReferenceCollection::DiscoveryReferenceCollection
// System::Web::Services::Discovery.DiscoveryReferenceCollection->Add(DiscoveryReference)
// System::Web::Services::Discovery.DiscoveryReferenceCollection::Contains(DiscoveryReference)
// System::Web::Services::Discovery.DiscoveryReferenceCollection::Item(int)
// System::Web::Services::Discovery.DiscoveryReferenceCollection::Remove(DiscoveryReference)
// System::Web::Services::Discovery.DiscoveryReferenceCollection

/* The following example demonstrates the usage of 'DiscoveryReferenceCollection' class, 'Add', 'Contains',
* 'Item'and  'Remove' methods and its constructor. A variable of 'DiscoveryReferenceCollection'
* class is taken. Two 'DiscoveryReference' type member is added to the collection. Using this
* various methods of 'DiscoveryReferenceCollection' class are demonstrated.
*/

// <Snippet1>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::IO;
using namespace System::Web::Services::Discovery;

// <Snippet2>
int main()
{
   DiscoveryDocumentReference^ myDiscoveryDocReference1 = gcnew DiscoveryDocumentReference;
   DiscoveryDocumentReference^ myDiscoveryDocReference2 = gcnew DiscoveryDocumentReference;
   DiscoveryReference^ myDiscoveryReference;
   Console::WriteLine( "Demonstrating DiscoveryReferenceCollection class." );
   
   // Create new DiscoveryReferenceCollection.
   DiscoveryReferenceCollection^ myDiscoveryReferenceCollection = gcnew DiscoveryReferenceCollection;
   
   // Access the Count method.
   Console::WriteLine( "The number of elements in the collection is: {0}", myDiscoveryReferenceCollection->Count );
   
   // Add elements to the collection.
   myDiscoveryReferenceCollection->Add( myDiscoveryDocReference1 );
   myDiscoveryReferenceCollection->Add( myDiscoveryDocReference2 );
   Console::WriteLine( "The number of elements in the collection after adding two elements to the collection: {0}", myDiscoveryReferenceCollection->Count );
   
   // Call the Contains method.
   if ( myDiscoveryReferenceCollection->Contains( myDiscoveryDocReference1 ) != true )
   {
      throw gcnew Exception( "Element not found in collection." );
   }
   
   // Access the indexed member.
   myDiscoveryReference = dynamic_cast<DiscoveryReference^>(myDiscoveryReferenceCollection[ 0 ]);
   if ( myDiscoveryReference == nullptr )
   {
      throw gcnew Exception( "Element not found in collection." );
   }
   
   // Remove one element from collection.
   myDiscoveryReferenceCollection->Remove( myDiscoveryDocReference1 );
   Console::WriteLine( "The number of elements in the collection after removing one element is: {0}", myDiscoveryReferenceCollection->Count );
}
// </Snippet2>
// </Snippet1>
