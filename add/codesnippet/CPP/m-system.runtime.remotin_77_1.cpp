   // Create a SoapInteger object.
   SoapInteger^ xsdInteger = gcnew SoapInteger;
   xsdInteger->Value = -14;
   Console::WriteLine( L"The value of the SoapInteger object is {0}.",
      xsdInteger );