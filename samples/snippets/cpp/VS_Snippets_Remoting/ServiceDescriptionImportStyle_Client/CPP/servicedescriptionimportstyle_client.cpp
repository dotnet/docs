

// System::Web::Services::Description.ServiceDescriptionImportStyle
// System::Web::Services::Description.ServiceDescriptionImportStyle::Client
/* The following program demonstrates the 'ServiceDescriptionImportStyle'
enumeration and 'Client' member of 'ServiceDescriptionImportStyle' in
'System::Web::Services::Description' namespace. It creates a
ServiceDescriptionImporter Object* from a .wsdl file and demonstrates
the usage of Client. */
// <Snippet1>
#using <System.Web.Services.dll>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Web::Services::Description;
int main()
{
   try
   {
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "Sample_cpp.wsdl" );
      ServiceDescriptionImporter^ myImporter = gcnew ServiceDescriptionImporter;
      myImporter->ProtocolName = "Soap";
      myImporter->AddServiceDescription( myServiceDescription, "", "" );
      
      // <Snippet2>
      ServiceDescriptionImportStyle myStyle = myImporter->Style;
      Console::WriteLine( "Import style: {0}", myStyle );
      
      // </Snippet2>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Following exception was thrown: {0}", e );
   }

}

// </Snippet1>
