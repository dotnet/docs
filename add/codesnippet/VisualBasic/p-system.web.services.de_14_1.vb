      ' Read the 'Operation_Faults_Input_VB.wsdl' file as input.
      Dim myServiceDescription As ServiceDescription = _
                     ServiceDescription.Read("Operation_Faults_Input_VB.wsdl")

      ' Get the operation fault collection.
      Dim myPortTypeCollection As PortTypeCollection = myServiceDescription.PortTypes
      Dim myPortType As PortType = myPortTypeCollection(0)
      Dim myOperationCollection As OperationCollection = myPortType.Operations

      ' Remove the operation fault with the name 'ErrorString'.
      Dim myOperation As Operation = myOperationCollection(0)
      Dim myOperationFaultCollection As OperationFaultCollection = myOperation.Faults
      If myOperationFaultCollection.Contains(myOperationFaultCollection("ErrorString")) Then
         myOperationFaultCollection.Remove(myOperationFaultCollection("ErrorString"))
      End If