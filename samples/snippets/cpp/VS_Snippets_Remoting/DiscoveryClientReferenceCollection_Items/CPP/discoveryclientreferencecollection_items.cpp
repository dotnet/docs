/*
System::Web::Services::Discovery.DiscoveryClientReferenceCollection::DiscoveryClientReferenceCollection
System::Web::Services::Discovery.DiscoveryClientReferenceCollection->Add(DiscoveryReference)
System::Web::Services::Discovery.DiscoveryClientReferenceCollection->Add(DiscoveryReference, url)
System::Web::Services::Discovery.DiscoveryClientReferenceCollection::Remove
System::Web::Services::Discovery.DiscoveryClientReferenceCollection::Item

The following example demonstrates the 'constructor' and various members of
the class 'DiscoveryClientReferenceCollection'. The 'Add(DiscoveryReference)'
method adds a DocumentReference Object* to the DiscoveryClientDocumentCollection
collection. The Add(url, DiscoveryReference) method adds a DiscoveryReference
with the specified Url. The 'Remove' method removes a DiscoveryReference with
the specified Url from the 'DiscoveryClientReferenceCollection' collection.
The 'Item' property gets or sets a DiscoveryReference Object* from the
'DiscoveryClientReferenceCollection' with the specified Url.
*/

#using <System.Web.Services.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Web::Services::Discovery;

int main()
{
   // <Snippet5>
   // <Snippet2>
   // <Snippet1>
   DiscoveryClientReferenceCollection^ myDiscoveryClientReferenceCollection = gcnew DiscoveryClientReferenceCollection;
   ContractReference^ myContractReference = gcnew ContractReference;
   String^ myStringUrl1 = "http://www.contoso.com/service1.disco";
   myContractReference->Ref = myStringUrl1;
   myDiscoveryClientReferenceCollection->Add( myContractReference );
   // </Snippet1>
   // </Snippet2>

   // myDiscoveryClientReferenceCollection is an instance collection.
   Object^ myObject = myDiscoveryClientReferenceCollection[ myStringUrl1 ];
   Console::WriteLine( "Object representing the URL: {0}", myObject );
   // </Snippet5>

   Console::WriteLine( "" );
   
   // <Snippet4>
   // <Snippet3>
   DiscoveryDocumentReference^ myDiscoveryDocumentReference = gcnew DiscoveryDocumentReference;
   String^ myStringUrl = "http://www.contoso.com/service.disco";
   myDiscoveryClientReferenceCollection->Add( myStringUrl, myDiscoveryDocumentReference );
   // </Snippet3>

   myDiscoveryClientReferenceCollection->Remove( myStringUrl );
   // </Snippet4>

   // Retrieve the keys in the collection.
   ICollection^ myCollection = myDiscoveryClientReferenceCollection->Keys;
   array<Object^>^myObjectCollection = gcnew array<Object^>(myDiscoveryClientReferenceCollection->Count);
   myCollection->CopyTo( myObjectCollection, 0 );
   Console::WriteLine( "The discovery documents, service descriptions, and" );
   Console::WriteLine( "XML schema definitions in the collection are:" );
   for ( int iIndex = 0; iIndex < myObjectCollection->Length; iIndex++ )
   {
      Console::WriteLine( myObjectCollection[ iIndex ] );
   }
   Console::WriteLine( "" );
   
   // Retrieve the values in the collection.
   ICollection^ myCollection1 = myDiscoveryClientReferenceCollection->Values;
   array<Object^>^myObjectCollection1 = gcnew array<Object^>(myDiscoveryClientReferenceCollection->Count);
   myCollection1->CopyTo( myObjectCollection1, 0 );
   Console::WriteLine( "The objects in the collection are:" );
   for ( int iIndex = 0; iIndex < myObjectCollection1->Length; iIndex++ )
   {
      Console::WriteLine( myObjectCollection1[ iIndex ] );
   }
}
