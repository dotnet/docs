
'  The following example demonstrates the 'Item[string]' property of 
'  FaultBindingCollection class
'  The program removes a fault binding with the name 'ErrorString' from 
'  the WSDL file. It also removes a operation fault with the name 
'  'ErrorString' and displays the resultant WSDL file to the console.
 

Imports System
Imports System.Web.Services.Description


Public Class FaultBindingCollection_Remove
   
   Public Shared Sub Main()
      ' Read the 'StockQuote.wsdl' file as input.
      Dim myServiceDescription As ServiceDescription = ServiceDescription.Read("StockQuote.wsdl")
      
      ' Get the operation fault collection and remove the operation fault with the name 'ErrorString'.
      Dim myPortTypeCollection As PortTypeCollection = myServiceDescription.PortTypes
      Dim myPortType As PortType = myPortTypeCollection(0)
      Dim myOperationCollection As OperationCollection = myPortType.Operations
      Dim myOperation As Operation = myOperationCollection(0)
      Dim myOperationFaultCollection As OperationFaultCollection = myOperation.Faults
      If myOperationFaultCollection.Contains(myOperationFaultCollection("ErrorString")) Then
         myOperationFaultCollection.Remove(myOperationFaultCollection("ErrorString"))
      End If 
      ' Get the fault binding collection and remove the fault binding with the name 'ErrorString'.
      ' <Snippet1>
      Dim myBindingCollection As BindingCollection = myServiceDescription.Bindings
      Dim myBinding As Binding = myBindingCollection(0)
      Dim myOperationBindingCollection As OperationBindingCollection = myBinding.Operations
      Dim myOperationBinding As OperationBinding = myOperationBindingCollection(0)
      Dim myFaultBindingCollection As FaultBindingCollection = myOperationBinding.Faults
      If myFaultBindingCollection.Contains(myFaultBindingCollection("ErrorString")) Then
         myFaultBindingCollection.Remove(myFaultBindingCollection("ErrorString"))
        End If
        ' </Snippet1>
      myServiceDescription.Write(Console.Out)
   End Sub 'Main
End Class 'FaultBindingCollection_Remove