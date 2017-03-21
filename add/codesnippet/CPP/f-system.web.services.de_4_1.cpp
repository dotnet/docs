   SoapBinding^ mySoapBinding = gcnew SoapBinding;
   mySoapBinding->Transport = SoapBinding::HttpTransport;
   mySoapBinding->Style = SoapBindingStyle::Document;