   // Create a SoapPositiveInteger object.
   SoapPositiveInteger^ xsdInteger = gcnew SoapPositiveInteger;
   xsdInteger->Value = 14;
   Console::WriteLine( L"The value of the SoapPositiveInteger object is {0}.",
      xsdInteger );