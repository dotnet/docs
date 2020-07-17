/*
System::Web::Services::Discovery.DiscoveryClientReferenceCollection::Keys
System::Web::Services::Discovery.DiscoveryClientReferenceCollection::Values
System::Web::Services::Discovery.DiscoveryClientReferenceCollection::Contains

The following example demonstrates the 'Keys', 'Values' properties and
the method 'Contains' of the class 'DiscoveryClientReferenceCollection'. A sample
discovery document is read and the 'Keys', 'Values' and 'Contains' properties
are displayed.
*/

#using <System.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Net;
using namespace System::Collections;
using namespace System::Web::Services::Discovery;

int main()
{
// <Snippet1>
   DiscoveryClientProtocol^ myDiscoveryClientProtocol = gcnew DiscoveryClientProtocol;
   myDiscoveryClientProtocol->Credentials = CredentialCache::DefaultCredentials;
   
   // 'dataservice.disco' is a sample discovery document.
   String^ myStringUrl = "http://localhost/dataservice.disco";
   
   // Call the Discover method to populate the References property.
   DiscoveryDocument^ myDiscoveryDocument = myDiscoveryClientProtocol->Discover( myStringUrl );
   
   // Resolve all references found in the discovery document.
   myDiscoveryClientProtocol->ResolveAll();
   DiscoveryClientReferenceCollection^ myDiscoveryClientReferenceCollection = myDiscoveryClientProtocol->References;
   
   // Retrieve the keys in the collection.
   ICollection^ myCollection = myDiscoveryClientReferenceCollection->Keys;
   array<Object^>^myObjectCollection = gcnew array<Object^>(myDiscoveryClientReferenceCollection->Count);
   myCollection->CopyTo( myObjectCollection, 0 );
   Console::WriteLine( "The discovery documents, service descriptions, and XML schema" );
   Console::WriteLine( " definitions in the collection are:" );
   for ( int iIndex = 0; iIndex < myObjectCollection->Length; iIndex++ )
   {
      Console::WriteLine( myObjectCollection[ iIndex ] );
   }
//</Snippet1>
   Console::WriteLine( "" );
// <Snippet2>
   // Retrieve the values in the collection.
   ICollection^ myCollection1 = myDiscoveryClientReferenceCollection->Values;
   array<Object^>^myObjectCollection1 = gcnew array<Object^>(myDiscoveryClientReferenceCollection->Count);
   myCollection1->CopyTo( myObjectCollection1, 0 );
   Console::WriteLine( "The objects in the collection are:" );
   for ( int iIndex = 0; iIndex < myObjectCollection1->Length; iIndex++ )
   {
      Console::WriteLine( myObjectCollection1[ iIndex ] );
   }
//</Snippet2>
   Console::WriteLine( "" );
// <Snippet3>
   String^ myStringUrl1 = "http://localhost/dataservice.disco";
   if ( myDiscoveryClientReferenceCollection->Contains( myStringUrl1 ) )
   {
      Console::WriteLine( "The document reference {0} is part of the  collection.", myStringUrl1 );
   }
// </Snippet3>
}
