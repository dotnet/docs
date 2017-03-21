      // Display results of PermissionSet::GetEnumerator.
      IEnumerator^ psEnumerator = ps1->GetEnumerator();
      while ( psEnumerator->MoveNext() )
      {
         Console::WriteLine( psEnumerator->Current );
      }