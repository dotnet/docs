' System.Web.Services.Description.OperationFaultCollection
' System.Web.Services.Description.OperationFaultCollection.Contains
' System.Web.Services.Description.OperationFaultCollection.CopyTo
' System.Web.Services.Description.OperationFaultCollection.IndexOf
' System.Web.Services.Description.OperationFaultCollection.Insert
' System.Web.Services.Description.OperationFaultCollection.Item
' System.Web.Services.Description.OperationFaultCollection.Remove

' The following example demonstrates the usage of the 
' 'OperationFaultCollection' class, the 'Contains', 'CopyTo', 'IndexOf',
' 'Insert', 'Remove', methods and the 'Item' property of the class.
' The program reverses the fault bindings that appear in the WSDL file.
' It also reverses the operation faults and writes the resultant WSDL
' file.

' <Snippet1>
Imports System
Imports System.Web.Services.Description

Public Class MyOperationFaultCollectionSample
   
   Public Shared Sub Main()
      Try
         ' Read the StockQuote.wsdl file as input.
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("StockQuote_vb.wsdl")
' <Snippet2>
' <Snippet3>
' <Snippet4>
' <Snippet5>
' <Snippet6>
' <Snippet7>
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
' </Snippet7>
' </Snippet6>
' </Snippet5>
' </Snippet4>
' </Snippet3>
' </Snippet2>
         Dim myBindingCollection As BindingCollection = _
            myServiceDescription.Bindings
         Dim myBinding As Binding = myBindingCollection(0)
         Dim myOperationBindingCollection As OperationBindingCollection = _
            myBinding.Operations
         Dim myOperationBinding As OperationBinding = _
            myOperationBindingCollection(0)
         Dim myFaultBindingCollection As FaultBindingCollection = _
            myOperationBinding.Faults
         
         ' Reverse the fault binding order.
         If myFaultBindingCollection.Count > 1 Then
            Dim myFaultBinding As FaultBinding = myFaultBindingCollection(0)
            
            Dim myFaultBindingArray(myFaultBindingCollection.Count -1 ) _
               As FaultBinding

            ' Copy the fault bindings to a temporary array.
            myFaultBindingCollection.CopyTo(myFaultBindingArray, 0)
            
            ' Remove all the fault bindings.
            Dim i As Integer
            For i = 0 To myFaultBindingArray.Length - 1
               myFaultBindingCollection.Remove(myFaultBindingArray(i))
            Next i

            Dim j As Integer = myFaultBindingArray.Length - 1
            i = 0

            ' Insert the fault bindings in the reverse order.
            While i < myFaultBindingArray.Length
               myFaultBindingCollection.Insert(i, myFaultBindingArray(j))
               i += 1
               j -= 1
            End While
 
            ' Check whether the first element before the reversal 
            ' is now the last element.
            If myFaultBindingCollection.Contains(myFaultBinding) And _
               myFaultBindingCollection.IndexOf(myFaultBinding) = _
               myFaultBindingCollection.Count - 1 Then

               ' Write the WSDL generated to a file.
               myServiceDescription.Write("StockQuoteOut_vb.wsdl")
               Console.WriteLine( _
                  "The file StockQuoteOut_vb.wsdl was successfully written.")
            Else
               Console.WriteLine( _
                  "An Error occured while reversing the input WSDL file.")
            End If
         End If
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("Source : " & e.Source.ToString())
         Console.WriteLine("Message : " & e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyOperationFaultCollectionSample
' </Snippet1>
