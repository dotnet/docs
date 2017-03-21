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
      
      ServiceDescriptionImportStyle myStyle = myImporter->Style;
      Console::WriteLine( "Import style: {0}", myStyle );
      
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Following exception was thrown: {0}", e );
   }

}
