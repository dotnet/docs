   // Create a SoapAnyUri object.
   String^ anyUriValue = L"http://localhost:8080/WebService";
   SoapAnyUri^ anyUri = gcnew SoapAnyUri( anyUriValue );
   Console::WriteLine( L"The value of the SoapAnyUri object is {0}.", anyUri );