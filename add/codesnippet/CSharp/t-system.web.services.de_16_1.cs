using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

class MyOperationClass
{
   public static void Main()
   {
      ServiceDescription myDescription = ServiceDescription.Read("Operation_5_Input_CS.wsdl");
      // Create a 'PortType' object.
      PortType myPortType = new PortType();
      myPortType.Name = "OperationServiceHttpPost";
      Operation myOperation = CreateOperation
                         ("AddNumbers","s0:AddNumbersHttpPostIn","s0:AddNumbersHttpPostOut");    
      myPortType.Operations.Add(myOperation);
      // Get the PortType of the Operation. 
      PortType myPort = myOperation.PortType;
      Console.WriteLine(
         "The port type of the operation is: " + myPort.Name);
      // Add the 'PortType's to 'PortTypeCollection' of 'ServiceDescription'.
      myDescription.PortTypes.Add(myPortType);
      
      // Write the 'ServiceDescription' as a WSDL file.
      myDescription.Write("Operation_5_Output_CS.wsdl");
      Console.WriteLine("WSDL file with name 'Operation_5_Output_CS.wsdl' file created Successfully");
   }
   public static Operation CreateOperation(string myOperationName,string myInputMesg,string myOutputMesg)
   {
      // Create an Operation.
      Operation myOperation = new Operation();
      myOperation.Name = myOperationName;
      OperationMessage myInput = (OperationMessage)new OperationInput();
      myInput.Message =  new XmlQualifiedName(myInputMesg);
      OperationMessage myOutput = (OperationMessage)new OperationOutput();
      myOutput.Message = new XmlQualifiedName(myOutputMesg);

      // Add messages to the OperationMessageCollection.
      myOperation.Messages.Add(myInput);
      myOperation.Messages.Add(myOutput);
      Console.WriteLine("Operation name is: " + myOperation.Name);     
      return myOperation;
   }
}