/*
System::Web::Services::Discovery.DiscoveryClientDocumentCollection::DiscoveryClientDocumentCollection
System::Web::Services::Discovery.DiscoveryClientDocumentCollection->Add
System::Web::Services::Discovery.DiscoveryClientDocumentCollection::Remove
System::Web::Services::Discovery.DiscoveryClientDocumentCollection::Item

The following example demonstrates the constructor, the 'Add' and 
'Remove' methods and the 'Item' property. The method 'Add', adds a
discovery document Object* to the DiscoveryClientDocumentCollection.
The method 'Remove', removes a discovery document Object* from the
DiscoveryClientDocumentCollection. The Item property is used to 
retrieve an Object* in the DiscoveryClientDocumentCollection. A sample
discovery document is read and the methods 'Add', 'Remove' and the 
property 'Item' are applied on the sample.
*/

#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Collections;
using namespace System::Web::Services::Discovery;

int main()
{
   // <Snippet3>
   // <Snippet2>
   // <Snippet1>
   DiscoveryClientDocumentCollection^ myDiscoveryClientDocumentCollection = gcnew DiscoveryClientDocumentCollection;
   // </Snippet1>

   DiscoveryDocument^ myDiscoveryDocument = gcnew DiscoveryDocument;
   String^ myStringUrl = "http://www.contoso.com/service.disco";
   String^ myStringUrl1 = "http://www.contoso.com/service1.disco";
   myDiscoveryClientDocumentCollection->Add( myStringUrl, myDiscoveryDocument );
   myDiscoveryClientDocumentCollection->Add( myStringUrl1, myDiscoveryDocument );
   // </Snippet2>

   myDiscoveryClientDocumentCollection->Remove( myStringUrl1 );
   // </Snippet3>

   // <Snippet4>
   Object^ myObject = myDiscoveryClientDocumentCollection[ myStringUrl ];
   Console::WriteLine( "Object representing the Url : {0}", myObject );
   // </Snippet4>

   Console::WriteLine( "" );
   
   // 'Keys' in the collection are retrieved.
   ICollection^ myCollection = myDiscoveryClientDocumentCollection->Keys;
   array<Object^>^myObjectCollection = gcnew array<Object^>(myDiscoveryClientDocumentCollection->Count);
   myCollection->CopyTo( myObjectCollection, 0 );
   Console::WriteLine( "The discovery documents in the collection are :" );
   for ( int iIndex = 0; iIndex < myObjectCollection->Length; iIndex++ )
   {
      Console::WriteLine( myObjectCollection[ iIndex ] );
   }
   Console::WriteLine( "" );
   
   // 'Values' in the collection are retrieved.
   ICollection^ myCollection1 = myDiscoveryClientDocumentCollection->Values;
   array<Object^>^myObjectCollection1 = gcnew array<Object^>(myDiscoveryClientDocumentCollection->Count);
   myCollection1->CopyTo( myObjectCollection1, 0 );
   Console::WriteLine( "The objects in the collection are :" );
   for ( int iIndex = 0; iIndex < myObjectCollection1->Length; iIndex++ )
      Console::WriteLine( myObjectCollection1[ iIndex ] );
}
