      FileStream^ myFileStream = gcnew FileStream( "output.wsdl",FileMode::OpenOrCreate,FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );

      // Write the WSDL.
      Console::WriteLine( "Writing a new WSDL file." );
      myServiceDescription->Write( myStreamWriter );
      myStreamWriter->Close();
      myFileStream->Close();