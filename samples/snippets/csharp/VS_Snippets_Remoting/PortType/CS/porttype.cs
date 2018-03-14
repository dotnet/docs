// System.Web.Services.Description.PortType.Operations
// System.Web.Services.Description.PortType.PortType()
// System.Web.Services.Description.PortType.Name

/*The following sample demonstrates the properties 'Operations','Name' and constructor
  'PortType()' of class 'PortType'.This sample reads the contents of a file 'MathService_cs.wsdl'
  into a 'ServiceDescription' instance. It gets the collection of 'PortType'
  instances from 'ServiceDescription'. It removes a 'PortType' from the collection, creates a 
  new 'PortType' and adds it into collection.The programs writes a new web service description 
  file 'MathService_New.wsdl'.
*/

// <Snippet1>
using System;
using System.Web.Services.Description;
using System.Xml;

class MyPortTypeClass
{
   public static void Main()
   {
      try
      {
// <Snippet2>
// <Snippet3>
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
         
         string inputMsg,outputMsg;
         for(int i = 0; i < myOperationCollection.Count; i++)
         {
            inputMsg = myOperationCollection[i].Name + "SoapIn";
            outputMsg = myOperationCollection[i].Name + "SoapOut";
            Console.WriteLine(" Operation = " + myOperationCollection[i].Name);
            myNewPortType.Operations.Add(
               CreateOperation(myOperationCollection[i].Name, 
               inputMsg, outputMsg, myServiceDescription.TargetNamespace));
         }
         // Add the PortType to the collection.
         myPortTypeCollection.Add(myNewPortType);
         noOfPortTypes = myServiceDescription.PortTypes.Count;
         Console.WriteLine("\nTotal number of PortTypes : " 
            + noOfPortTypes);
         myServiceDescription.Write("MathService_New.wsdl");
// </Snippet3>
// </Snippet2>
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception:" + e.Message);
      }
   }
   public static Operation CreateOperation(string operationName,
      string inputMessage,string outputMessage,string targetNamespace)
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
// </Snippet1>
