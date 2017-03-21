   // Print the value of the SoapHexBinary object.
   Console::Write( L"hexBinary.Value contains:" );
   for ( int i = 0; i < hexBinary->Value->Length; ++i )
   {
      Console::Write( L" {0}", hexBinary->Value[ i ] );

   }
   Console::WriteLine();