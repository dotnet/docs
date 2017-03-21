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