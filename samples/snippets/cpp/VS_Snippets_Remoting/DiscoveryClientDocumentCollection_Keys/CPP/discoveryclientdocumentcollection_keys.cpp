/*
System::Web::Services::Discovery.DiscoveryClientDocumentCollection::Keys
System::Web::Services::Discovery.DiscoveryClientDocumentCollection::Values
System::Web::Services::Discovery.DiscoveryClientDocumentCollection::Contains(String)

The following example demonstrates the 'Keys', 'Values' properties
and the 'Contains' method. The 'Keys' property returns the names
the discoverydocuments in the 'DiscoveryClientDocumentCollection' and 
the 'Values' property returns the type of objects in the 
'DiscoveryClientDocumentCollection'. A sample discovery document is read
and the properties 'Keys' and 'Values' and the method 'Contains' are 
displayed.
*/

#using <System.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Collections;
using namespace System::Web::Services::Discovery;

int main()
{
   DiscoveryClientProtocol^ myDiscoveryClientProtocol = gcnew DiscoveryClientProtocol;
   myDiscoveryClientProtocol->Credentials = CredentialCache::DefaultCredentials;
   
   // 'dataservice.disco' is a sample discovery document.
   String^ myStringUrl = "http://localhost/dataservice.disco";
   
   // 'Discover' method is called to populate the 'Documents' property.
   myDiscoveryClientProtocol->Discover( myStringUrl );
   DiscoveryClientDocumentCollection^ myDiscoveryClientDocumentCollection =
      myDiscoveryClientProtocol->Documents;
   
   // 'Keys' in the collection are retrieved.
   // <Snippet1>
   ICollection^ myCollection = myDiscoveryClientDocumentCollection->Keys;
   array<Object^>^myObjectCollection =
      gcnew array<Object^>(myDiscoveryClientDocumentCollection->Count);
   myCollection->CopyTo( myObjectCollection, 0 );
   Console::WriteLine( "The discovery documents in the collection are :" );
   for ( int iIndex = 0; iIndex < myObjectCollection->Length; iIndex++ )
      Console::WriteLine( myObjectCollection[ iIndex ] );
   // </Snippet1>

   Console::WriteLine( "" );
   
   // <Snippet2>
   // 'Values' in the collection are retrieved.
   ICollection^ myCollection1 = myDiscoveryClientDocumentCollection->Values;
   array<Object^>^myObjectCollection1 =
      gcnew array<Object^>(myDiscoveryClientDocumentCollection->Count);
   myCollection1->CopyTo( myObjectCollection1, 0 );
   Console::WriteLine( "The objects in the collection are :" );
   for ( int iIndex = 0; iIndex < myObjectCollection1->Length; iIndex++ )
      Console::WriteLine( myObjectCollection1[ iIndex ] );
   // </Snippet2>

   Console::WriteLine( "" );
   
   // <Snippet3>
   bool myContains = myDiscoveryClientDocumentCollection->Contains( myStringUrl );
   if ( myContains )
      Console::WriteLine( "The discovery document {0} is present in the  Collection", myStringUrl );
   // </Snippet3>
}
