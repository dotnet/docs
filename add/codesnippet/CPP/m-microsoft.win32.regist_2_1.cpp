   // Print the information from the Test9999 subkey.
   Console::WriteLine( "There are {0} subkeys under Test9999.", test9999->SubKeyCount.ToString() );
   array<String^>^subKeyNames = test9999->GetSubKeyNames();
   for ( int i = 0; i < subKeyNames->Length; i++ )
   {
      RegistryKey ^ tempKey = test9999->OpenSubKey( subKeyNames[ i ] );
      Console::WriteLine( "\nThere are {0} values for {1}.", tempKey->ValueCount.ToString(), tempKey->Name );
      array<String^>^valueNames = tempKey->GetValueNames();
      for ( int j = 0; j < valueNames->Length; j++ )
      {
         Console::WriteLine( "{0,-8}: {1}", valueNames[ j ], tempKey->GetValue( valueNames[ j ] )->ToString() );

      }
   }