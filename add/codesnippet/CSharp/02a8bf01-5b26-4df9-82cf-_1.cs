      // Build a new Service.
      Service myService = new Service();
      myService.Name = "MathService";
      XmlQualifiedName myXmlQualifiedName = 
         new XmlQualifiedName("s0:MathServiceSoap");
      
      // Build a new Port for SOAP.
      Port mySoapPort= new Port();
      
      mySoapPort.Name = "MathServiceSoap";
                  
      mySoapPort.Binding = myXmlQualifiedName;
      
      SoapAddressBinding mySoapAddressBinding = new SoapAddressBinding();
      mySoapAddressBinding.Location = 
         "http://localhost/ServiceCollection_Item/AddSub_CS.asmx";
      mySoapPort.Extensions.Add(mySoapAddressBinding);
      
      // Build a new Port for HTTP-GET.
      XmlQualifiedName myXmlQualifiedName2 = 
         new XmlQualifiedName("s0:MathServiceHttpGet");
                        
      Port myHttpGetPort= new Port();
      myHttpGetPort.Name="MathServiceHttpGet";
      myHttpGetPort.Binding=myXmlQualifiedName2;
      HttpAddressBinding myHttpAddressBinding = new HttpAddressBinding();
      myHttpAddressBinding.Location = 
         "http://localhost/ServiceCollection_Item/AddSub_CS.asmx";
      myHttpGetPort.Extensions.Add(myHttpAddressBinding);
      
      // Add the ports to the service.
      myService.Ports.Add(myHttpGetPort);
      myService.Ports.Add(mySoapPort);
      
      // Add the service to the ServiceCollection.
      myServiceCollection .Add(myService);