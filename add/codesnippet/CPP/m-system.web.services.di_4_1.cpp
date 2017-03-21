      // Check whether the given XmlTextReader is readable.
      if ( DiscoveryDocument::CanRead( myXmlTextReader ) == true )
            
      // Read the given XmlTextReader.
      myDiscoveryDocument = DiscoveryDocument::Read( myXmlTextReader );
      else
            Console::WriteLine( "The supplied file is not readable" );
      