// <Snippet3>
using System;
using System.Diagnostics.Contracts;

static class ValidationHelper 
{
   [ContractArgumentValidator]
   public static void NotNull(object argument, string parameterName) 
   {
      if (argument == null) throw new ArgumentNullException(parameterName, 
                                                            "The parameter cannot be null.");
      Contract.EndContractBlock();
   }

   [ContractArgumentValidator]
   public static void InRange(object[] array, int index, string arrayName, string indexName)
   {
      NotNull(array, arrayName);
      
      if (index < 0) 
         throw new ArgumentOutOfRangeException(indexName, 
                                               "The index cannot be negative.");
      if (index >= array.Length) 
         throw new ArgumentOutOfRangeException(indexName, 
                                               "The index is outside the bounds of the array.");                                                     
      Contract.EndContractBlock();
   }
}

public class Example
{
   public void Execute(object[] data, int position) 
   {
      ValidationHelper.InRange(data, position, "data", "position");

      // Body of method goes here.
   }
}
// </Snippet3>


public class Test
{
   public static void Main()
   {
      object[] numbers = {1, 2, 3, 4, 5, 6};
      Example ex = new Example();
      ex.Execute(numbers, 3);
      Console.WriteLine("No exception!");
   } 
}