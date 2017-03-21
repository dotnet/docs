         Dim myOperationFaultCollection As OperationFaultCollection = myOperation.Faults
         Dim myOperationFault As New OperationFault()
         myOperationFault.Name = "ErrorString"
         myOperationFault.Message = New XmlQualifiedName("s0:GetTradePriceStringFault")
         myOperationFaultCollection.Add(myOperationFault)