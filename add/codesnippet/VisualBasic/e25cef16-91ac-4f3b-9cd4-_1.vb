         Dim myService As New Service()
         myService.Name = "MathService"
         Dim myXmlQualifiedName As New XmlQualifiedName("s0:MathServiceSoap")

         ' Build a new Port for SOAP.
         Dim mySoapPort As New Port()
         mySoapPort.Name = "MathServiceSoap"
         mySoapPort.Binding = myXmlQualifiedName
         Dim mySoapAddressBinding As New SoapAddressBinding()
         mySoapAddressBinding.Location = _
            "http://localhost/ServiceDescription_Read/AddService_VB.asmx"
         mySoapPort.Extensions.Add(mySoapAddressBinding)

         ' Build a new Port for HTTP-GET.
         Dim myXmlQualifiedName2 As New _
            XmlQualifiedName("s0:MathServiceHttpGet")
         Dim myHttpGetPort As New Port()
         myHttpGetPort.Name = "MathServiceHttpGet"
         myHttpGetPort.Binding = myXmlQualifiedName2
         Dim myHttpAddressBinding As New HttpAddressBinding()
         myHttpAddressBinding.Location = _
            "http://localhost/ServiceDescription_Read/AddService_VB.asmx"
         myHttpGetPort.Extensions.Add(myHttpAddressBinding)

         ' Add the ports to the service.
         myService.Ports.Add(myHttpGetPort)
         myService.Ports.Add(mySoapPort)
         
         ' Add the service to the ServiceCollection.
         myServiceDescription.Services.Insert(1, myService)