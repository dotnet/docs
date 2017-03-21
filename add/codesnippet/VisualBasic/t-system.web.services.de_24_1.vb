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

         ' Get the operation message for the Add operation.
         Dim myOperationMessage As OperationMessage = _
            myOperationMessageCollection.Item(0)
         Dim myInputOperationMessage As OperationMessage = _
            CType(New OperationInput(), OperationMessage)
         Dim myXmlQualifiedName As _
            New XmlQualifiedName("AddSoapIn", myDescription.TargetNamespace)
         myInputOperationMessage.Message = myXmlQualifiedName
         
         Dim myCollection(myOperationMessageCollection.Count -1 ) _
            As OperationMessage
         myOperationMessageCollection.CopyTo(myCollection, 0)
         Console.WriteLine("Operation name(s) :")
         Dim i As Integer
         For i = 0 To myCollection.Length - 1
            Console.WriteLine(" " & myCollection(i).Operation.Name)
         Next i

         ' Add the OperationMessage to the collection.
         myOperationMessageCollection.Add(myInputOperationMessage)
         DisplayFlowInputOutput(myOperationMessageCollection, "Add")
         
         If myOperationMessageCollection.Contains(myOperationMessage) _
            = True Then
            Dim myIndex As Integer = _
               myOperationMessageCollection.IndexOf(myOperationMessage)
            Console.WriteLine(" The index of the Add operation " & _
                "message in the collection is : " & myIndex.ToString())
         End If

         myOperationMessageCollection.Remove(myInputOperationMessage)

         ' Display Flow, Input, and Output after removing.
         DisplayFlowInputOutput(myOperationMessageCollection, "Remove")

         ' Insert the message at index 0 in the collection.
         myOperationMessageCollection.Insert(0, myInputOperationMessage)

         ' Display Flow, Input, and Output after inserting.
         DisplayFlowInputOutput(myOperationMessageCollection, "Insert")

         myDescription.Write("MathService_new_vb.wsdl")
      Catch e As Exception
         Console.WriteLine("Exception caught!!!")
         Console.WriteLine("Source : " & e.Source.ToString())
         Console.WriteLine("Message : " & e.Message.ToString())
      End Try
   End Sub 'Main
   
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