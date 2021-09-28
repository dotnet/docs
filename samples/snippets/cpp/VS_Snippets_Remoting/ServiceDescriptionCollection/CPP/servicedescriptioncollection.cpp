

// System::Web::Services::Description.ServiceDescriptionCollection
/*The following program demonstrates the 'ServiceDescriptionCollection' class.
It creates two 'ServiceDescription' objects and add them to
'ServiceDescriptionCollection' Object*. It displays the name of 'ServiceDescription'
objects using 'Item' property. 'GetBinding' method is used to display binding instance of the
'ServiceDescription' Object*.

Note: This program requires 'DataTypes_CS.wsdl' and 'MathService_cpp.wsdl' files to
be placed in same directory as that of .exe for running.
*/
// <Snippet1>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Web::Services::Description;

int main()
{
   try
   {
      // Get ServiceDescription objects.
      ServiceDescription^ myServiceDescription1 = ServiceDescription::Read( "DataTypes_cpp.wsdl" );
      ServiceDescription^ myServiceDescription2 = ServiceDescription::Read( "MathService_cpp.wsdl" );

      // Set the names of the ServiceDescriptions.
      myServiceDescription1->Name = "DataTypes";
      myServiceDescription2->Name = "MathService";

      // Create a ServiceDescriptionCollection.
      ServiceDescriptionCollection^ myServiceDescriptionCollection = gcnew ServiceDescriptionCollection;

      // Add the ServiceDescriptions to the collection.
      myServiceDescriptionCollection->Add( myServiceDescription1 );
      myServiceDescriptionCollection->Add( myServiceDescription2 );

      // Display the elements of the collection using the Item property.
      Console::WriteLine( "Elements in the collection: " );
      for ( int i = 0; i < myServiceDescriptionCollection->Count; i++ )
         Console::WriteLine( myServiceDescriptionCollection[ i ]->Name );

      // Construct an XML qualified name.
      XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "MathServiceSoap","http://tempuri2.org/" );

      // Get the Binding from the collection.
      Binding^ myBinding = myServiceDescriptionCollection->GetBinding( myXmlQualifiedName );
      Console::WriteLine( "Binding found in collection with name: {0}", myBinding->ServiceDescription->Name );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The following exception was raised: {0}", e->Message );
   }
}
// </Snippet1>
