      Console::WriteLine( "\nCopy the evidence to an array using CopyTo, then display the array." );
      array<Object^>^evidenceArray = gcnew array<Object^>(myEvidence->Count);
      myEvidence->CopyTo( evidenceArray, 0 );
      for each (Object^ obj in evidenceArray)
      {
         Console::WriteLine(obj->ToString());
      }