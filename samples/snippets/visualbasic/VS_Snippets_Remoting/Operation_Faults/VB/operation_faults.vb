' System.Web.Services.Description.Operation.Faults

' The following program demonstrates the 'Faults' property of 'Operation'
' class. It reads from a 'Operation_Faults_Input_VB.wsdl' file removes fault
' binding and operation fault with the name 'ErrorString'. The modified
' ServiceDescriptor is written to 'Operation_Faults_Output_VB.wsdl' file.

Imports System
Imports System.Web.Services.Description

Public Class MyOperationClass

   Public Shared Sub Main()
' <Snippet1>
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
' </Snippet1>

      ' Get the fault binding collection.
      Dim myBindingCollection As BindingCollection = myServiceDescription.Bindings
      Dim myBinding As Binding = myBindingCollection(0)
      Dim myOperationBindingCollection As OperationBindingCollection = myBinding.Operations
      ' Remove the fault binding with the name 'ErrorString'.
      Dim myOperationBinding As OperationBinding = myOperationBindingCollection(0)
      Dim myFaultBindingCollection As FaultBindingCollection = myOperationBinding.Faults
      If myFaultBindingCollection.Contains(myFaultBindingCollection("ErrorString")) Then
         myFaultBindingCollection.Remove(myFaultBindingCollection("ErrorString"))
      End If
      myServiceDescription.Write("Operation_Faults_Output_VB.wsdl")
      Console.WriteLine _
           ("WSDL file with name 'Operation_Faults_Output_VB.wsdl' file created Successfully")
   End Sub 'Main
End Class 'MyOperationClass