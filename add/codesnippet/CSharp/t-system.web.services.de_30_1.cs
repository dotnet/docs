using System;
using System.Xml;
using System.Web.Services;
using System.Web.Services.Description;

class MyOperationFlowSample
{
   public static void Main()
   {
      try
      {
         ServiceDescription myDescription = 
            ServiceDescription.Read("MathService_Input_cs.wsdl");
         PortTypeCollection  myPortTypeCollection  = 
            myDescription.PortTypes;

         // Get the OperationCollection for SOAP protocol.
         OperationCollection myOperationCollection = 
            myPortTypeCollection[0].Operations;

         // Get the OperationMessageCollection for the Add operation.
         OperationMessageCollection myOperationMessageCollection = 
            myOperationCollection[0].Messages;

         // Indicate that the endpoint or service receives no 
         // transmissions (None).
         Console.WriteLine("myOperationMessageCollection does not " +
            "contain any operation messages.");
         DisplayOperationFlowDescription(myOperationMessageCollection.Flow);
         Console.WriteLine();

         // Indicate that the endpoint or service receives a message (OneWay).
         OperationMessage myInputOperationMessage = 
            (OperationMessage) new OperationInput();
         XmlQualifiedName myXmlQualifiedName = 
            new XmlQualifiedName("AddSoapIn", myDescription.TargetNamespace);
         myInputOperationMessage.Message = myXmlQualifiedName;
         myOperationMessageCollection.Add(myInputOperationMessage);
         Console.WriteLine("myOperationMessageCollection contains " +
            "only input operation messages.");
         DisplayOperationFlowDescription(myOperationMessageCollection.Flow);
         Console.WriteLine();

         myOperationMessageCollection.Remove(myInputOperationMessage);

         // Indicate that an endpoint or service sends a message (Notification).
         OperationMessage myOutputOperationMessage = 
            (OperationMessage) new OperationOutput();
         XmlQualifiedName myXmlQualifiedName1 = new XmlQualifiedName
            ("AddSoapOut", myDescription.TargetNamespace);
         myOutputOperationMessage.Message = myXmlQualifiedName1;
         myOperationMessageCollection.Add(myOutputOperationMessage);
         Console.WriteLine("myOperationMessageCollection contains " +
            "only output operation messages.");
         DisplayOperationFlowDescription(myOperationMessageCollection.Flow);
         Console.WriteLine();

         // Indicate that an endpoint or service sends a message, then
         // receives a correlated message (SolicitResponse).
         myOperationMessageCollection.Add(myInputOperationMessage);
         Console.WriteLine("'myOperationMessageCollection' contains " +
            "an output operation message first, then " +
            "an input operation message.");
         DisplayOperationFlowDescription(myOperationMessageCollection.Flow);
         Console.WriteLine();

         // Indicate that an endpoint or service receives a message,
         // then sends a correlated message (RequestResponse).
         myOperationMessageCollection.Remove(myInputOperationMessage);
         myOperationMessageCollection.Insert(0, myInputOperationMessage);
         Console.WriteLine("myOperationMessageCollection contains " +
            "an input operation message first, then " +
            "an output operation message.");
         DisplayOperationFlowDescription(myOperationMessageCollection.Flow);
         Console.WriteLine();

         myDescription.Write("MathService_new_cs.wsdl");
         Console.WriteLine(
            "The file MathService_new_cs.wsdl was successfully written.");
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
   }

   public static void DisplayOperationFlowDescription(
      OperationFlow myOperationFlow)
   {
      switch(myOperationFlow)
      {
         case OperationFlow.None:
            Console.WriteLine("Indicates that the endpoint or service " +
               "receives no transmissions (None).");
            break;
         case OperationFlow.OneWay:
            Console.WriteLine("Indicates that the endpoint or service " +
               "receives a message (OneWay).");
            break;
         case OperationFlow.Notification:
            Console.WriteLine("Indicates that the endpoint or service " +
               "sends a message (Notification).");
            break;
         case OperationFlow.SolicitResponse:
            Console.WriteLine("Indicates that the endpoint or service " +
               "sends a message, then receives a " +
               "correlated message (SolicitResponse).");
            break;
         case OperationFlow.RequestResponse:
            Console.WriteLine("Indicates that the endpoint or service " +
               "receives a message, then sends a " +
               "correlated message (RequestResponse).");
            break;
      }
   }
}