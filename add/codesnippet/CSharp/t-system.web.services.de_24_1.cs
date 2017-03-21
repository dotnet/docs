using System;
using System.Xml;
using System.Web.Services;
using System.Web.Services.Description;

class MyOperationMessageCollectionSample
{
   static void Main()
   {
      try
      {
         ServiceDescription myDescription =
            ServiceDescription.Read("MathService_input_cs.wsdl");
         PortTypeCollection myPortTypeCollection  =
            myDescription.PortTypes;

         // Get the OperationCollection for the SOAP protocol.
         OperationCollection myOperationCollection =
            myPortTypeCollection[0].Operations;

         // Get the OperationMessageCollection for the Add operation.
         OperationMessageCollection myOperationMessageCollection =
            myOperationCollection[0].Messages;

         // Display the Flow, Input, and Output properties.
         DisplayFlowInputOutput(myOperationMessageCollection, "Start");

         // Get the operation message for the Add operation.
         OperationMessage myOperationMessage =
            myOperationMessageCollection[0];
         OperationMessage myInputOperationMessage =
            (OperationMessage) new OperationInput();
         XmlQualifiedName myXmlQualifiedName = new XmlQualifiedName(
            "AddSoapIn", myDescription.TargetNamespace);
         myInputOperationMessage.Message = myXmlQualifiedName;

         OperationMessage[] myCollection = 
            new OperationMessage[myOperationMessageCollection.Count];
         myOperationMessageCollection.CopyTo(myCollection, 0);
         Console.WriteLine("Operation name(s) :");
         for (int i = 0; i < myCollection.Length ; i++)
         {
            Console.WriteLine(" " + myCollection[i].Operation.Name);
         }

         // Add the OperationMessage to the collection.
         myOperationMessageCollection.Add(myInputOperationMessage);
         DisplayFlowInputOutput(myOperationMessageCollection, "Add");

         if(myOperationMessageCollection.Contains(myOperationMessage) 
            == true )
         {
            int myIndex =
               myOperationMessageCollection.IndexOf(myOperationMessage);
            Console.WriteLine(" The index of the Add operation " +
               "message in the collection is : " + myIndex);
         }

         myOperationMessageCollection.Remove(myInputOperationMessage);

         // Display Flow, Input, and Output after removing.
         DisplayFlowInputOutput(myOperationMessageCollection, "Remove");

         // Insert the message at index 0 in the collection.
         myOperationMessageCollection.Insert(0, myInputOperationMessage);

         // Display Flow, Input, and Output after inserting.
         DisplayFlowInputOutput(myOperationMessageCollection, "Insert");

         myDescription.Write("MathService_new_cs.wsdl");
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
   }

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
}