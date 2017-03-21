   // Create a SoapBase64Binary object.
   array<Byte>^bytes = gcnew array<Byte>(5){
      2,3,5,7,11
   };
   SoapBase64Binary^ base64Binary = gcnew SoapBase64Binary( bytes );
   Console::WriteLine( L"The SoapBase64Binary object is {0}.",
      base64Binary );