      ' Read a ServiceDescription from existing WSDL.
      Dim myServiceDescription As ServiceDescription = _
         ServiceDescription.Read("Input.vb.wsdl")
      myServiceDescription.TargetNamespace = "http://tempuri.org/"

      ' Get the ServiceCollection of the ServiceDescription.
      Dim myServiceCollection As ServiceCollection = _
         myServiceDescription.Services

      ' Remove the Service at index 0 of the collection.
      myServiceCollection.Remove(myServiceDescription.Services.Item(0))

      ' Build a new Service.
      Dim myService As New Service()
      myService.Name = "MathService"
      Dim myXmlQualifiedName As New XmlQualifiedName("s0:MathServiceSoap")

      ' Build a new Port for SOAP.
      Dim mySoapPort As New Port()

      mySoapPort.Name = "MathServiceSoap"

      mySoapPort.Binding = myXmlQualifiedName

      Dim mySoapAddressBinding As New SoapAddressBinding()
      mySoapAddressBinding.Location = _
         "http://localhost/ServiceCollection_Item/AddSub.vb.asmx"
      mySoapPort.Extensions.Add(mySoapAddressBinding)

      ' Build a new Port for HTTP-GET.
      Dim myXmlQualifiedName2 As _
         New XmlQualifiedName("s0:MathServiceHttpGet")

      Dim myHttpGetPort As New Port()
      myHttpGetPort.Name = "MathServiceHttpGet"
      myHttpGetPort.Binding = myXmlQualifiedName2
      Dim myHttpAddressBinding As New HttpAddressBinding()
      myHttpAddressBinding.Location = _
         "http://localhost/ServiceCollection_Item/AddSub.vb.asmx"
      myHttpGetPort.Extensions.Add(myHttpAddressBinding)

      ' Add the ports to the service.
      myService.Ports.Add(myHttpGetPort)
      myService.Ports.Add(mySoapPort)

      ' Add the service to the ServiceCollection.
      myServiceCollection.Add(myService)

      ' Write to a new WSDL file.
      myServiceDescription.Write("output.wsdl")