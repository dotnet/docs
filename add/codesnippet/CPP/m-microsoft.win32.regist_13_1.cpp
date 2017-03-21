   // Delete the ID value.
   testSettings = test9999->OpenSubKey( "TestSettings", true );
   testSettings->DeleteValue( "id" );

   // Verify the deletion.
   Console::WriteLine( dynamic_cast<String^>(testSettings->GetValue(  "id", "ID not found." )) );
   testSettings->Close();