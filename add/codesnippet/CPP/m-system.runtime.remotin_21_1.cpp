   // Create a SoapNormalizedString object.
   SoapNormalizedString^ normalized = gcnew SoapNormalizedString;
   normalized->Value = L"one two";
   Console::WriteLine( L"The value of the SoapNormalizedString object is {0}.",
      normalized );