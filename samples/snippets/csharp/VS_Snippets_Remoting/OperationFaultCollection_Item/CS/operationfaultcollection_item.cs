// System.Web.Services.Description.OperationFaultCollection.Item[string]

/*
   The following example demonstrates the 'Item' property of the
   'OperationFaultCollection' class. The program removes a fault binding 
   with the name 'ErrorString' from the WSDL file. It also removes an
   operation fault with the name 'ErrorString' and generates a WSDL file.
*/

using System;
using System.Web.Services.Description;

public class MySample
{
   public static void Main()
   {
      try
      {
         // Read the 'StockQuote.wsdl' file as input.
         ServiceDescription myServiceDescription = ServiceDescription.
                                               Read("StockQuote_cs.wsdl");
         // Remove the operation fault with the name 'ErrorString'.
         PortTypeCollection myPortTypeCollection = myServiceDescription.
                                                                PortTypes;
         PortType myPortType = myPortTypeCollection[0];
         OperationCollection myOperationCollection = myPortType.Operations;
         Operation myOperation = myOperationCollection[0];

// <Snippet1>
         OperationFaultCollection myOperationFaultCollection = 
            myOperation.Faults;
         OperationFault myOperationFault = 
            myOperationFaultCollection["ErrorString"];
         if( myOperationFault != null )
         {
            myOperationFaultCollection.Remove(myOperationFault);
         }
// </Snippet1>

         // Remove the fault binding with the name 'ErrorString'.
         BindingCollection myBindingCollection = myServiceDescription.
                                                                 Bindings;
         Binding myBinding = myBindingCollection[0];
         OperationBindingCollection myOperationBindingCollection = 
                                                     myBinding.Operations;
         OperationBinding myOperationBinding = 
                                          myOperationBindingCollection[0];
         FaultBindingCollection myFaultBindingCollection = 
                                                myOperationBinding.Faults;
         if(myFaultBindingCollection.Contains(
                                 myFaultBindingCollection["ErrorString"]))
         {
            myFaultBindingCollection.Remove(
                                 myFaultBindingCollection["ErrorString"]);
         }

         myServiceDescription.Write("OperationFaultCollection_out.wsdl");
         Console.WriteLine("WSDL file with name 'OperationFaultCollection_out.wsdl'" +
                  " created Successfully");
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
   }
}
