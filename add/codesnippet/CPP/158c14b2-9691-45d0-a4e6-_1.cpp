      FileStream^ myFileStream = gcnew FileStream( "Temp::vsdisco",FileMode::OpenOrCreate,FileAccess::Write );
      myDiscoveryDocumentReference->WriteDocument( myDiscoveryDocument, myFileStream );
      myFileStream->Close();
      