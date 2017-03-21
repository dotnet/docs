   // Create a SoapNegativeInteger object.
   Decimal decimalValue = -14;
   SoapNegativeInteger^ xsdInteger = gcnew SoapNegativeInteger( 
      decimalValue );
   Console::WriteLine( L"The value of the SoapNegativeInteger object is {0}.",
      xsdInteger );