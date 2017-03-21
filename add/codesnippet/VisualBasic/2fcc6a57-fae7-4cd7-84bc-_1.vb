         Dim myPortTypeCollection As PortTypeCollection = _
            myServiceDescription.PortTypes
         Dim myPortType As PortType = myPortTypeCollection(0)
         Dim myOperationCollection As OperationCollection = _
            myPortType.Operations
         Dim myOperation As Operation = myOperationCollection(0)
         Dim myOperationFaultCollection As OperationFaultCollection = _
            myOperation.Faults

         ' Reverse the operation fault order.
         If myOperationFaultCollection.Count > 1 Then
            Dim myOperationFault As OperationFault = _
               myOperationFaultCollection(0)
            Dim myOperationFaultArray(myOperationFaultCollection.Count -1 ) _
               As OperationFault

            ' Copy the operation faults to a temporary array.
            myOperationFaultCollection.CopyTo(myOperationFaultArray, 0)

            ' Remove all the operation faults from the collection.
            Dim i As Integer
            For i = 0 To myOperationFaultArray.Length - 1
               myOperationFaultCollection.Remove(myOperationFaultArray(i))
            Next i

            ' Insert the operation faults in the reverse order.
            Dim j As Integer = myOperationFaultArray.Length - 1
            i = 0
            While i < myOperationFaultArray.Length
               myOperationFaultCollection.Insert(i, myOperationFaultArray(j))
               i += 1
               j -= 1
            End While
            If myOperationFaultCollection.Contains(myOperationFault) And _
               myOperationFaultCollection.IndexOf(myOperationFault) = _
               myOperationFaultCollection.Count - 1 Then
               Console.WriteLine("Succeeded in reversing the operation faults.")
            Else
               Console.WriteLine("Error while reversing the faults.")
            End If
         End If