

// <snippet0>
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;

int main()
{
   // Get a WSDL file describing a service.
   ServiceDescription^ description = ServiceDescription::Read( "service.wsdl" );

   // <snippet1>
   // Initialize a service description importer.
   ServiceDescriptionImporter^ importer = gcnew ServiceDescriptionImporter;
   importer->ProtocolName = "Soap12"; // Use SOAP 1.2.
   importer->AddServiceDescription( description, nullptr, nullptr );
   // </snippet1>

   // <snippet2>
   // Report on the service descriptions.
   Console::WriteLine( "Importing {0} service descriptions with {1} associated schemas.", importer->ServiceDescriptions->Count, importer->Schemas->Count );
   // </snippet2>

   // <snippet3>
   // Generate a proxy client.
   importer->Style = ServiceDescriptionImportStyle::Client;
   // </snippet3>

   // <snippet4>
   // Generate properties to represent primitive values.
   importer->CodeGenerationOptions = System::Xml::Serialization::CodeGenerationOptions::GenerateProperties;
   // </snippet4>

   // Initialize a Code-DOM tree into which we will import the service.
   CodeNamespace^ nmspace = gcnew CodeNamespace;
   CodeCompileUnit^ unit = gcnew CodeCompileUnit;
   unit->Namespaces->Add( nmspace );
   
   // <snippet5>
   // Import the service into the Code-DOM tree. This creates proxy code
   // that uses the service.
   ServiceDescriptionImportWarnings warning = importer->Import(nmspace,unit);
   if ( warning == (ServiceDescriptionImportWarnings)0 )
   {
      // Generate and print the proxy code in C#.
      CodeDomProvider^ provider = CodeDomProvider::CreateProvider( "CSharp" );
      ICodeGenerator^ generator = provider->CreateGenerator();
      generator->GenerateCodeFromCompileUnit( unit, Console::Out, gcnew CodeGeneratorOptions );
   }
   else
   {
      // Print an error message.
      Console::WriteLine( warning );
   }
   // </snippet5>
}
// </snippet0>
