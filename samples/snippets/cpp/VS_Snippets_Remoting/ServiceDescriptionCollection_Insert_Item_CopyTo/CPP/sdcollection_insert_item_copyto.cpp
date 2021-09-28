

// System::Web::Services::Description.ServiceDescriptionCollection::Insert()
// System::Web::Services::Description.ServiceDescriptionCollection::Item(String)
// System::Web::Services::Description.ServiceDescriptionCollection::CopyTo()
/* The following program demonstrates 'Item' property, 'Insert' and 'CopyTo'
methods of the 'ServiceDescriptionCollection' class. It creates an instance of
'ServiceDescriptionCollection' and adds 'ServiceDescription' objects to the
collection. The elements of the collection are copied to a 'ServiceDescription'
array.

Note: This program requires 'DataTypes_cpp.wsdl' and 'MathService_cpp.wsdl'
files to be placed in the same directory as that of .exe for running.
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
      myServiceDescription1->Name = "DataTypes";
      ServiceDescription^ myServiceDescription2 = ServiceDescription::Read( "MathService_cpp.wsdl" );
      myServiceDescription2->Name = "MathService";

      // Create the object of 'ServiceDescriptionCollection' class.
      ServiceDescriptionCollection^ myCollection = gcnew ServiceDescriptionCollection;

      // Add 'ServiceDescription' objects.
      myCollection->Add( myServiceDescription1 );

      // <Snippet1>
      // Insert a ServiceDescription into the collection.
      myCollection->Insert( 1, myServiceDescription2 );
      // </Snippet1>

      // <Snippet2>
      // Get a ServiceDescription in the collection using 
      // the Item property.
      ServiceDescription^ myServiceDescription = myCollection[ "http://tempuri1.org/" ];
      // </Snippet2>

      Console::WriteLine( "Name of the object retrieved using 'Item' property: {0}", myServiceDescription->Name );
      
      // <Snippet3>
      array<ServiceDescription^>^myArray = gcnew array<ServiceDescription^>(myCollection->Count);

      // Copy the collection to a ServiceDescription array.
      myCollection->CopyTo( myArray, 0 );
      for ( int i = 0; i < myArray->Length; i++ )
         Console::WriteLine( "Name of element in array: {0}", myArray[ i ]->Name );
      // </Snippet3>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The following exception was raised: {0}", e->Message );
   }
}
