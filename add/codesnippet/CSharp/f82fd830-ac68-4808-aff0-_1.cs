         OperationCollection myOperationCollection = 
                                       myPortTypeCollection[0].Operations;
         Operation myOperation = new Operation();
         myOperation.Name = "Add";
         OperationMessage myOperationMessageInput = 
                                  (OperationMessage) new OperationInput();
         myOperationMessageInput.Message = new XmlQualifiedName
                              ("AddSoapIn",myDescription.TargetNamespace);
         OperationMessage myOperationMessageOutput = 
                                 (OperationMessage) new OperationOutput();
         myOperationMessageOutput.Message = new XmlQualifiedName(
                              "AddSoapOut",myDescription.TargetNamespace);
         myOperation.Messages.Add(myOperationMessageInput);
         myOperation.Messages.Add(myOperationMessageOutput);
         myOperationCollection.Add(myOperation);