

// System.Web.Services.Description.PortTypeCollection
/* The following sample demonstrates the class 'PortTypeCollection'. It reads the
contents of  WSDL document 'MathService.wsdl'into a 'ServiceDescription' instance.
It gets the collection of 'PortType'from 'ServiceDescription'. It copies the
collection into an array of 'PortType' and displays their names. Then it removes a
'PortType', checks whether the collection contains the removed 'PortType'.
It adds the same 'PortType' and writes a new web service description file into 
'MathService_New.wsdl'.
*/
// <Snippet1>
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Xml;
using namespace System::Collections;
int main()
{
   try
   {
      // Read the existing Web service description file.
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_CS.wsdl" );
      PortTypeCollection^ myPortTypeCollection = myServiceDescription->PortTypes;
      int noOfPortTypes = myServiceDescription->PortTypes->Count;
      Console::WriteLine( "\nTotal number of PortTypes: {0}", myServiceDescription->PortTypes->Count );

      // Get the first PortType in the collection.
      PortType^ myNewPortType = myPortTypeCollection[ "MathServiceSoap" ];
      int index = myPortTypeCollection->IndexOf( myNewPortType );
      Console::WriteLine( "The PortType with the name {0} is at index: {1}", myNewPortType->Name, (index + 1) );
      Console::WriteLine( "Removing the PortType: {0}", myNewPortType->Name );

      // Remove the PortType from the collection.
      myPortTypeCollection->Remove( myNewPortType );
      bool bContains = myPortTypeCollection->Contains( myNewPortType );
      Console::WriteLine( "The PortType with the name {0} exists: {1}", myNewPortType->Name, bContains );
      Console::WriteLine( "Total number of PortTypes after removing: {0}", myServiceDescription->PortTypes->Count );
      Console::WriteLine( "Adding a PortType: {0}", myNewPortType->Name );

      // Add a new portType from the collection.
      myPortTypeCollection->Add( myNewPortType );

      // Display the number of portTypes after adding a port.
      Console::WriteLine( "Total number of PortTypes after adding a new port: {0}", myServiceDescription->PortTypes->Count );

      // List the PortTypes available in the WSDL document.
      IEnumerator^ myEnum = myPortTypeCollection->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         PortType^ myPortType = safe_cast<PortType^>(myEnum->Current);
         Console::WriteLine( "The PortType name is: {0}", myPortType->Name );
      }
      myServiceDescription->Write( "MathService_New.wsdl" );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
// </Snippet1>
