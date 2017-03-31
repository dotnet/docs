
' * The following example demonstrates the 'Remove', 'CopyTo', 'Insert', 'Contains', 
' * 'IndexOf' method and 'Item[int]' property of FaultBindingCollection class
' * 
' * The program reverses the fault bindings that appear in the WSDL file. It also reverses
' * the operation faults and displays the resultant WSDL file to the console.
' *
Imports System
Imports System.Web.Services.Description


Public Class FaultBindingCollection_Remove
   
   Public Shared Sub Main()
      ' Read the 'StockQuote.wsdl' file as input.
      Dim myServiceDescription As ServiceDescription = ServiceDescription.Read("StockQuote.wsdl")
      
      Dim myPortTypeCollection As PortTypeCollection = myServiceDescription.PortTypes
      Dim myPortType As PortType = myPortTypeCollection(0)
      Dim myOperationCollection As OperationCollection = myPortType.Operations
      Dim myOperation As Operation = myOperationCollection(0)
      Dim myOperationFaultCollection As OperationFaultCollection = myOperation.Faults
      ' Reverse the operation fault order.
      If myOperationFaultCollection.Count > 1 Then
         Dim myOperationFaultArray(myOperationFaultCollection.Count - 1) As OperationFault
         ' Copy the operation fault to a temporary array.
         myOperationFaultCollection.CopyTo(myOperationFaultArray, 0)
         ' Remove all the operation fault instances in the fault binding collection.
         Dim i, j As Integer
         For i = 0 To myOperationFaultArray.Length - 1
            myOperationFaultCollection.Remove(myOperationFaultArray(i))
         Next i
         j = myOperationFaultArray.Length - 1
         For i = 0 To myOperationFaultArray.Length - 1
            myOperationFaultCollection.Insert(i, myOperationFaultArray(j))
            j = j - 1
         Next


      End If

      ' <Snippet1>
      ' <Snippet2>
      ' <Snippet3>
      ' <Snippet4>
      ' <Snippet5>
      ' <Snippet6>
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
' </Snippet6>
' </Snippet5>
' </Snippet4>
' </Snippet3>
' </Snippet2>
' </Snippet1>