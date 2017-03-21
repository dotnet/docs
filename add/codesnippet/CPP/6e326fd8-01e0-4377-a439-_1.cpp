      ContractReference^ myContractReference = gcnew ContractReference;
      FileStream^ myFileStream = gcnew FileStream( "TestOutput_cpp.wsdl",
         FileMode::OpenOrCreate,FileAccess::Write );
      
      // Get the ServiceDescription for the test .wsdl file.
      ServiceDescription^ myServiceDescription =
         ServiceDescription::Read( "TestInput_cpp.wsdl" );
      
      // Write the ServiceDescription into the file stream.
      myContractReference->WriteDocument( myServiceDescription, myFileStream );
      Console::WriteLine( "ServiceDescription is written "
         + "into the file stream successfully." );
      Console::WriteLine( "The number of bytes written into the file stream: {0}",
         myFileStream->Length );
      myFileStream->Close();