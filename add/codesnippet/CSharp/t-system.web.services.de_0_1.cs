         // Obtain the ServiceDescription of existing Wsdl.
         ServiceDescription myDescription = ServiceDescription.Read("MyWsdl_CS.wsdl");
         // Remove the Binding from the Binding Collection of ServiceDescription.
         BindingCollection myBindingCollection = myDescription.Bindings;
         myBindingCollection.Remove(myBindingCollection[0]);
         
         // Form a new Binding.
         Binding myBinding = new Binding();
         myBinding.Name = "Service1Soap";
         XmlQualifiedName myXmlQualifiedName = 
                              new XmlQualifiedName("s0:Service1Soap");
         myBinding.Type = myXmlQualifiedName;

         SoapBinding mySoapBinding = new SoapBinding();
         mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http";
         mySoapBinding.Style = SoapBindingStyle.Document;

         OperationBinding addOperationBinding = 
                CreateOperationBinding("Add",myDescription.TargetNamespace);
         myBinding.Operations.Add(addOperationBinding);
         myBinding.Extensions.Add(mySoapBinding);

         // Add the Binding to the ServiceDescription.
         myDescription.Bindings.Add(myBinding);
         myDescription.Write("MyOutWsdl.wsdl");