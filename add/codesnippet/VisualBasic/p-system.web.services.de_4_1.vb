      Dim myFaultBindingCollection As FaultBindingCollection = myOperationBinding.Faults
      Dim myFaultBinding As New FaultBinding()
      myFaultBinding.Name = "ErrorString"
      ' Associate SOAP fault binding to the fault binding of the operation.
      myExtensions = myFaultBinding.Extensions
      Dim mySoapFaultBinding As New SoapFaultBinding()
      mySoapFaultBinding.Use = SoapBindingUse.Literal
      mySoapFaultBinding.Namespace = "http://www.contoso.com/stockquote"
      myExtensions.Add(mySoapFaultBinding)
      myFaultBindingCollection.Add(myFaultBinding)