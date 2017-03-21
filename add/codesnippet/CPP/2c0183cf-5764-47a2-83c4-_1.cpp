      for ( int i = 0; i < myDiscoveryClientResultCollection->Count; i++ )
      {
         DiscoveryClientResult^ myClientResult = myDiscoveryClientResultCollection[ i ];
         Console::WriteLine( "DiscoveryClientResult {0}", (i + 1) );
         Console::WriteLine( "Type of reference in the discovery document: {0}", myClientResult->ReferenceTypeName );
         Console::WriteLine( "Url for reference:{0}", myClientResult->Url );
         Console::WriteLine( "File for saving the reference: {0}", myClientResult->Filename );
      }