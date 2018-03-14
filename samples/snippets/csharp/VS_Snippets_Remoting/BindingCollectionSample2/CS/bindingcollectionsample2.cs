// System.Web.Services.Description.Binding.Binding();System.Web.Services.Description.Binding.Name;
// System.Web.Services.Description.Binding.Type;System.Web.Services.Description.Binding.Extensions;System.Web.Services.Description.Binding.Operations;
// System.Web.Services.Description.BindingCollection.Insert;
// System.Web.Services.Description.Binding.ServiceDescription;

// Grouping Clause : Snippet5 and Snippet8 go together.

/* The following example demonstrates the constructor 'Binding()' and properties 'Extensions','Name','Operations',
  'ServiceDescription' and 'Type' property of 'Binding' class AND method 'Insert' of 'BindingCollection' class.
  The input to the program is a WSDL file 'MathService_input.wsdl' with all information related to SOAP protocol 
  removed from it.In a way it tries to simulate a scenario wherein a service initially did not support a protocol, however later 
  on happen to support it. 
  IN this example the WSDL file is modified to insert a new Binding for SOAP. The binding is populated based on
  WSDL document structure defined in WSDL specification. The ServiceDescription instance is loaded with values
  for 'Messages', 'PortTypes','Bindings' and 'Port'.The instance is then written to an external file 'MathService_new.wsdl'.
  
 * */
using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

class MyClass
{
   public static void Main()
   {
      ServiceDescription myServiceDescription = ServiceDescription.Read("MathService_input.wsdl");
      // Create SOAP Messages.
      myServiceDescription.Messages.Add(CreateMessage("AddSoapIn","parameters","Add",myServiceDescription.TargetNamespace));
      myServiceDescription.Messages.Add(CreateMessage("AddSoapOut","parameters","AddResponse",myServiceDescription.TargetNamespace));            
      myServiceDescription.Messages.Add(CreateMessage("SubtractSoapIn","parameters","Subtract",myServiceDescription.TargetNamespace));
      myServiceDescription.Messages.Add(CreateMessage("SubtractSoapOut","parameters","SubtractResponse",myServiceDescription.TargetNamespace));
      myServiceDescription.Messages.Add(CreateMessage("MultiplySoapIn","parameters","Multiply",myServiceDescription.TargetNamespace));
      myServiceDescription.Messages.Add(CreateMessage("MultiplySoapOut","parameters","MultiplyResponse",myServiceDescription.TargetNamespace));
      myServiceDescription.Messages.Add(CreateMessage("DivideSoapIn","parameters","Divide",myServiceDescription.TargetNamespace));
      myServiceDescription.Messages.Add(CreateMessage("DivideSoapOut","parameters","DivideResponse",myServiceDescription.TargetNamespace));
      
      // Create a new PortType.
      PortType soapPortType = new PortType();
      soapPortType.Name = "MathServiceSoap";
      soapPortType.Operations.Add(CreateOperation("Add","AddSoapIn","AddSoapOut",myServiceDescription.TargetNamespace));
      soapPortType.Operations.Add(CreateOperation("Subtract","SubtractSoapIn","SubtractSoapOut",myServiceDescription.TargetNamespace));
      soapPortType.Operations.Add(CreateOperation("Multiply","MultiplySoapIn","MultiplySoapOut",myServiceDescription.TargetNamespace));
      soapPortType.Operations.Add(CreateOperation("Divide","DivideSoapIn","DivideSoapOut",myServiceDescription.TargetNamespace));
      myServiceDescription.PortTypes.Add(soapPortType);
// <Snippet2>
// <Snippet1>
// <Snippet6>
      // Create a new Binding for SOAP Protocol.
      Binding myBinding = new Binding();
      myBinding.Name = myServiceDescription.Services[0].Name + "Soap";
// </Snippet2>
// <Snippet3>
      // Pass the name of the existing porttype 'MathServiceSoap' and the Xml targetNamespace attribute of the Descriptions tag.
      myBinding.Type = new XmlQualifiedName("MathServiceSoap",myServiceDescription.TargetNamespace);
// </Snippet3>
// <Snippet4>
      // Create SOAP Extensibility element.
      SoapBinding mySoapBinding = new SoapBinding();
      // SOAP over HTTP.
      mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http";
      mySoapBinding.Style = SoapBindingStyle.Document;
      // Add tag soap:binding as an extensibility element.
      myBinding.Extensions.Add(mySoapBinding);
// </Snippet4>
// <Snippet5>
      // Create OperationBindings for each of the operations defined in asmx file.
      OperationBinding addOperationBinding = CreateOperationBinding("Add",myServiceDescription.TargetNamespace);
      myBinding.Operations.Add(addOperationBinding);
      OperationBinding subtractOperationBinding = CreateOperationBinding("Subtract",myServiceDescription.TargetNamespace);
      myBinding.Operations.Add(subtractOperationBinding);
      OperationBinding multiplyOperationBinding = CreateOperationBinding("Multiply",myServiceDescription.TargetNamespace);
      myBinding.Operations.Add(multiplyOperationBinding);
      OperationBinding divideOperationBinding = CreateOperationBinding("Divide",myServiceDescription.TargetNamespace);
      myBinding.Operations.Add(divideOperationBinding);
// </Snippet5>
      myServiceDescription.Bindings.Insert(0,myBinding);
// </Snippet1>
// </Snippet6>
// <Snippet7>
      Console.WriteLine("\nTarget Namespace of the Service Description to which the binding was added is:" + myServiceDescription.Bindings[0].ServiceDescription.TargetNamespace);
// </Snippet7>
      // Create Port.
      Port soapPort = new Port();
      soapPort.Name = "MathServiceSoap";
      soapPort.Binding = new XmlQualifiedName(myBinding.Name,myServiceDescription.TargetNamespace);
      // Create SoapAddress extensibility element to add to port.
      SoapAddressBinding mySoapAddressBinding = new SoapAddressBinding();
      mySoapAddressBinding.Location = "http://localhost/BindingCollectionSample/MathService.asmx";
      soapPort.Extensions.Add(mySoapAddressBinding);
      // Add port to the MathService which is the first service in the Service Collection.
      myServiceDescription.Services[0].Ports.Add(soapPort);
      // Save the ServiceDescripition instance to an external file.
      myServiceDescription.Write("MathService_new.wsdl");
      Console.WriteLine("\nSuccessfully added bindings for SOAP protocol and saved results in file MathService_new.wsdl");
      Console.WriteLine("\n This file should be passed to wsdl tool as input to generate proxy");
      
   }
   // Creates a Message with name ="messageName" having one MessagePart with name = "partName".
   public static Message CreateMessage(string messageName,string partName,string element,string targetNamespace)
   {
      Message myMessage = new Message();
      myMessage.Name = messageName;
      MessagePart myMessagePart = new MessagePart();
      myMessagePart.Name = partName;
      myMessagePart.Element = new XmlQualifiedName(element,targetNamespace);
      myMessage.Parts.Add(myMessagePart);
      return myMessage;
   }
// <Snippet8>   
   // Used to create OperationBinding instances within 'Binding'.
   public static OperationBinding CreateOperationBinding(string operation,string targetNamespace)
   {
      // Create OperationBinding instance for operation.
      OperationBinding myOperationBinding = new OperationBinding();
      myOperationBinding.Name = operation;
      // Create InputBinding for operation.
      InputBinding myInputBinding = new InputBinding();
      SoapBodyBinding mySoapBodyBinding = new SoapBodyBinding();
      mySoapBodyBinding.Use = SoapBindingUse.Literal;
      myInputBinding.Extensions.Add(mySoapBodyBinding);
      // Create OutputBinding for operation.
      OutputBinding myOutputBinding = new OutputBinding();
      myOutputBinding.Extensions.Add(mySoapBodyBinding);
      // Add 'InputBinding' and 'OutputBinding' to 'OperationBinding'. 
      myOperationBinding.Input = myInputBinding;
      myOperationBinding.Output = myOutputBinding;
      // Create extensibility element for 'SoapOperationBinding'.
      SoapOperationBinding mySoapOperationBinding = new SoapOperationBinding();
      mySoapOperationBinding.Style = SoapBindingStyle.Document;
      mySoapOperationBinding.SoapAction = targetNamespace + operation;
      // Add extensibility element 'SoapOperationBinding' to 'OperationBinding'.
      myOperationBinding.Extensions.Add(mySoapOperationBinding);
      return myOperationBinding;
   }
// </Snippet8>
   // Used to create Operations under PortType.
   public static Operation CreateOperation(string operationName,string inputMessage,string outputMessage,string targetNamespace)
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