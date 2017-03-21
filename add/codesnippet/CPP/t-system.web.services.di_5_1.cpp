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
      
      DiscoveryExceptionDictionary^ myExceptionDictionary = myDiscoveryClientProtocol2->Errors;
      if ( myExceptionDictionary->Contains( myUrlKey ) == true )
      {
         Console::WriteLine( "'myExceptionDictionary' contains a discovery exception for the key '{0}'", myUrlKey );
      }
      else
      {
         Console::WriteLine( "'myExceptionDictionary' does not contain a discovery exception for the key '{0}'", myUrlKey );
      }
      if ( myExceptionDictionary->Contains( myUrlKey ) == true )
      {
         Console::WriteLine( "System generated exceptions." );
         
         Exception^ myException = myExceptionDictionary[ myUrlKey ];
         Console::WriteLine( " Source : {0}", myException->Source );
         Console::WriteLine( " Exception : {0}", myException->Message );

         Console::WriteLine();
         
         // Remove the discovery exception.for the key 'myUrlKey'.
         myExceptionDictionary->Remove( myUrlKey );

         DiscoveryExceptionDictionary^ myNewExceptionDictionary = gcnew DiscoveryExceptionDictionary;
         
         // Add an exception with the custom error message.
         Exception^ myNewException = gcnew Exception( "The requested service is not available." );
         myNewExceptionDictionary->Add( myUrlKey, myNewException );
         myExceptionDictionary = myNewExceptionDictionary;

         Console::WriteLine( "Added exceptions." );
         
         array<Object^>^myArray = gcnew array<Object^>(myExceptionDictionary->Count);
         myExceptionDictionary->Keys->CopyTo( (Array^)myArray, 0 );
         Console::WriteLine( " Keys are :" );

         for each(Object^ myObj in myArray)
         {
            Console::WriteLine(" " + myObj->ToString());
         }

         Console::WriteLine();
         
         array<Object^>^myCollectionArray = gcnew array<Object^>(myExceptionDictionary->Count);
         myExceptionDictionary->Values->CopyTo( (Array^)myCollectionArray, 0 );
         Console::WriteLine( " Values are :" );
         for each(Object^ myObj in myCollectionArray)
         {
            Console::WriteLine(" " + myObj->ToString());
         }
      }
   }
}