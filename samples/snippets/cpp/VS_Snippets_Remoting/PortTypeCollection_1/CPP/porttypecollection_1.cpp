

// System.Web.Services.Description.PortTypeCollection.Item[int]
// System.Web.Services.Description.PortTypeCollection.Remove()
// System.Web.Services.Description.PortTypeCollection.Add()
/*The following sample demonstrates the indexer 'Item[int]', methods
'Remove()' and 'Add()' of class 'PortTypeCollection'. It reads the
contents of a file 'MathService.wsdl'into a 'ServiceDescription' instance.
It gets the collection of 'PortType' from 'ServiceDescription' and adds
a new PortType and writes a new web service description file into 
'MathService_New.wsdl'.
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
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_CS.wsdl" );
      PortTypeCollection^ myPortTypeCollection = myServiceDescription->PortTypes;
      int noOfPortTypes = myServiceDescription->PortTypes->Count;
      Console::WriteLine( "\nTotal number of PortTypes: {0}", myServiceDescription->PortTypes->Count );

      // Get the first PortType in the collection.
      PortType^ myNewPortType = myPortTypeCollection[ 0 ];
      Console::WriteLine( "The PortType at index 0 is: {0}", myNewPortType->Name );
      Console::WriteLine( "Removing the PortType {0}", myNewPortType->Name );

      // Remove the PortType from the collection.
      myPortTypeCollection->Remove( myNewPortType );

      // Display the number of PortTypes.
      Console::WriteLine( "\nTotal number of PortTypes after removing: {0}", myServiceDescription->PortTypes->Count );
      Console::WriteLine( "Adding a PortType {0}", myNewPortType->Name );

      // Add a new PortType from the collection.
      myPortTypeCollection->Add( myNewPortType );

      // Display the number of PortTypes after adding a port.
      Console::WriteLine( "Total number of PortTypes after adding a new port: {0}", myServiceDescription->PortTypes->Count );
      myServiceDescription->Write( "MathService_New.wsdl" );
      // </Snippet3>
      // </Snippet2>
      // </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
