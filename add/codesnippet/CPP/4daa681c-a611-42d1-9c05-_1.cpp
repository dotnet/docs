   // Create a SoapPositiveInteger object.
   Decimal decimalValue = 14;
   SoapPositiveInteger^ xsdInteger = gcnew SoapPositiveInteger( decimalValue );
   Console::WriteLine( L"The value of the SoapPositiveInteger object is {0}.",
      xsdInteger );