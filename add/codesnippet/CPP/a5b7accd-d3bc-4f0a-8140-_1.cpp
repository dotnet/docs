   // Create a SoapHexBinary object.
   array<Byte>^ bytes = gcnew array<Byte>(5){
      2,3,5,7,11
   };
   SoapHexBinary^ hexBinary = gcnew SoapHexBinary( bytes );
   Console::WriteLine( L"The SoapHexBinary object is {0}.", hexBinary );