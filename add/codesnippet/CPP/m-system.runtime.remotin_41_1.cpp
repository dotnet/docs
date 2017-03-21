   // Create a SoapBase64Binary object.
   SoapBase64Binary^ base64Binary = gcnew SoapBase64Binary;
   base64Binary->Value = gcnew array<Byte>(7){
      2,3,5,7,11,0,5
   };
   Console::WriteLine( L"The SoapBase64Binary object is {0}.",
      base64Binary );