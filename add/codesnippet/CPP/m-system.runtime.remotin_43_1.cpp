   // Create a SoapAnyUri object.
   SoapAnyUri^ anyUri = gcnew SoapAnyUri;
   anyUri->Value = L"http://localhost:8080/WebService";
   Console::WriteLine( L"The value of the SoapAnyUri object is {0}.", anyUri );