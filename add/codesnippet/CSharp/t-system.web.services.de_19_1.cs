using System;
using System.Xml;
using System.Web.Services;
using System.Web.Services.Description;

class MyOperationMessageSample
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

         OperationMessage myInputOperationMessage =
            (OperationMessage) new OperationInput();
         XmlQualifiedName myXmlQualifiedName = new XmlQualifiedName(
            "AddSoapIn", myDescription.TargetNamespace);
         myInputOperationMessage.Message = myXmlQualifiedName;
         myOperationMessageCollection.Insert(0, myInputOperationMessage);

         // Display the operation name of the InputMessage.
         Console.WriteLine("The operation name is " + 
            myInputOperationMessage.Operation.Name);

         // Add the OperationMessage to the collection.
         myDescription.Write("MathService_new_cs.wsdl");
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
   }
}