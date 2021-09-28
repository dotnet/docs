

// System::Web::Services::Description.ServiceDescriptionCollection::ServiceDescriptionCollection()
// System::Web::Services::Description.ServiceDescriptionCollection->Add()
// System::Web::Services::Description.ServiceDescriptionCollection::Item(Int32)
/* The following program demonstrates 'Constructor', 'Add' method and
'Item' property of 'ServiceDescriptionCollection' class. It creates an
instance of 'ServiceDescriptionCollection' and adds
'ServiceDescription' objects to the collection. The Item property is used to
display the TargetNamespace of elements in the collection.

Note: This program requires 'DataTypes_CS::wsdl' and 'MathService_CS::wsdl'
files to be placed in same directory as that of .exe for running.
*/
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Web::Services::Description;

int main()
{
   try
   {
      ServiceDescription^ myServiceDescription1 = ServiceDescription::Read( "DataTypes_cpp.wsdl" );
      ServiceDescription^ myServiceDescription2 = ServiceDescription::Read( "MathService_cpp.wsdl" );

      // <Snippet1>
      // <Snippet2>
      // Create a ServiceDescriptionCollection.
      ServiceDescriptionCollection^ myCollection = gcnew ServiceDescriptionCollection;

      // Add ServiceDescriptions to the collection.
      myCollection->Add( myServiceDescription1 );
      myCollection->Add( myServiceDescription2 );
      // </Snippet1>
      // </Snippet2>

      // <Snippet3>
      // Display element properties in the collection using 
      // the Item property.
      for ( int i = 0; i < myCollection->Count; i++ )
         Console::WriteLine( myCollection[ i ]->TargetNamespace );
      // </Snippet3>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The following exception was raised: {0}", e->Message );
   }
}
