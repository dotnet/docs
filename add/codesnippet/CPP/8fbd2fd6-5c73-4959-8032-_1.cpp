   // Create a SoapNormalizedString object.
   String^ testString = L"one two";
   SoapNormalizedString^ normalized = gcnew SoapNormalizedString(
      testString );
   Console::WriteLine( L"The value of the SoapNormalizedString object is {0}.",
      normalized );