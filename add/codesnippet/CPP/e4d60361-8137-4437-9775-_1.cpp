   CspParameters^ parameters = gcnew CspParameters;
   parameters->KeyContainerName = L"TestContainer";
   array<Object^>^argsArray = gcnew array<Object^>(1){
      parameters
   };
   
   // Instantiate the RSA provider instance accessing the TestContainer
   // key container.
   RSACryptoServiceProvider^ rsaProvider =
      static_cast<RSACryptoServiceProvider^>(
         CryptoConfig::CreateFromName( L"RSA", argsArray ));