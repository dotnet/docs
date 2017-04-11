

// System::Web::Services::Description.ServiceDescriptionCollection::GetBinding()
/* The following program demonstrates the 'GetBinding' method
of 'ServiceDescriptionCollection' class. It searches for a
'Binding' in the collection and returns the Binding instance.
On success, a message is displayed on the console.

Note: This program requires 'DataTypes_cpp.wsdl' and 'MathService_cpp.wsdl'
files to be placed in same directory as that of .exe for running.
*/

#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Web::Services::Description;

int main()
{
   try
   {
      ServiceDescription^ myServiceDescription1 =
         ServiceDescription::Read( "DataTypes_cpp.wsdl" );
      ServiceDescription^ myServiceDescription2 =
         ServiceDescription::Read( "MathService_cpp.wsdl" );
      
      // Create the Object* of 'ServiceDescriptionCollection' class.
      ServiceDescriptionCollection^ myCollection =
         gcnew ServiceDescriptionCollection;
      
      // Add ServiceDescription objects.
      myCollection->Add( myServiceDescription1 );
      myCollection->Add( myServiceDescription2 );
      
// <Snippet1>
      // Construct an XML qualified name.
      XmlQualifiedName^ myXmlQualifiedName =
         gcnew XmlQualifiedName( "MathServiceSoap","http://tempuri2.org/" );
      
      // Get the Binding from the collection.
      myCollection->GetBinding( myXmlQualifiedName );
// </Snippet1>
      Console::WriteLine( "Specified Binding is a member of ServiceDescription "
        + "instances within the collection" );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The following exception was raised: {0}", e->Message );
   }
}
