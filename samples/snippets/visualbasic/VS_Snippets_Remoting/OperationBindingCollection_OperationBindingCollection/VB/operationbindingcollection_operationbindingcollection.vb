' System.Web.Services.Description.OperationBindingCollection
' System.Web.Services.Description.OperationBindingCollection.Contains
' System.Web.Services.Description.OperationBindingCollection.Add
' System.Web.Services.Description.OperationBindingCollection.Item
' System.Web.Services.Description.OperationBindingCollection.Remove
' System.Web.Services.Description.OperationBindingCollection.Insert
' System.Web.Services.Description.OperationBindingCollection.IndexOf
' System.Web.Services.Description.OperationBindingCollection.CopyTo

' The following example demonstrates the usage of the
' 'OperationBindingCollection' class, the 'Item' property and various methods of the
' class. The input to the program is a WSDL file 'MathService_input_cs.wsdl' without
' the add operation binding of SOAP protocol. In this example the WSDL file
' is modified to insert a new 'OperationBinding' for SOAP. The
' 'OperationBindingCollection' is populated based on WSDL document
' structure defined in WSDL specification. The updated instance is then
' written to 'MathService_new_cs.wsdl'.
'

' <Snippet1>
Imports System
Imports System.Web.Services.Description
Imports Microsoft.VisualBasic

Class MyOperationBindingCollectionSample

   Shared Sub Main()
      Try
         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_input_vb.wsdl")

         ' Add the OperationBinding for the Add operation.
         Dim addOperationBinding As New OperationBinding()
         Dim addOperation As String = "Add"
         Dim myTargetNamespace As String = myServiceDescription.TargetNamespace
         addOperationBinding.Name = addOperation

         ' Add the InputBinding for the operation.
         Dim myInputBinding As New InputBinding()
         Dim mySoapBodyBinding As New SoapBodyBinding()
         mySoapBodyBinding.Use = SoapBindingUse.Literal
         myInputBinding.Extensions.Add(mySoapBodyBinding)
         addOperationBinding.Input = myInputBinding

         ' Add the OutputBinding for the operation.
         Dim myOutputBinding As New OutputBinding()
         myOutputBinding.Extensions.Add(mySoapBodyBinding)
         addOperationBinding.Output = myOutputBinding

         ' Add the extensibility element for the SoapOperationBinding.
         Dim mySoapOperationBinding As New SoapOperationBinding()
         mySoapOperationBinding.Style = SoapBindingStyle.Document
         mySoapOperationBinding.SoapAction = myTargetNamespace & addOperation
         addOperationBinding.Extensions.Add(mySoapOperationBinding)

         ' Get the BindingCollection from the ServiceDescription.
         Dim myBindingCollection As BindingCollection = _
            myServiceDescription.Bindings

         ' Get the OperationBindingCollection of SOAP binding from
         ' the BindingCollection.
         Dim myOperationBindingCollection As OperationBindingCollection = _
            myBindingCollection(0).Operations

' <Snippet2>
         ' Check for the Add OperationBinding in the collection.
         Dim contains As Boolean = _
            myOperationBindingCollection.Contains(addOperationBinding)
         Console.WriteLine(ControlChars.NewLine & _
            "Whether the collection contains the Add " & _
            "OperationBinding : " & contains.ToString())
' </Snippet2>

' <Snippet3>
         ' Add the Add OperationBinding to the collection.
         myOperationBindingCollection.Add(addOperationBinding)
         Console.WriteLine(ControlChars.NewLine & _
            "Added the OperationBinding of the Add " & _
            "operation to the collection.")
' </Snippet3>

' <Snippet4>
' <Snippet5>
         ' Get the OperationBinding of the Add operation from the collection.
         Dim myOperationBinding As OperationBinding = _
            myOperationBindingCollection(3)

         ' Remove the OperationBinding of the 'Add' operation from
         ' the collection.
         myOperationBindingCollection.Remove(myOperationBinding)
         Console.WriteLine(ControlChars.NewLine & _
            "Removed the OperationBinding of the " & _
            "Add operation from the collection.")
' </Snippet5>
' </Snippet4>
' <Snippet6>
' <Snippet7>
         ' Insert the OperationBinding of the Add operation at index 0.
         myOperationBindingCollection.Insert(0, addOperationBinding)
         Console.WriteLine(ControlChars.NewLine & _
            "Inserted the OperationBinding of the " & _
            "Add operation in the collection.")

         ' Get the index of the OperationBinding of the Add
         ' operation from the collection.
         Dim index As Integer = myOperationBindingCollection.IndexOf( _
            addOperationBinding)
         Console.WriteLine(ControlChars.NewLine & _
            "The index of the OperationBinding of the " & _
            "Add operation : " & index.ToString())
' </Snippet7>
' </Snippet6>
         Console.WriteLine("")

' <Snippet8>
         Dim operationBindingArray(myOperationBindingCollection.Count -1  ) _
            As OperationBinding

         ' Copy this collection to the OperationBinding array.
         myOperationBindingCollection.CopyTo(operationBindingArray, 0)
         Console.WriteLine("The operations supported by this service " & _
            "are :")
         Dim myOperationBinding1 As OperationBinding
         For Each myOperationBinding1 In  operationBindingArray
            Dim myBinding As Binding = myOperationBinding1.Binding
            Console.WriteLine(" Binding : " & myBinding.Name & " Name of " & _
               "operation : " & myOperationBinding1.Name)
         Next myOperationBinding1
' </Snippet8>

         ' Save the ServiceDescription to an external file.
         myServiceDescription.Write("MathService_new_vb.wsdl")
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("Source : " & e.Source.ToString())
         Console.WriteLine("Message : " & e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyOperationBindingCollectionSample
' </Snippet1>
