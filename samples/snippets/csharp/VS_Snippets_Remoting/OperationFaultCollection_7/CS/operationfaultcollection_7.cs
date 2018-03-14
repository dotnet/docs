// System.Web.Services.Description.OperationFaultCollection
// System.Web.Services.Description.OperationFaultCollection.Contains
// System.Web.Services.Description.OperationFaultCollection.CopyTo
// System.Web.Services.Description.OperationFaultCollection.IndexOf
// System.Web.Services.Description.OperationFaultCollection.Insert
// System.Web.Services.Description.OperationFaultCollection.Item
// System.Web.Services.Description.OperationFaultCollection.Remove

/*
   The following example demonstrates the usage of the 
   'OperationFaultCollection' class, the 'Contains', 'CopyTo', 'IndexOf',
   'Insert', 'Remove', methods and the 'Item' property of the class.
   The program reverses the fault bindings that appear in the WSDL file.
   It also reverses the operation faults and writes the resultant WSDL
   file.
*/

// <Snippet1>
using System;
using System.Web.Services.Description;

public class MyOperationFaultCollectionSample
{
   public static void Main()
   {
      try
      {
         // Read the StockQuote.wsdl file as input.
         ServiceDescription myServiceDescription = 
            ServiceDescription.Read("StockQuote_cs.wsdl");
// <Snippet2>
// <Snippet3>
// <Snippet4>
// <Snippet5>
// <Snippet6>
// <Snippet7>
         PortTypeCollection myPortTypeCollection = 
            myServiceDescription.PortTypes;
         PortType myPortType = myPortTypeCollection[0];
         OperationCollection myOperationCollection = myPortType.Operations;
         Operation myOperation = myOperationCollection[0];
         OperationFaultCollection myOperationFaultCollection = 
            myOperation.Faults;

         // Reverse the operation fault order.
         if(myOperationFaultCollection.Count > 1)
         {
            OperationFault myOperationFault = myOperationFaultCollection[0];
            OperationFault[] myOperationFaultArray = 
               new OperationFault[myOperationFaultCollection.Count];

            // Copy the operation faults to a temporary array.
            myOperationFaultCollection.CopyTo(myOperationFaultArray, 0);

            // Remove all the operation faults from the collection.
            for(int i = 0; i < myOperationFaultArray.Length; i++)
            {
               myOperationFaultCollection.Remove(myOperationFaultArray[i]);
            }

            // Insert the operation faults in the reverse order.
            for(int i = 0, j = (myOperationFaultArray.Length - 1);
               i < myOperationFaultArray.Length; i++, j--)
            {
               myOperationFaultCollection.Insert(
                  i, myOperationFaultArray[j]);
            }
            if ( myOperationFaultCollection.Contains(myOperationFault) &&
               (myOperationFaultCollection.IndexOf(myOperationFault) 
               == myOperationFaultCollection.Count-1))
            {
               Console.WriteLine(
                  "Succeeded in reversing the operation faults.");
            }
            else 
            {
               Console.WriteLine("Error while reversing the faults.");
            }
         }
// </Snippet7>
// </Snippet6>
// </Snippet5>
// </Snippet4>
// </Snippet3>
// </Snippet2>
         BindingCollection myBindingCollection = 
            myServiceDescription.Bindings;
         Binding myBinding = myBindingCollection[0];
         OperationBindingCollection myOperationBindingCollection = 
            myBinding.Operations;
         OperationBinding myOperationBinding = 
            myOperationBindingCollection[0];
         FaultBindingCollection myFaultBindingCollection = 
            myOperationBinding.Faults;

         // Reverse the fault binding order.
         if(myFaultBindingCollection.Count > 1) 
         {
            FaultBinding myFaultBinding = myFaultBindingCollection[0];

            FaultBinding[] myFaultBindingArray = 
               new FaultBinding[myFaultBindingCollection.Count];

            // Copy the fault bindings to a temporary array.
            myFaultBindingCollection.CopyTo(myFaultBindingArray, 0);

            // Remove all the fault bindings.
            for(int i = 0; i < myFaultBindingArray.Length; i++)
            {
               myFaultBindingCollection.Remove(myFaultBindingArray[i]);
            }

            // Insert the fault bindings in the reverse order.
            for(int i = 0, j = (myFaultBindingArray.Length - 1);
               i < myFaultBindingArray.Length; i++, j--)
            {
               myFaultBindingCollection.Insert(i, myFaultBindingArray[j]);
            }

            // Check whether the first element before the reversal 
            // is now the last element.
            if(myFaultBindingCollection.Contains(myFaultBinding) && 
               myFaultBindingCollection.IndexOf(myFaultBinding) == 
               (myFaultBindingCollection.Count - 1))
            {
               // Write the WSDL generated to a file.
               myServiceDescription.Write("StockQuoteOut_cs.wsdl");
               Console.WriteLine(
                  "The file StockQuoteOut_cs.wsdl was successfully written.");
            }
            else
            {
               Console.WriteLine(
                  "An error occured while reversing the input WSDL file.");
            }
         }
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
   }
}
// </Snippet1>
