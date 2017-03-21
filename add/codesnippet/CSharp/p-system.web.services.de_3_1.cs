      static void Main()
      {
         string myWsdlFileName ="MyWsdl_CS.wsdl";
         XmlTextReader myReader = new XmlTextReader(myWsdlFileName);
         if (ServiceDescription.CanRead(myReader))
         {
            ServiceDescription myDescription = 
               ServiceDescription.Read(myWsdlFileName);

            // Remove the PortType at index 0 of the collection.
            PortTypeCollection myPortTypeCollection = 
               myDescription.PortTypes;
            myPortTypeCollection.Remove(myDescription.PortTypes[0]);
            
            // Build a new PortType.
            PortType myPortType = new PortType();
            myPortType.Name = "Service1Soap";
            Operation myOperation = 
               CreateOperation("Add","s0:AddSoapIn","s0:AddSoapOut","");
            myPortType.Operations.Add(myOperation);

            // Add a new PortType to the PortType collection of 
            // the ServiceDescription.
            myDescription.PortTypes.Add(myPortType);

            myDescription.Write("MyOutWsdl.wsdl");
            Console.WriteLine("New WSDL file generated successfully.");
         }
         else
         {
            Console.WriteLine("This file is not a WSDL file.");
         }

      }
      // Creates an Operation for a PortType.
      public static Operation CreateOperation(string operationName, 
         string inputMessage, string outputMessage, string targetNamespace)
      {
         Operation myOperation = new Operation();
         myOperation.Name = operationName;
         OperationMessage input = (OperationMessage) new OperationInput();
         input.Message = new XmlQualifiedName(inputMessage,targetNamespace);
         OperationMessage output = (OperationMessage) new OperationOutput();
         output.Message = new XmlQualifiedName(outputMessage,targetNamespace);
         myOperation.Messages.Add(input);
         myOperation.Messages.Add(output);
         return myOperation;
      }