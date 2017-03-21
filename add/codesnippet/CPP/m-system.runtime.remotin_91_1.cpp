   // Create a SoapNonPositiveInteger object.
   SoapNonPositiveInteger^ xsdInteger = gcnew SoapNonPositiveInteger;
   xsdInteger->Value = -14;
   Console::WriteLine( L"The value of the SoapNonPositiveInteger object is {0}.",
      xsdInteger );