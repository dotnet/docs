' System.Web.Services.Description.OperationFaultCollection.Item[String]

' The following example demonstrates the 'Item' property of the
' 'OperationFaultCollection' class. The program removes a fault binding
' with the name 'ErrorString' from the WSDL file. It also removes an
' operation fault with the name 'ErrorString' and generates a WSDL file.

Imports System
Imports System.Web.Services.Description

Public Class MySample
   Public Shared Sub Main()
      Try
         ' Read the 'StockQuote.wsdl' file as input.
         Dim myServiceDescription As ServiceDescription = _
                              ServiceDescription.Read("StockQuote_vb.wsdl")
         ' Remove the operation fault with the name 'ErrorString'.
         Dim myPortTypeCollection As PortTypeCollection = _
                                             myServiceDescription.PortTypes
         Dim myPortType As PortType = myPortTypeCollection(0)
         Dim myOperationCollection As OperationCollection = myPortType.Operations
         Dim myOperation As Operation = myOperationCollection(0)

' <Snippet1>
         Dim myOperationFaultCollection As OperationFaultCollection = _
            myOperation.Faults
         Dim myOperationFault As OperationFault = _
            myOperationFaultCollection("ErrorString")
         If Not (myOperationFault Is Nothing) Then
            myOperationFaultCollection.Remove(myOperationFault)
         End If
' </Snippet1>

         ' Remove the fault binding with the name 'ErrorString'.
         Dim myBindingCollection As BindingCollection = _
                                              myServiceDescription.Bindings
         Dim myBinding As Binding = myBindingCollection(0)
         Dim myOperationBindingCollection As OperationBindingCollection = _
                                                      myBinding.Operations
         Dim myOperationBinding As OperationBinding = _
                                            myOperationBindingCollection(0)
         Dim myFaultBindingCollection As FaultBindingCollection = _
                                                  myOperationBinding.Faults
         If myFaultBindingCollection.Contains _
            (myFaultBindingCollection("ErrorString")) Then
            myFaultBindingCollection.Remove(myFaultBindingCollection("ErrorString"))
         End If

         myServiceDescription.Write("OperationFaultCollection_out.wsdl")
         Console.WriteLine("WSDL file with name 'OperationFaultCollection_out.wsdl'" + _
                           " created Successfully")
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("Source : " + e.Source)
         Console.WriteLine("Message : " + e.Message)
      End Try
   End Sub 'Main
End Class 'MySample