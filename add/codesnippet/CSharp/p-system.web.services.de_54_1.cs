      // Create an Operation.
      Operation myOperation = new Operation();
      myOperation.Name = myOperationName;
      OperationMessage myInput = (OperationMessage)new OperationInput();
      myInput.Message =  new XmlQualifiedName(myInputMesg);
      OperationMessage myOutput = (OperationMessage)new OperationOutput();
      myOutput.Message = new XmlQualifiedName(myOutputMesg);

      // Add messages to the OperationMessageCollection.
      myOperation.Messages.Add(myInput);
      myOperation.Messages.Add(myOutput);
      Console.WriteLine("Operation name is: " + myOperation.Name);     