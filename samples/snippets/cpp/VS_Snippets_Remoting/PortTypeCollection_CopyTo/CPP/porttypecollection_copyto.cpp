// System.Web.Services.Description.PortTypeCollection.CopyTo()

/*
The following sample demonstrates the 'CopyTo()' method of the class
'PortTypeCollection'.This sample reads the contents of a file 'MathService.wsdl'
into a 'ServiceDescription' instance. It gets the collection of 'PortType'
from 'ServiceDescription'. It copies the collection into an array of 'PortType' 
and displays their names.
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
      PortTypeCollection^ myPortTypeCollection;

      ServiceDescription^ myServiceDescription =
         ServiceDescription::Read( "MathService_CS.wsdl" );

      myPortTypeCollection = myServiceDescription->PortTypes;
      int noOfPortTypes = myServiceDescription->PortTypes->Count;
      Console::WriteLine( "\nTotal number of PortTypes: {0}",
         myServiceDescription->PortTypes->Count );
      
      // Copy the collection into an array.
      array<PortType^>^ myPortTypeArray = gcnew array<PortType^>(noOfPortTypes);
      myPortTypeCollection->CopyTo( myPortTypeArray, 0 );
      
      // Display names of all PortTypes.
      for ( int i = 0; i < noOfPortTypes; i++ )
      {
         Console::WriteLine( "PortType name: {0}", myPortTypeArray[ i ]->Name );
      }
      myServiceDescription->Write( "MathService_New.wsdl" );
// </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
