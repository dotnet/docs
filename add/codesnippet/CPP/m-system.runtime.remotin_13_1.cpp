   // Create a SoapHexBinary object.
   SoapHexBinary^ hexBinary = gcnew SoapHexBinary;
   hexBinary->Value = gcnew array<Byte>(5){
      2,3,5,7,11
   };
   Console::WriteLine( L"The SoapHexBinary object is {0}.", hexBinary );