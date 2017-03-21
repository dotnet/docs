   // Create a SoapInteger object.
   Decimal decimalValue = -14;
   SoapInteger^ xsdInteger = gcnew SoapInteger( decimalValue );
   Console::WriteLine( L"The value of the SoapInteger object is {0}.",
      xsdInteger );