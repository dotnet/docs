      // Create a DiscoveryDocument.
      DiscoveryDocument^ myDiscoveryDocument = gcnew DiscoveryDocument;
      
      // Create an XmlTextReader with the sample file.
      XmlTextReader^ myXmlTextReader = gcnew XmlTextReader(
         "http://localhost/example_Write2_cs.disco" );
      
      // Read the given XmlTextReader.
      myDiscoveryDocument = DiscoveryDocument::Read( myXmlTextReader );

      FileStream^ myFileStream = gcnew FileStream(
         "log.txt",FileMode::OpenOrCreate,FileAccess::Write );
      StreamWriter^ myStreamWriter = gcnew StreamWriter( myFileStream );

      XmlTextWriter^ myXmlTextWriter = gcnew XmlTextWriter( myStreamWriter );
      myDiscoveryDocument->Write( myXmlTextWriter );

      myXmlTextWriter->Flush();
      myXmlTextWriter->Close();
      
      // Display the contents of the DiscoveryDocument on the console.
      FileStream^ myFileStream1 = gcnew FileStream(
         "log.txt",FileMode::OpenOrCreate,FileAccess::Read );
      StreamReader^ myStreamReader = gcnew StreamReader( myFileStream1 );
      
      // Set the file pointer to the beginning.
      myStreamReader->BaseStream->Seek( 0, SeekOrigin::Begin );
      Console::WriteLine( "The contents of the DiscoveryDocument are: " );
      while ( myStreamReader->Peek() > -1 )
      {
         Console::WriteLine( myStreamReader->ReadLine() );
      }
      myStreamReader->Close();