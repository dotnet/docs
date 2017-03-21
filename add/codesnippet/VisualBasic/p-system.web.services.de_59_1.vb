      Dim myServiceDescription As New ServiceDescription()
      myServiceDescription = _
         ServiceDescription.Read("ServiceDescription_Extensions_Input_vb.wsdl")
      Console.WriteLine( _
         myServiceDescription.Bindings(1).Extensions(0).ToString())
      Dim mySoapBinding As New SoapBinding()
      mySoapBinding.Required = True
      Dim mySoapBinding1 As New SoapBinding()
      mySoapBinding1.Required = False
      myServiceDescription.Extensions.Add(mySoapBinding)
      myServiceDescription.Extensions.Add(mySoapBinding1)
      Dim myServiceDescriptionFormatExtension As _
         ServiceDescriptionFormatExtension
      For Each myServiceDescriptionFormatExtension _
         In myServiceDescription.Extensions
         Console.WriteLine("Required: " & _
            myServiceDescriptionFormatExtension.Required.ToString())
      Next myServiceDescriptionFormatExtension
      myServiceDescription.Write("ServiceDescription_Extensions_Output_vb.wsdl")
      myServiceDescription.RetrievalUrl = "http://www.contoso.com/"
      Console.WriteLine("Retrieval URL is: " & _
         myServiceDescription.RetrievalUrl)