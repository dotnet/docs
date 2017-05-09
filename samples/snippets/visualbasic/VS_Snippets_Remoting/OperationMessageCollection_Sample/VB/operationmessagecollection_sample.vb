' System.Web.Services.Description.OperationMessageCollection
' System.Web.Services.Description.OperationMessageCollection.Item
' System.Web.Services.Description.OperationMessageCollection.CopyTo
' System.Web.Services.Description.OperationMessageCollection.Add
' System.Web.Services.Description.OperationMessageCollection.Contains
' System.Web.Services.Description.OperationMessageCollection.IndexOf
' System.Web.Services.Description.OperationMessageCollection.Remove
' System.Web.Services.Description.OperationMessageCollection.Insert
' System.Web.Services.Description.OperationMessageCollection.Flow
' System.Web.Services.Description.OperationMessageCollection.Input
' System.Web.Services.Description.OperationMessageCollection.Output

' The following example demonstrates the usage of the 
' 'OperationMessageCollection' class and various methods and properties of it.
' The input to the program is a WSDL file 'MathService_input_vb.wsdl' without
' the input message of 'Add' operation for the SOAP
' protocol. In a way it tries to simulate a scenario 
' wherein the operation flow was 'Notification', however later operation
' flow changed to 'Request-Response'.The WSDL file is
' modified by inserting a new input message for the 'Add' operation. The
' input message in the ServiceDescription instance is loaded with values for 
' 'Input Message'. The instance is then written to 'MathService_new_vb.wsdl'.

' <Snippet1>
Imports System
Imports System.Xml
Imports System.Web.Services
Imports System.Web.Services.Description

Class MyOperationMessageCollectionSample
   
   Shared Sub Main()
      Try
         Dim myDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_input_vb.wsdl")
         Dim myPortTypeCollection As PortTypeCollection = _
            myDescription.PortTypes

         ' Get the OperationCollection for the SOAP protocol.
         Dim myOperationCollection As OperationCollection = _
            myPortTypeCollection(0).Operations

         ' Get the OperationMessageCollection for the Add operation.
         Dim myOperationMessageCollection As OperationMessageCollection = _
            myOperationCollection(0).Messages
         ' Display the Flow, Input, and Output properties.
         DisplayFlowInputOutput(myOperationMessageCollection, "Start")

' <Snippet2>
' <Snippet4>
         ' Get the operation message for the Add operation.
         Dim myOperationMessage As OperationMessage = _
            myOperationMessageCollection.Item(0)
         Dim myInputOperationMessage As OperationMessage = _
            CType(New OperationInput(), OperationMessage)
         Dim myXmlQualifiedName As _
            New XmlQualifiedName("AddSoapIn", myDescription.TargetNamespace)
         myInputOperationMessage.Message = myXmlQualifiedName
         
' <Snippet3>
         Dim myCollection(myOperationMessageCollection.Count -1 ) _
            As OperationMessage
         myOperationMessageCollection.CopyTo(myCollection, 0)
         Console.WriteLine("Operation name(s) :")
         Dim i As Integer
         For i = 0 To myCollection.Length - 1
            Console.WriteLine(" " & myCollection(i).Operation.Name)
         Next i

' </Snippet3>
         ' Add the OperationMessage to the collection.
         myOperationMessageCollection.Add(myInputOperationMessage)
' </Snippet4>
         DisplayFlowInputOutput(myOperationMessageCollection, "Add")
         
' <Snippet5>
' <Snippet6>
         If myOperationMessageCollection.Contains(myOperationMessage) _
            = True Then
            Dim myIndex As Integer = _
               myOperationMessageCollection.IndexOf(myOperationMessage)
            Console.WriteLine(" The index of the Add operation " & _
                "message in the collection is : " & myIndex.ToString())
         End If
' </Snippet6>
' </Snippet5>
' </Snippet2>

' <Snippet7>
' <Snippet8>
         myOperationMessageCollection.Remove(myInputOperationMessage)

         ' Display Flow, Input, and Output after removing.
         DisplayFlowInputOutput(myOperationMessageCollection, "Remove")

         ' Insert the message at index 0 in the collection.
         myOperationMessageCollection.Insert(0, myInputOperationMessage)

         ' Display Flow, Input, and Output after inserting.
         DisplayFlowInputOutput(myOperationMessageCollection, "Insert")

' </Snippet8>
' </Snippet7>
         myDescription.Write("MathService_new_vb.wsdl")
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("Source : " & e.Source.ToString())
         Console.WriteLine("Message : " & e.Message.ToString())
      End Try
   End Sub 'Main
   
' <Snippet9>
' <Snippet10>
' <Snippet11>
   ' Displays the properties of the OperationMessageCollection.
   Public Shared Sub DisplayFlowInputOutput(myOperationMessageCollection As  _
      OperationMessageCollection, myOperation As String)

      Console.WriteLine("After " & myOperation.ToString() & ":")
      Console.WriteLine("Flow : " & _
         myOperationMessageCollection.Flow.ToString())
      Console.WriteLine("The first occurrence of operation Input " & _
         "in the collection {0}" , myOperationMessageCollection.Input)
      Console.WriteLine("The first occurrence of operation Output " & _
         "in the collection " &  myOperationMessageCollection.Output.ToString())
      Console.WriteLine()
   End Sub 'DisplayFlowInputOutput
End Class 'MyOperationMessageCollectionSample 
' </Snippet11>
' </Snippet10>
' </Snippet9>
' </Snippet1>
