      // Enumerate the 'References' in the DiscoveryDocument.
      IEnumerator^ myEnumerator = myDiscoveryDocument->References->GetEnumerator();
      Console::WriteLine( "The 'References' in the discovery document are-" );
      while ( myEnumerator->MoveNext() )
            Console::Write( (dynamic_cast<DiscoveryDocumentReference^>(myEnumerator->Current)->Url) );
      