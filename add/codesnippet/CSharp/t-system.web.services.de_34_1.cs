   public static void MyMethod(
      ServiceDescriptionBaseCollection myServiceCollection)
   {
      Type myType = myServiceCollection.GetType();
      if (myType.Equals(
         typeof(System.Web.Services.Description.ServiceCollection)))
      {
         // Remove the services at index 0 of the collection.
         ((ServiceCollection)myServiceCollection).Remove(
            myServiceDescription.Services[0]);

         // Build a new Service.
         Service myService =new Service();
         myService.Name="MathService";
         XmlQualifiedName myXmlQualifiedName = 
            new XmlQualifiedName("s0:MathServiceSoap");

         // Build a new Port for SOAP.
         Port mySoapPort= new Port();
         mySoapPort.Name="MathServiceSoap";
         mySoapPort.Binding=myXmlQualifiedName;
         SoapAddressBinding mySoapAddressBinding = new SoapAddressBinding();
         mySoapAddressBinding.Location = "http://localhost/" +
            "ServiceDescriptionBaseCollection/AddSubtractService.CS.asmx";
         mySoapPort.Extensions.Add(mySoapAddressBinding);

         // Build a new Port for HTTP-GET.
         XmlQualifiedName myXmlQualifiedName2 = 
            new XmlQualifiedName("s0:MathServiceHttpGet");
         Port myHttpGetPort= new Port();
         myHttpGetPort.Name="MathServiceHttpGet";
         myHttpGetPort.Binding=myXmlQualifiedName2;
         HttpAddressBinding myHttpAddressBinding = new HttpAddressBinding();
         myHttpAddressBinding.Location = "http://localhost/" + 
            "ServiceDescriptionBaseCollection/AddSubtractService.CS.asmx";
         myHttpGetPort.Extensions.Add(myHttpAddressBinding);

         // Add the ports to the Service.
         myService.Ports.Add(myHttpGetPort);
         myService.Ports.Add(mySoapPort);

         // Add the Service to the ServiceCollection.
         myServiceDescription.Services.Add(myService);
      }
      else if(myType.Equals(
         typeof(System.Web.Services.Description.BindingCollection)))
      {
         // Remove the Binding in the BindingCollection at index 0.
         ((BindingCollection)myServiceCollection).Remove(
            myServiceDescription.Bindings[0]);

         // Build a new Binding.
         Binding myBinding = new Binding();
         myBinding.Name = "MathServiceSoap";
         XmlQualifiedName myXmlQualifiedName = 
            new XmlQualifiedName("s0:MathServiceSoap");
         myBinding.Type=myXmlQualifiedName;
         SoapBinding mySoapBinding = new SoapBinding();
         mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http";
         mySoapBinding.Style = SoapBindingStyle.Document;

         // Create the operations for the binding.
         OperationBinding addOperationBinding = CreateOperationBinding(
            "Add", myServiceDescription.TargetNamespace);
         OperationBinding subtractOperationBinding = CreateOperationBinding(
            "Subtract",myServiceDescription.TargetNamespace);

         // Add the operations to the Binding.
         myBinding.Operations.Add(subtractOperationBinding);
         myBinding.Operations.Add(addOperationBinding);
         myBinding.Extensions.Add(mySoapBinding);

         // Add the Binding to the Bindings collection.
         myServiceDescription.Bindings.Add(myBinding);
      }
      else if (myType.Equals(
         typeof(System.Web.Services.Description.PortTypeCollection)))
      {
         // Remove the PortType at index 0.
         ((PortTypeCollection)myServiceCollection).Remove(
            myServiceDescription.PortTypes[0]);

         // Build a new PortType.
          PortType myPortType = new PortType();
          myPortType.Name = "MathServiceSoap";

         // Build an Add Operation for the PortType.
          Operation myAddOperation = new Operation();
          myAddOperation.Name="Add";

          // Build the Input and Output messages for the Operations.
          OperationInput myOperationInputMessage1 = new OperationInput();
          XmlQualifiedName myXmlQualifiedName1 = 
             new XmlQualifiedName("s0:AddSoapIn");
          myOperationInputMessage1.Message = myXmlQualifiedName1;

          OperationOutput myOperationOutputMessage1 = new OperationOutput();
          XmlQualifiedName myXmlQualifiedName2 = 
             new XmlQualifiedName("s0:AddSoapOut");
          myOperationOutputMessage1.Message=myXmlQualifiedName2;

          // Add the messages to the operations.
          myAddOperation.Messages.Add(myOperationInputMessage1);
          myAddOperation.Messages.Add(myOperationOutputMessage1);

          // Build an Add Operation for the PortType.
          Operation mySubtractOperation = new Operation();
          mySubtractOperation.Name = "Subtract";

          // Build the Input and Output messages for the operations.
          OperationInput myOperationInputMessage2 = new OperationInput();
          XmlQualifiedName myXmlQualifiedName3 = 
             new XmlQualifiedName("s0:SubtractSoapIn");
          myOperationInputMessage2.Message = myXmlQualifiedName3;
          OperationOutput myOperationOutputMessage2 = new OperationOutput();
          XmlQualifiedName myXmlQualifiedName4 = 
             new XmlQualifiedName("s0:SubtractSoapOut");
          myOperationOutputMessage2.Message = myXmlQualifiedName4;

          // Add the messages to the operations.
          mySubtractOperation.Messages.Add(myOperationInputMessage2);
          mySubtractOperation.Messages.Add(myOperationOutputMessage2);

          // Add the operations to the PortType.
          myPortType.Operations.Add(myAddOperation);
          myPortType.Operations.Add(mySubtractOperation);

          // Add the PortType to the collection.
          myServiceDescription.PortTypes.Add(myPortType);
      }
    }