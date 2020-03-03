

// System.Web.Services.Description.PortCollection.Insert
// System.Web.Services.Description.PortCollection.IndexOf
// System.Web.Services.Description.PortCollection.CopyTo
/*
  The following sample reads the contents of a file 'MathService.wsdl'
  into a 'ServiceDescription' instance. It gets the collection of Service
  instances from 'ServiceDescription'. It instantiates 'PortCollection' for
  each service in the collection. 'CopyTo' is called to copy
  the contents into an array. Calls 'IndexOf' for a given port.
  'Insert' method is called to insert a new port in the collection.
*/
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Xml;

int main()
{
   try
   {
      Service^ myService;
      PortCollection^ myPortCollection;
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathServiceCopyTo_cs.wsdl" );
      Console::WriteLine( "Total Number of Services :{0}", myServiceDescription->Services->Count );
      for ( int i = 0; i < myServiceDescription->Services->Count; ++i )
      {
         myService = myServiceDescription->Services[ i ];
         Console::WriteLine( "Name : {0}", myService->Name );
         
         // <Snippet1>
         // <Snippet2>
         // <Snippet3>
         myPortCollection = myService->Ports;
         
         // Create an array of Port objects.
         Console::WriteLine( "\nPort collection :" );
         array<Port^>^myPortArray = gcnew array<Port^>(myService->Ports->Count);
         myPortCollection->CopyTo( myPortArray, 0 );
         for ( int i1 = 0; i1 < myService->Ports->Count; ++i1 )
         {
            Console::WriteLine( "Port[{0}] : {1}", i1, myPortArray[ i1 ]->Name );

         }
         // </Snippet3>
         Port^ myIndexPort = myPortCollection[ 0 ];
         Console::WriteLine( "\n\nThe index of port '{0}' is : {1}", myIndexPort->Name, myPortCollection->IndexOf( myIndexPort ) );
         // </Snippet2>

         Port^ myPortTestInsert = myPortCollection[ 0 ];
         myPortCollection->Remove( myPortTestInsert );
         myPortCollection->Insert( 0, myPortTestInsert );
         Console::WriteLine( "\n\nTotal Number of Ports after inserting a new port '{0}' is : {1}", myPortTestInsert->Name, myService->Ports->Count );
         for ( int i1 = 0; i1 < myService->Ports->Count; ++i1 )
         {
            Console::WriteLine( "Port[{0}]  : {1}", i1, myPortArray[ i1 ]->Name );

         }
         myServiceDescription->Write( "MathServiceCopyToNew_cs.wsdl" );
         // </Snippet1>
      }
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "Exception:{0}", ex->Message );
   }
}
