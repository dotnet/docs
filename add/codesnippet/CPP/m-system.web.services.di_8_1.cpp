      // Create an object of the 'DiscoveryDocument'.
      DiscoveryDocument^ myDiscoveryDocument = gcnew DiscoveryDocument;
      
      // Create an XmlTextReader with the sample file.
      XmlTextReader^ myXmlTextReader = gcnew XmlTextReader(
         "http://localhost/example_Write1_cs.disco" );
      
      // Read the given XmlTextReader.
      myDiscoveryDocument = DiscoveryDocument::Read( myXmlTextReader );
      
      // Write the DiscoveryDocument into the stream.
      FileStream^ myFileStream = gcnew FileStream(
         "log.txt",FileMode::OpenOrCreate,FileAccess::Write );
      myDiscoveryDocument->Write( myFileStream );

      myFileStream->Flush();
      myFileStream->Close();
      
      // Display the contents of the DiscoveryDocument onto the console.
      FileStream^ myFileStream1 = gcnew FileStream(
         "log.txt",FileMode::OpenOrCreate,FileAccess::Read );
      StreamReader^ myStreamReader = gcnew StreamReader( myFileStream1 );
      
      // Set the file pointer to the begin.
      myStreamReader->BaseStream->Seek( 0, SeekOrigin::Begin );
      Console::WriteLine( "The contents of the DiscoveryDocument are-" );
      while ( myStreamReader->Peek() > -1 )
      {
         Console::WriteLine( myStreamReader->ReadLine() );
      }
      myStreamReader->Close();