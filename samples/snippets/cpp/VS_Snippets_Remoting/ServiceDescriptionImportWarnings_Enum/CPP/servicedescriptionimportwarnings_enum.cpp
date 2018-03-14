// System::Web::Services::Description.ServiceDescriptionImportWarnings::NoCodeGenerated
// System::Web::Services::Description.ServiceDescriptionImportWarnings::NoMethodsGenerated
// System::Web::Services::Description.ServiceDescriptionImportWarnings::UnsupportedOperationsIgnored
// System::Web::Services::Description.ServiceDescriptionImportWarnings::OptionalExtensionsIgnored
// System::Web::Services::Description.ServiceDescriptionImportWarnings::RequiredExtensionsIgnored
// System::Web::Services::Description.ServiceDescriptionImportWarnings::UnsupportedBindingsIgnored

/*
The following program demonstrates the enum values of 'ServiceDescriptionImportWarnings'.
'Import' method of 'ServiceDescriptionImporter' will give the enumaration. The user selected
option will help in taking the related wsdl file and returns the corresponding warning which
is displayed on the console.
*/

using namespace System;

#using <System.Web.Services.dll>
#using <System.dll>
#using <System.Xml.dll>

using namespace System::Web::Services::Description;
using namespace System::CodeDom;

void DisplayWarning( String^ myWSDLFileName )
{
// <Snippet1>
   String^ myDisplay;
   // Read wsdl file.
   ServiceDescription^ myServiceDescription = ServiceDescription::Read
      ( myWSDLFileName );

   ServiceDescriptionImporter^ myServiceDescriptionImporter =
      gcnew ServiceDescriptionImporter;
   
   // Add 'myServiceDescription' to 'myServiceDescriptionImporter'.
   myServiceDescriptionImporter->AddServiceDescription
      ( myServiceDescription, "", "" );

   myServiceDescriptionImporter->ProtocolName = "HttpGet";
   CodeNamespace^ myCodeNamespace = gcnew CodeNamespace;
   CodeCompileUnit^ myCodeCompileUnit = gcnew CodeCompileUnit;
   
   // Invoke 'Import' method.
   ServiceDescriptionImportWarnings myWarning =
      myServiceDescriptionImporter->Import(myCodeNamespace,
         myCodeCompileUnit);

   switch ( myWarning )
   {
      case ServiceDescriptionImportWarnings::NoCodeGenerated:
         myDisplay = "NoCodeGenerated";
         break;
      case ServiceDescriptionImportWarnings::NoMethodsGenerated:
         myDisplay = "NoMethodsGenerated";
         break;
      case ServiceDescriptionImportWarnings::UnsupportedOperationsIgnored:
         myDisplay = "UnsupportedOperationsIgnored";
         break;
      case ServiceDescriptionImportWarnings::OptionalExtensionsIgnored:
         myDisplay = "OptionalExtensionsIgnored";
         break;
      case ServiceDescriptionImportWarnings::RequiredExtensionsIgnored:
         myDisplay = "RequiredExtensionsIgnored";
         break;
      case ServiceDescriptionImportWarnings::UnsupportedBindingsIgnored:
         myDisplay = "UnsupportedBindingsIgnored";
         break;
      default:
         myDisplay = "General Warning";
         break;
   }
   Console::WriteLine( "Warning : " + myDisplay );
// </Snippet1>
}

int main()
{
   DisplayWarning( "ServiceDescriptionImportWarnings_NoCodeGenerated.wsdl" );
   DisplayWarning( "ServiceDescriptionImportWarnings_NoMethodsGenerated::wsdl" );
   DisplayWarning( "ServiceDescriptionImportWarnings_UnsupportedOperationsIgnored::wsdl" );
   DisplayWarning( "ServiceDescriptionImportWarnings_OptionalExtensionsIgnored::wsdl" );
}
