      Dim myBindingCollection As BindingCollection = myServiceDescription.Bindings
      Dim myBinding As Binding = myBindingCollection(0)
      Dim myOperationBindingCollection As OperationBindingCollection = myBinding.Operations
      Dim myOperationBinding As OperationBinding = myOperationBindingCollection(0)
      Dim myFaultBindingCollection As FaultBindingCollection = myOperationBinding.Faults

      ' Reverse the fault bindings order.
      If myFaultBindingCollection.Count > 1 Then
         Dim myFaultBinding As FaultBinding = myFaultBindingCollection(0)

         Dim myFaultBindingArray(myFaultBindingCollection.Count - 1) As FaultBinding
         ' Copy the fault bindings to a temporary array.
         myFaultBindingCollection.CopyTo(myFaultBindingArray, 0)

         ' Remove all the fault binding instances in the fault binding collection.
         Dim i, j As Integer

         For i = 0 To myFaultBindingArray.Length - 1
            myFaultBindingCollection.Remove(myFaultBindingArray(i))
         Next i

         j = myFaultBindingArray.Length - 1
         For i = 0 To myFaultBindingArray.Length - 1
            myFaultBindingCollection.Insert(i, myFaultBindingArray(j))
            j = j - 1
         Next

         If myFaultBindingCollection.Contains(myFaultBinding) And myFaultBindingCollection.IndexOf(myFaultBinding) = myFaultBindingCollection.Count - 1 Then
            ' Display the WSDL generated to the console.
            myServiceDescription.Write(Console.Out)
         Else
            Console.WriteLine("Error while reversing")
         End If
      End If
   End Sub 'Main 

End Class 'FaultBindingCollection_Remove