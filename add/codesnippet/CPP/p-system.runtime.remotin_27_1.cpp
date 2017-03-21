   // Print the value of the SoapBase64Binary object.
   Console::Write( L"base64Binary.Value contains:" );
   for ( int i = 0; i < base64Binary->Value->Length; ++i )
   {
      Console::Write( L" {0}", base64Binary->Value[ i ] );

   }
   Console::WriteLine();