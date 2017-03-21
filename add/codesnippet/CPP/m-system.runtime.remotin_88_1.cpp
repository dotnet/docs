   // Create a SoapNonNegativeInteger object.
   SoapNonNegativeInteger^ xsdInteger = gcnew SoapNonNegativeInteger;
   xsdInteger->Value = +14;
   Console::WriteLine( L"The value of the SoapNonNegativeInteger object is {0}.", xsdInteger );