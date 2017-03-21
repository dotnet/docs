      FaultBindingCollection myFaultBindingCollection = myOperationBinding.Faults;
      FaultBinding myFaultBinding = new FaultBinding();
      myFaultBinding.Name = "ErrorString";
      // Associate SOAP fault binding to the fault binding of the operation.
      myExtensions = myFaultBinding.Extensions;
      SoapFaultBinding mySoapFaultBinding = new SoapFaultBinding();
      mySoapFaultBinding.Use = SoapBindingUse.Literal;
      mySoapFaultBinding.Namespace = "http://www.contoso.com/stockquote";
      myExtensions.Add(mySoapFaultBinding);
      myFaultBindingCollection.Add(myFaultBinding);