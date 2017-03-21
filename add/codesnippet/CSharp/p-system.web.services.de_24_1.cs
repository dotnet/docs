    // Initialize a service description importer.
    ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
    importer.ProtocolName = "Soap12";  // Use SOAP 1.2.
    importer.AddServiceDescription(description,null,null);