      // Create SOAP Extensibility element.
      SoapBinding^ mySoapBinding = gcnew SoapBinding;
      // SOAP over HTTP.
      mySoapBinding->Transport = "http://schemas.xmlsoap.org/soap/http";
      mySoapBinding->Style = SoapBindingStyle::Document;
      // Add tag soap:binding as an extensibility element.
      myBinding->Extensions->Add( mySoapBinding );