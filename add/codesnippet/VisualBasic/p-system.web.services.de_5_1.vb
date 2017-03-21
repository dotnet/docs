         Dim myOperationFaultCollection As OperationFaultCollection = _
            myOperation.Faults
         Dim myOperationFault As OperationFault = _
            myOperationFaultCollection("ErrorString")
         If Not (myOperationFault Is Nothing) Then
            myOperationFaultCollection.Remove(myOperationFault)
         End If