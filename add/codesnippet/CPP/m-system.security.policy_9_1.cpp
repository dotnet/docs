      Console::WriteLine( "\nMerge new evidence with the current evidence." );
      array<Object^>^oa1 = {};
      Site^ site = gcnew Site( "www.wideworldimporters.com" );
      array<Object^>^oa2 = {url,site};
      Evidence^ newEvidence = gcnew Evidence( oa1,oa2 );
      myEvidence->Merge( newEvidence );
      Console::WriteLine( "Evidence count = {0}", PrintEvidence( myEvidence ) );