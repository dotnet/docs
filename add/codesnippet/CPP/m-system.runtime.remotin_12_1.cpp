   // Create a SoapNegativeInteger object.
   SoapNegativeInteger^ xsdInteger = gcnew SoapNegativeInteger;
   xsdInteger->Value = -14;
   Console::WriteLine( L"The value of the SoapNegativeInteger object is {0}.",
      xsdInteger );