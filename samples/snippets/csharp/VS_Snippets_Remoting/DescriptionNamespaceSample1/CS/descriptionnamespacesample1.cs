// System.Web.Services.Description.InputBinding.InputBinding();
// System.Web.Services.Description.InputBinding.Extensions
// System.Web.Services.Description.InputBinding

// System.Web.Services.Description.Message.Message();
// System.Web.Services.Description.Message.Name;
// System.Web.Services.Description.Message.Parts;

// System.Web.Services.Description.MessageCollection.Add;
// System.Web.Services.Description.MessageCollection.Insert;
// System.Web.Services.Description.MessageCollection;

// System.Web.Services.Description.MessagePart.MessagePart();
// System.Web.Services.Description.MessagePart.Element;
// System.Web.Services.Description.MessagePart.Name;
// System.Web.Services.Description.MessagePart;

// System.Web.Services.Description.MessagePartCollection.Add;
// System.Web.Services.Description.MessagePartCollection.Insert;

/*
  The following program takes input a WSDL file 'MathService_input.wsdl' with all information related to SOAP protocol
  removed from it.In a way it tries to simulate a scenario wherein a service initially did not support a protocol, however later
  on happen to support it.
  In this example the WSDL file is modified to insert a new Binding for SOAP. The binding is populated based on
  WSDL document structure defined in WSDL specification. The ServiceDescription instance is loaded with values
  for 'Messages', 'PortTypes','Bindings' and 'Port'.The instance is then written to an external file 'MathService_new.wsdl'.

  */
using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

class MyClass1
{
   public static void Main()
   {
// <Snippet9>
      ServiceDescription myServiceDescription = 
         ServiceDescription.Read("MathService_input_cs.wsdl");

      // Create SOAP messages.
// <Snippet7>
      Message myMessage = new Message();
      myMessage.Name = "AddSoapOut";
// <Snippet14>
      MessagePart myMessagePart = new MessagePart();
      myMessagePart.Name = "parameters";
      myMessagePart.Element = new 
         XmlQualifiedName("AddResponse",myServiceDescription.TargetNamespace);
      myMessage.Parts.Add(myMessagePart);
// </Snippet14>
      myServiceDescription.Messages.Add(myMessage);
// </Snippet9>
// </Snippet7>
// <Snippet8>
      Message myMessage1 = new Message();
      myMessage1.Name = "AddSoapIn";
// <Snippet15>
      MessagePart myMessagePart1 = new MessagePart();
      myMessagePart1.Name = "parameters";
      myMessagePart1.Element = new XmlQualifiedName("Add",myServiceDescription.TargetNamespace);
      myMessage1.Parts.Insert(0,myMessagePart1);
// </Snippet15>
      myServiceDescription.Messages.Insert(16,myMessage1);
// </Snippet8>

      myServiceDescription.Messages.Add(
         CreateMessage("SubtractSoapIn","parameters",
         "Subtract",myServiceDescription.TargetNamespace));
      myServiceDescription.Messages.Add(
         CreateMessage("SubtractSoapOut","parameters",
         "SubtractResponse",myServiceDescription.TargetNamespace));
      myServiceDescription.Messages.Add(
         CreateMessage("MultiplySoapIn","parameters",
         "Multiply",myServiceDescription.TargetNamespace));
      myServiceDescription.Messages.Add(
         CreateMessage("MultiplySoapOut","parameters",
         "MultiplyResponse",myServiceDescription.TargetNamespace));
      myServiceDescription.Messages.Add(
         CreateMessage("DivideSoapIn","parameters",
         "Divide",myServiceDescription.TargetNamespace));
      myServiceDescription.Messages.Add(
         CreateMessage("DivideSoapOut","parameters",
         "DivideResponse",myServiceDescription.TargetNamespace));

      // Create a new PortType.
      PortType soapPortType = new PortType();
      soapPortType.Name = "MathServiceSoap";
      soapPortType.Operations.Add(CreateOperation("Add","AddSoapIn",
         "AddSoapOut",myServiceDescription.TargetNamespace));
      soapPortType.Operations.Add(CreateOperation("Subtract","SubtractSoapIn",
         "SubtractSoapOut",myServiceDescription.TargetNamespace));
      soapPortType.Operations.Add(CreateOperation("Multiply","MultiplySoapIn",
         "MultiplySoapOut",myServiceDescription.TargetNamespace));
      soapPortType.Operations.Add(CreateOperation("Divide","DivideSoapIn",
         "DivideSoapOut",myServiceDescription.TargetNamespace));
      myServiceDescription.PortTypes.Add(soapPortType);

      // Create a new Binding for the SOAP protocol.
      Binding myBinding = new Binding();
      myBinding.Name = myServiceDescription.Services[0].Name + "Soap";

      // Pass the name of the existing PortType MathServiceSoap and the 
      // Xml TargetNamespace attribute of the Descriptions tag.
      myBinding.Type = new XmlQualifiedName("MathServiceSoap",
         myServiceDescription.TargetNamespace);

      // Create a SOAP extensibility element.
      SoapBinding mySoapBinding = new SoapBinding();
      mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http";
      mySoapBinding.Style = SoapBindingStyle.Document;

      // Add tag soap:binding as an extensibility element.
      myBinding.Extensions.Add(mySoapBinding);

      // Create OperationBindings for each of the operations defined 
      // in the .asmx file.
      OperationBinding addOperationBinding = CreateOperationBinding(
         "Add",myServiceDescription.TargetNamespace);
      myBinding.Operations.Add(addOperationBinding);
      OperationBinding subtractOperationBinding = CreateOperationBinding(
         "Subtract",myServiceDescription.TargetNamespace);
      myBinding.Operations.Add(subtractOperationBinding);
      OperationBinding multiplyOperationBinding = CreateOperationBinding(
         "Multiply",myServiceDescription.TargetNamespace);
      myBinding.Operations.Add(multiplyOperationBinding);
      OperationBinding divideOperationBinding = CreateOperationBinding(
         "Divide",myServiceDescription.TargetNamespace);
      myBinding.Operations.Add(divideOperationBinding);
      myServiceDescription.Bindings.Insert(0,myBinding);
      Console.WriteLine("\nTarget namespace of the service description to " + 
         "which the binding was added is: " + 
         myServiceDescription.Bindings[0].ServiceDescription.TargetNamespace);

      // Create a Port.
      Port soapPort = new Port();
      soapPort.Name = "MathServiceSoap";
      soapPort.Binding = new XmlQualifiedName(myBinding.Name,
         myServiceDescription.TargetNamespace);

      // Create a SoapAddress extensibility element to add to the port.
      SoapAddressBinding mySoapAddressBinding = new SoapAddressBinding();
      mySoapAddressBinding.Location = "http://localhost/MathService.cs.asmx";
      soapPort.Extensions.Add(mySoapAddressBinding);

      // Add the port to the MathService, which is the first service in 
      // the service collection.
      myServiceDescription.Services[0].Ports.Add(soapPort);

      // Save the ServiceDescripition to an external file.
      myServiceDescription.Write("MathService_new.wsdl");
      Console.WriteLine("\nSuccessfully added bindings for SOAP protocol " +
         "and saved results in the file MathService_new.wsdl");
      Console.WriteLine("\n This file should be passed to the WSDL tool " +
         "as input to generate the proxy");

   }
// <Snippet13>
   // Creates a Message with name = messageName having one MessagePart 
   // with name = partName.
   public static Message CreateMessage(string messageName,string partName,
      string element,string targetNamespace)
   {
// <Snippet4>
// <Snippet5>
      Message myMessage = new Message();
      myMessage.Name = messageName;
// </Snippet5>
// <Snippet6>
// <Snippet10>
// <Snippet11>
// <Snippet12>
      MessagePart myMessagePart = new MessagePart();
      myMessagePart.Name = partName;
      myMessagePart.Element = new XmlQualifiedName(element,targetNamespace);
      myMessage.Parts.Add(myMessagePart);
// </Snippet10>
// </Snippet11>
// </Snippet12>
// </Snippet6>
// </Snippet4>
      return myMessage;
   }
// </Snippet13>
// <Snippet3>
   // Used to create OperationBinding instances within 'Binding'.
   public static OperationBinding CreateOperationBinding(string operation,
      string targetNamespace)
   {
      // Create OperationBinding for operation.
      OperationBinding myOperationBinding = new OperationBinding();
      myOperationBinding.Name = operation;
// <Snippet1>
// <Snippet2>
      // Create InputBinding for operation.
      InputBinding myInputBinding = new InputBinding();
      SoapBodyBinding mySoapBodyBinding = new SoapBodyBinding();
      mySoapBodyBinding.Use = SoapBindingUse.Literal;
      myInputBinding.Extensions.Add(mySoapBodyBinding);
// </Snippet2>
// </Snippet1>
      // Create OutputBinding for operation.
      OutputBinding myOutputBinding = new OutputBinding();
      myOutputBinding.Extensions.Add(mySoapBodyBinding);

      // Add InputBinding and OutputBinding to OperationBinding.
      myOperationBinding.Input = myInputBinding;
      myOperationBinding.Output = myOutputBinding;

      // Create an extensibility element for SoapOperationBinding.
      SoapOperationBinding mySoapOperationBinding = new SoapOperationBinding();
      mySoapOperationBinding.Style = SoapBindingStyle.Document;
      mySoapOperationBinding.SoapAction = targetNamespace + operation;

      // Add the extensibility element SoapOperationBinding to OperationBinding.
      myOperationBinding.Extensions.Add(mySoapOperationBinding);
      return myOperationBinding;
   }
// </Snippet3>
   // Used to create Operations under PortType.
   public static Operation CreateOperation(string operationName,
      string inputMessage,string outputMessage,string targetNamespace)
   {
      Operation myOperation = new Operation();
      myOperation.Name = operationName;
      OperationMessage input = (OperationMessage) new OperationInput();
      input.Message = new XmlQualifiedName(inputMessage,targetNamespace);
      OperationMessage output = (OperationMessage) new OperationOutput();
      output.Message = new XmlQualifiedName(outputMessage,targetNamespace);
      myOperation.Messages.Add(input);
      myOperation.Messages.Add(output);
      return myOperation;
   }
}
