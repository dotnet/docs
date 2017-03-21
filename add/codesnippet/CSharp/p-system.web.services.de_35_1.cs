         SoapBinding mySoapBinding = new SoapBinding();
         mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http";
         mySoapBinding.Style = SoapBindingStyle.Document;
         // Add the 'SoapBinding' object to the 'Binding' object.
         myBinding.Extensions.Add(mySoapBinding);