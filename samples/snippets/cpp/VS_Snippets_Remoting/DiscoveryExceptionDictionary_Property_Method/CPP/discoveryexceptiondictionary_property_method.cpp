// System.Web.Services.Discovery.DiscoveryExceptionDictionary
// System.Web.Services.Discovery.DiscoveryExceptionDictionary.Contains
// System.Web.Services.Discovery.DiscoveryExceptionDictionary.Item
// System.Web.Services.Discovery.DiscoveryExceptionDictionary.Remove
// System.Web.Services.Discovery.DiscoveryExceptionDictionary.DiscoveryExceptionDictionary
// System.Web.Services.Discovery.DiscoveryExceptionDictionary.Add
// System.Web.Services.Discovery.DiscoveryExceptionDictionary.Keys
// System.Web.Services.Discovery.DiscoveryExceptionDictionary.Values

/*
The following example demonstrates the usage of the
'DiscoveryExceptionDictionary' class, the constructor
'DiscoveryExceptionDictionary()', the properties 'Item', 'Keys',
'Values' and the methods 'Contains', 'Add' and 'Remove' of the class.
The input to the program is a discovery file 'MathService_cs.disco'
which holds reference related to 'MathService_cs.asmx' web service.
The program is executed first with the file 'MathService_cs.asmx' in
the location as specified in the discovery file. The file
'MathService_cs.asmx' is removed from the referred location in a way to
simulate a scenario wherein the file related to web service is missing,
and the program is excecuted second time to show the exception occuring.
*/

// <Snippet1>
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Discovery;
using namespace System::Xml;
using namespace System::Collections;
using namespace System::Runtime::Remoting;
using namespace System::Net;

int main()
{
   String^ myDiscoFile = "http://localhost/MathService_cs.disco";
   String^ myUrlKey = "http://localhost/MathService_cs.asmx?wsdl";
   DiscoveryClientProtocol^ myDiscoveryClientProtocol1 = gcnew DiscoveryClientProtocol;
   DiscoveryDocument^ myDiscoveryDocument = myDiscoveryClientProtocol1->Discover( myDiscoFile );
   IEnumerator^ myEnumerator = myDiscoveryDocument->References->GetEnumerator();
   while ( myEnumerator->MoveNext() )
   {
      ContractReference^ myContractReference = dynamic_cast<ContractReference^>(myEnumerator->Current);
      DiscoveryClientProtocol^ myDiscoveryClientProtocol2 = myContractReference->ClientProtocol;
      myDiscoveryClientProtocol2->ResolveAll();
      
      // <Snippet2>
      DiscoveryExceptionDictionary^ myExceptionDictionary = myDiscoveryClientProtocol2->Errors;
      if ( myExceptionDictionary->Contains( myUrlKey ) == true )
      {
         Console::WriteLine( "'myExceptionDictionary' contains a discovery exception for the key '{0}'", myUrlKey );
      }
      else
      {
         Console::WriteLine( "'myExceptionDictionary' does not contain a discovery exception for the key '{0}'", myUrlKey );
      }
      // </Snippet2>
      if ( myExceptionDictionary->Contains( myUrlKey ) == true )
      {
         Console::WriteLine( "System generated exceptions." );
         
         // <Snippet3>
         Exception^ myException = myExceptionDictionary[ myUrlKey ];
         Console::WriteLine( " Source : {0}", myException->Source );
         Console::WriteLine( " Exception : {0}", myException->Message );
         // </Snippet3>

         Console::WriteLine();
         
         // <Snippet4>
         // Remove the discovery exception.for the key 'myUrlKey'.
         myExceptionDictionary->Remove( myUrlKey );
         // </Snippet4>

         // <Snippet5>
         // <Snippet6>
         DiscoveryExceptionDictionary^ myNewExceptionDictionary = gcnew DiscoveryExceptionDictionary;
         
         // Add an exception with the custom error message.
         Exception^ myNewException = gcnew Exception( "The requested service is not available." );
         myNewExceptionDictionary->Add( myUrlKey, myNewException );
         myExceptionDictionary = myNewExceptionDictionary;
         // </Snippet6>
         // </Snippet5>

         Console::WriteLine( "Added exceptions." );
         
         // <Snippet7>
         array<Object^>^myArray = gcnew array<Object^>(myExceptionDictionary->Count);
         myExceptionDictionary->Keys->CopyTo( (Array^)myArray, 0 );
         Console::WriteLine( " Keys are :" );

         for each(Object^ myObj in myArray)
         {
            Console::WriteLine(" " + myObj->ToString());
         }
         // </Snippet7>

         Console::WriteLine();
         
         // <Snippet8>
         array<Object^>^myCollectionArray = gcnew array<Object^>(myExceptionDictionary->Count);
         myExceptionDictionary->Values->CopyTo( (Array^)myCollectionArray, 0 );
         Console::WriteLine( " Values are :" );
         for each(Object^ myObj in myCollectionArray)
         {
            Console::WriteLine(" " + myObj->ToString());
         }
         // </Snippet8>
      }
   }
}
// </Snippet1>
