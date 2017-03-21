      ' Create an Operation.
      Dim myOperation As New Operation()
      myOperation.Name = myOperationName
      Dim myInput As OperationMessage = _
         CType(New OperationInput(), OperationMessage)
      myInput.Message = New XmlQualifiedName(myInputMesg)
      Dim myOutput As OperationMessage = _
         CType(New OperationOutput(), OperationMessage)
      myOutput.Message = New XmlQualifiedName(myOutputMesg)

      ' Add messages to the OperationMessageCollection.
      myOperation.Messages.Add(myInput)
      myOperation.Messages.Add(myOutput)
      Console.WriteLine("Operation name is: " & myOperation.Name)