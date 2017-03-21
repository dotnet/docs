      Dim mySoapHeaderBinding As New SoapHeaderBinding()
      ' Set the Message within the XML Web service to which the 
      ' 'SoapHeaderBinding' applies.
      mySoapHeaderBinding.Message = New XmlQualifiedName("s0:HelloMyHeader")
      mySoapHeaderBinding.Part = "MyHeader"
      mySoapHeaderBinding.Use = SoapBindingUse.Literal
      ' Add mySoapHeaderBinding to the 'myInputBinding' object.
      myInputBinding.Extensions.Add(mySoapHeaderBinding)