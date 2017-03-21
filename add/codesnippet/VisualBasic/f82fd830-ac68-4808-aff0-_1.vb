         Dim myOperationCollection As OperationCollection = _
                                         myPortTypeCollection(0).Operations
         Dim myOperation As New Operation()
         myOperation.Name = "Add"
         Dim myOperationMessageInput As OperationMessage = _
                              CType(New OperationInput(), OperationMessage)
         myOperationMessageInput.Message = New XmlQualifiedName _
                              ("AddSoapIn", myDescription.TargetNamespace)
         Dim myOperationMessageOutput As OperationMessage = _
                              CType(New OperationOutput(), OperationMessage)
         myOperationMessageOutput.Message = New XmlQualifiedName _
                              ("AddSoapOut", myDescription.TargetNamespace)
         myOperation.Messages.Add(myOperationMessageInput)
         myOperation.Messages.Add(myOperationMessageOutput)
         myOperationCollection.Add(myOperation)