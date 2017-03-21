   // Displays the properties of the OperationMessageCollection.
   public static void DisplayFlowInputOutput( OperationMessageCollection
      myOperationMessageCollection, string myOperation)
   {
      Console.WriteLine("After " + myOperation + ":");
      Console.WriteLine("Flow : " + myOperationMessageCollection.Flow);
      Console.WriteLine("The first occurrence of operation Input " +
         "in the collection " + myOperationMessageCollection.Input);
      Console.WriteLine("The first occurrence of operation Output " +
         "in the collection " + myOperationMessageCollection.Output);
      Console.WriteLine();
   }