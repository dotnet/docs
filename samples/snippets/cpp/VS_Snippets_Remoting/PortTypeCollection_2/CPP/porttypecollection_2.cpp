

// System.Web.Services.Description.PortTypeCollection.Contains()
// System.Web.Services.Description.PortTypeCollection.Insert()
// System.Web.Services.Description.PortTypeCollection.IndexOf()
// System.Web.Services.Description.PortTypeCollection.Item[string]
/* 
The following sample demonstrates the methods 'IndexOf()','Insert()','Contains()' and
indexer 'Item[string]' of class 'PortTypeCollection'. This sample reads the contents 
of 'MathService.wsdl' into a 'ServiceDescription' instance. It gets the collection of 
'PortType' instances from 'ServiceDescription'. It removes a 'PortType' with the name 
'MathServiceSoap' and adds the same later. Then it checks whether the collection contains 
the added 'PortType'.The sample writes a new web service description file 'MathService_New.wsdl'.
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
      // <Snippet1>
      // <Snippet2>
      // <Snippet3>
      // <Snippet4>
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_CS.wsdl" );
      PortTypeCollection^ myPortTypeCollection = myServiceDescription->PortTypes;
      int noOfPortTypes = myServiceDescription->PortTypes->Count;
      Console::WriteLine( "\nTotal number of PortTypes: {0}", noOfPortTypes );
      PortType^ myNewPortType = myPortTypeCollection[ "MathServiceSoap" ];
      // </Snippet4>

      // Get the index in the collection.
      int index = myPortTypeCollection->IndexOf( myNewPortType );
      // </Snippet3>

      Console::WriteLine( "Removing the PortType named {0}", myNewPortType->Name );
      
      // Remove the PortType from the collection.
      myPortTypeCollection->Remove( myNewPortType );
      noOfPortTypes = myServiceDescription->PortTypes->Count;
      Console::WriteLine( "\nTotal number of PortTypes: {0}", noOfPortTypes );

      // Check whether the PortType exists in the collection.
      bool bContains = myPortTypeCollection->Contains( myNewPortType );
      Console::WriteLine( "Port Type'{0}' exists: {1}", myNewPortType->Name, bContains );
      Console::WriteLine( "Adding the PortType" );

      // Insert a new portType at the index location.
      myPortTypeCollection->Insert( index, myNewPortType );
      // </Snippet2>

      // Display the number of portTypes after adding a port.
      Console::WriteLine( "Total number of PortTypes after adding a new port: {0}", myServiceDescription->PortTypes->Count );
      bContains = myPortTypeCollection->Contains( myNewPortType );
      Console::WriteLine( "Port Type'{0}' exists: {1}", myNewPortType->Name, bContains );
      myServiceDescription->Write( "MathService_New.wsdl" );
      // </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
