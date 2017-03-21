using System;
using System.Web.Services;
using System.Xml;
using System.Web.Services.Description;

class MyOperationCollectionSample
{
   public static void Main()
   {
      try
      {
         // Read the 'MathService_Input_cs.wsdl' file.
         ServiceDescription myDescription = 
                     ServiceDescription.Read("MathService_Input_cs.wsdl");
         PortTypeCollection myPortTypeCollection =myDescription.PortTypes;
         // Get the 'OperationCollection' for 'SOAP' protocol.
         OperationCollection myOperationCollection = 
                                       myPortTypeCollection[0].Operations;
         Operation myOperation = new Operation();
         myOperation.Name = "Add";
         OperationMessage myOperationMessageInput = 
                                  (OperationMessage) new OperationInput();
         myOperationMessageInput.Message = new XmlQualifiedName
                              ("AddSoapIn",myDescription.TargetNamespace);
         OperationMessage myOperationMessageOutput = 
                                 (OperationMessage) new OperationOutput();
         myOperationMessageOutput.Message = new XmlQualifiedName(
                              "AddSoapOut",myDescription.TargetNamespace);
         myOperation.Messages.Add(myOperationMessageInput);
         myOperation.Messages.Add(myOperationMessageOutput);
         myOperationCollection.Add(myOperation);

         if(myOperationCollection.Contains(myOperation) == true)
         {
            Console.WriteLine("The index of the added 'myOperation' " +
                              "operation is : " +
                              myOperationCollection.IndexOf(myOperation));
         }

         myOperationCollection.Remove(myOperation);
         // Insert the 'myOpearation' operation at the index '0'.
         myOperationCollection.Insert(0, myOperation);
         Console.WriteLine("The operation at index '0' is : " +
                           myOperationCollection[0].Name);

         Operation[] myOperationArray = new Operation[
                                             myOperationCollection.Count];
         myOperationCollection.CopyTo(myOperationArray, 0);
         Console.WriteLine("The operation(s) in the collection are :");
         for(int i = 0; i < myOperationCollection.Count; i++)
         {
            Console.WriteLine(" " + myOperationArray[i].Name);
         }

         myDescription.Write("MathService_New_cs.wsdl");
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
   }
}