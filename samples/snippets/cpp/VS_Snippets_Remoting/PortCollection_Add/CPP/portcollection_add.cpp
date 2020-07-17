

// System.Web.Services.Description.PortCollection.Contains
// System.Web.Services.Description.PortCollection.Add
/* 
  The following sample reads the contents of a file 'MathServiceAdd_cs.wsdl'
  into a 'ServiceDescription' instance. It gets the collection of Service 
  instances from 'ServiceDescription'. It then adds a new port and checks 
  whether a port exists.  The programs writes a new web service description
  file.
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
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathServiceAdd_cs.wsdl" );
      Console::WriteLine( "\nTotal Number of Services :{0}", myServiceDescription->Services->Count );
      for ( int i = 0; i < myServiceDescription->Services->Count; ++i )
      {
         myService = myServiceDescription->Services[ i ];
         Console::WriteLine( "Name : {0}", myService->Name );

         // <Snippet1>
         // <Snippet2>         
         myPortCollection = myService->Ports;
         Port^ myNewPort = myPortCollection[ 0 ];
         myPortCollection->Remove( myNewPort );

         // Display the number of ports.
         Console::WriteLine( "\nTotal number of ports before adding a new port : {0}", myService->Ports->Count );

         // Add a new port.
         myPortCollection->Add( myNewPort );

         // Display the number of ports after adding a port.
         Console::WriteLine( "Total number of ports after adding a new port : {0}", myService->Ports->Count );
         // </Snippet2>

         bool bContain = myPortCollection->Contains( myNewPort );
         Console::WriteLine( "\nPort '{0}' exists : {1}", myNewPort->Name, bContain );

         // Remove a port from the collection.
         myPortCollection->Remove( myPortCollection[ myNewPort->Name ] );
         bContain = myPortCollection->Contains( myNewPort );
         Console::WriteLine( "Port '{0}' exists : {1}", myNewPort->Name, bContain );

         // Create the description file.
         myPortCollection->Insert( 0, myNewPort );
         myServiceDescription->Write( "MathServiceAddNew_cs.wsdl" );
         // </Snippet1>         

      }
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "Exception:{0}", ex->Message );
   }
}
