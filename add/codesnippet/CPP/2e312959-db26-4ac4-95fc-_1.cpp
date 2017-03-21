   // Create a SoapNonPositiveInteger object.
   Decimal decimalValue = -14;
   SoapNonPositiveInteger^ xsdInteger = gcnew SoapNonPositiveInteger(
      decimalValue );
   Console::WriteLine( L"The value of the SoapNonPositiveInteger object is {0}.",
      xsdInteger );