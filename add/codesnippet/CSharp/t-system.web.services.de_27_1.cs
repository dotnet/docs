using System;
using System.Web.Services.Description;
using System.Xml;

class MyPortTypeClass
{
   public static void Main()
   {
      try
      {
         PortTypeCollection myPortTypeCollection;
         ServiceDescription myServiceDescription =
            ServiceDescription.Read("MathService_CS.wsdl");
         
         myPortTypeCollection = myServiceDescription.PortTypes;
         int noOfPortTypes = myServiceDescription.PortTypes.Count;
         Console.WriteLine("\nTotal number of PortTypes : "
            + noOfPortTypes);

         PortType myPortType = myPortTypeCollection["MathServiceSoap"];
         myPortTypeCollection.Remove(myPortType);

         // Create a new PortType.
         PortType myNewPortType = new PortType();
         myNewPortType.Name = "MathServiceSoap";
         OperationCollection myOperationCollection = 
            myServiceDescription.PortTypes[0].Operations;
         for(int i=0;i<myOperationCollection.Count;i++)
         {
            string inputmsg = myOperationCollection[i].Name + "SoapIn";
            string outputmsg = myOperationCollection[i].Name + "SoapOut";
            Console.WriteLine("Operation = " + myOperationCollection[i].Name);
            myNewPortType.Operations.Add(
               CreateOperation(myOperationCollection[i].Name, inputmsg, 
               outputmsg,myServiceDescription.TargetNamespace));
         }

         // Add the PortType to the collection.
         myPortTypeCollection.Add(myNewPortType);
         noOfPortTypes = myServiceDescription.PortTypes.Count;
         Console.WriteLine("\nTotal Number of PortTypes : " 
            + noOfPortTypes);
         myServiceDescription.Write("MathService_New.wsdl");
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception: " + e.Message);
      }
   }
   public static Operation CreateOperation(string operationName, 
      string inputMessage, string outputMessage, string targetNamespace)
   {
      Operation myOperation = new Operation();
      myOperation.Name = operationName;
      OperationMessage input = (OperationMessage) new OperationInput();
      input.Message = new XmlQualifiedName(inputMessage, targetNamespace);
      OperationMessage output = (OperationMessage) new OperationOutput();
      output.Message = new XmlQualifiedName(outputMessage, targetNamespace);
      myOperation.Messages.Add(input);
      myOperation.Messages.Add(output);
      return myOperation;
   }
}