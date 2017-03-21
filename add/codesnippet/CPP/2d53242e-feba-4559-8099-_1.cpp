   // Create a SoapNonNegativeInteger object.
   Decimal decimalValue = +14;
   SoapNonNegativeInteger^ xsdInteger = gcnew SoapNonNegativeInteger( decimalValue );
   Console::WriteLine( L"The value of the SoapNonNegativeInteger object is {0}.", xsdInteger );