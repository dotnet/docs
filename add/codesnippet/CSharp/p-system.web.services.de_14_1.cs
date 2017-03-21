      // Read the 'Operation_Faults_Input_CS.wsdl' file as input.
      ServiceDescription myServiceDescription =
         ServiceDescription.Read("Operation_Faults_Input_CS.wsdl");

      // Get the operation fault collection.
      PortTypeCollection myPortTypeCollection = myServiceDescription.PortTypes;
      PortType myPortType = myPortTypeCollection[0];
      OperationCollection myOperationCollection = myPortType.Operations;

      // Remove the operation fault with the name 'ErrorString'.
      Operation myOperation = myOperationCollection[0];
      OperationFaultCollection myOperationFaultCollection = myOperation.Faults;
      if(myOperationFaultCollection.Contains(myOperationFaultCollection["ErrorString"]))
         myOperationFaultCollection.Remove(myOperationFaultCollection["ErrorString"]);