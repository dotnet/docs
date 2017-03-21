      Console::WriteLine( "\nMake a copy of the current evidence." );
      Evidence^ evidenceCopy = gcnew Evidence( myEvidence );
      Console::WriteLine( "Count of new evidence items = {0}", evidenceCopy->Count );
      Console::WriteLine( "Does the copy equal the current evidence? {0}", myEvidence->Equals( evidenceCopy ) );