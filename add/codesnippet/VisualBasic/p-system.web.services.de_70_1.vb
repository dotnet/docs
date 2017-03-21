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