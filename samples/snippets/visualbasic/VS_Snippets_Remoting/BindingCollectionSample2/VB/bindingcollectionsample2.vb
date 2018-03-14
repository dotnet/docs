' System.Web.Services.Description.Binding.Binding();System.Web.Services.Description.Binding.Name;
' System.Web.Services.Description.Binding.Type;System.Web.Services.Description.Binding.Extensions;System.Web.Services.Description.Binding.Operations;
' System.Web.Services.Description.BindingCollection.Insert;
' System.Web.Services.Description.Binding.ServiceDescription;
' System.Web.Services.Description.HttpBinding.NameSpace;

' Grouping Clause : Snippet5 and Snippet8 go together.

' The following example demonstrates the constructor 'Binding()' and properties 'Extensions','Name','Operations',
'  'ServiceDescription' and 'Type' property of 'Binding' class AND method 'Insert' of 'BindingCollection' class.
'  The input to the program is a WSDL file 'MathService_input.wsdl' with all information related to SOAP protocol 
'  removed from it.In a way it tries to simulate a scenario wherein a service initially did not support a protocol, however later 
'  on happen to support it. 
'  IN this example the WSDL file is modified to insert a new Binding for SOAP. The binding is populated based on
'  WSDL document structure defined in WSDL specification. The ServiceDescription instance is loaded with values
'  for 'Messages', 'PortTypes','Bindings' and 'Port'.The instance is then written to an external file 'MathService_new.wsdl'.
  
  
Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml
Imports Microsoft.VisualBasic


Class [MyClass]
   
   Public Shared Sub Main()
      Dim myServiceDescription As ServiceDescription = ServiceDescription.Read("MathService_input.wsdl")
      ' Create SOAP Messages.
      myServiceDescription.Messages.Add(CreateMessage("AddSoapIn", "parameters", "Add", myServiceDescription.TargetNamespace))
      myServiceDescription.Messages.Add(CreateMessage("AddSoapOut", "parameters", "AddResponse", myServiceDescription.TargetNamespace))
      myServiceDescription.Messages.Add(CreateMessage("SubtractSoapIn", "parameters", "Subtract", myServiceDescription.TargetNamespace))
      myServiceDescription.Messages.Add(CreateMessage("SubtractSoapOut", "parameters", "SubtractResponse", myServiceDescription.TargetNamespace))
      myServiceDescription.Messages.Add(CreateMessage("MultiplySoapIn", "parameters", "Multiply", myServiceDescription.TargetNamespace))
      myServiceDescription.Messages.Add(CreateMessage("MultiplySoapOut", "parameters", "MultiplyResponse", myServiceDescription.TargetNamespace))
      myServiceDescription.Messages.Add(CreateMessage("DivideSoapIn", "parameters", "Divide", myServiceDescription.TargetNamespace))
      myServiceDescription.Messages.Add(CreateMessage("DivideSoapOut", "parameters", "DivideResponse", myServiceDescription.TargetNamespace))
      
      ' Create a new PortType.
      Dim soapPortType As New PortType()
      soapPortType.Name = "MathServiceSoap"
      soapPortType.Operations.Add(CreateOperation("Add", "AddSoapIn", "AddSoapOut", myServiceDescription.TargetNamespace))
      soapPortType.Operations.Add(CreateOperation("Subtract", "SubtractSoapIn", "SubtractSoapOut", myServiceDescription.TargetNamespace))
      soapPortType.Operations.Add(CreateOperation("Multiply", "MultiplySoapIn", "MultiplySoapOut", myServiceDescription.TargetNamespace))
      soapPortType.Operations.Add(CreateOperation("Divide", "DivideSoapIn", "DivideSoapOut", myServiceDescription.TargetNamespace))
      myServiceDescription.PortTypes.Add(soapPortType)
      ' <Snippet2>
      ' <Snippet1>
      ' <Snippet6>
      ' Create a new Binding for SOAP Protocol.
      Dim myBinding As New Binding()
      myBinding.Name = myServiceDescription.Services(0).Name + "Soap"
      ' </Snippet2>
      ' <Snippet3>
      ' Pass the name of the existing porttype 'MathServiceSoap' and the Xml targetNamespace attribute of the Descriptions tag.
      myBinding.Type = New XmlQualifiedName("MathServiceSoap", myServiceDescription.TargetNamespace)
      ' </Snippet3>
      ' <Snippet4>
      ' Create SOAP Extensibility element.
      Dim mySoapBinding As New SoapBinding()
      ' SOAP over Http.

      mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http"
      mySoapBinding.Style = SoapBindingStyle.Document
      ' Add tag soap:binding as an extensibility element.
      myBinding.Extensions.Add(mySoapBinding)
      ' </Snippet4>
     ' <Snippet5>
      ' Create OperationBindings for each of the operations defined in asmx file.
      Dim addOperationBinding As OperationBinding = CreateOperationBinding("Add", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(addOperationBinding)
      Dim subtractOperationBinding As OperationBinding = CreateOperationBinding("Subtract", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(subtractOperationBinding)
      Dim multiplyOperationBinding As OperationBinding = CreateOperationBinding("Multiply", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(multiplyOperationBinding)
      Dim divideOperationBinding As OperationBinding = CreateOperationBinding("Divide", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(divideOperationBinding)
      ' </Snippet5>
      myServiceDescription.Bindings.Insert(0, myBinding)
      ' </Snippet1>
      ' </Snippet6>
      ' <Snippet7>
      Console.WriteLine((ControlChars.Cr + "Target Namespace of the Service Description to which the binding was added is:" + myServiceDescription.Bindings(0).ServiceDescription.TargetNamespace))
      ' </Snippet7>
      ' Create Port.
      Dim soapPort As New Port()
      soapPort.Name = "MathServiceSoap"
      soapPort.Binding = New XmlQualifiedName(myBinding.Name, myServiceDescription.TargetNamespace)
      ' Create SoapAddress extensibility element to add to port.
      Dim mySoapAddressBinding As New SoapAddressBinding()
      mySoapAddressBinding.Location = "http://localhost/BindingCollectionSample/MathService.asmx"
      soapPort.Extensions.Add(mySoapAddressBinding)
      ' Add port to the MathService which is the first service in the Service Collection.
      myServiceDescription.Services(0).Ports.Add(soapPort)
      ' Save the ServiceDescripition instance to an external file.
      myServiceDescription.Write("MathService_new.wsdl")
      Console.WriteLine(ControlChars.Cr + "Successfully added bindings for SOAP protocol and saved results in file MathService_new.wsdl")
      Console.WriteLine(ControlChars.Cr + " This file should be passed to wsdl tool as input to generate proxy")
   End Sub 'Main
    
   ' Creates a Message with name ="messageName" having one MessagePart with name = "partName".
   Public Shared Function CreateMessage(messageName As String, partName As String, element As String, targetNamespace As String) As Message
      Dim myMessage As New Message()
      myMessage.Name = messageName
      Dim myMessagePart As New MessagePart()
      myMessagePart.Name = partName
      myMessagePart.Element = New XmlQualifiedName(element, targetNamespace)
      myMessage.Parts.Add(myMessagePart)
      Return myMessage
   End Function 'CreateMessage
   
   ' <Snippet8>   
   ' Used to create OperationBinding instances within 'Binding'.
   Public Shared Function CreateOperationBinding(operation As String, targetNamespace As String) As OperationBinding
      ' Create OperationBinding instance for operation.
      Dim myOperationBinding As New OperationBinding()
      myOperationBinding.Name = operation
      ' Create InputBinding for operation.
      Dim myInputBinding As New InputBinding()
      Dim mySoapBodyBinding As New SoapBodyBinding()
      mySoapBodyBinding.Use = SoapBindingUse.Literal
      myInputBinding.Extensions.Add(mySoapBodyBinding)
      ' Create OutputBinding for operation.
      Dim myOutputBinding As New OutputBinding()
      myOutputBinding.Extensions.Add(mySoapBodyBinding)
      ' Add 'InputBinding' and 'OutputBinding' to 'OperationBinding'. 
      myOperationBinding.Input = myInputBinding
      myOperationBinding.Output = myOutputBinding
      ' Create extensibility element for 'SoapOperationBinding'.
      Dim mySoapOperationBinding As New SoapOperationBinding()
      mySoapOperationBinding.Style = SoapBindingStyle.Document
      mySoapOperationBinding.SoapAction = targetNamespace + operation
      ' Add extensibility element 'SoapOperationBinding' to 'OperationBinding'.
      myOperationBinding.Extensions.Add(mySoapOperationBinding)
      Return myOperationBinding
   End Function 'CreateOperationBinding
   
   ' </Snippet8>
   ' Used to create Operations under PortType.
   Public Shared Function CreateOperation(operationName As String, inputMessage As String, outputMessage As String, targetNamespace As String) As Operation
      Dim myOperation As New Operation()
      myOperation.Name = operationName
      Dim input As OperationMessage = CType(New OperationInput(), OperationMessage)
      input.Message = New XmlQualifiedName(inputMessage, targetNamespace)
      Dim output As OperationMessage = CType(New OperationOutput(), OperationMessage)
      output.Message = New XmlQualifiedName(outputMessage, targetNamespace)
      myOperation.Messages.Add(input)
      myOperation.Messages.Add(output)
      Return myOperation
   End Function 'CreateOperation
End Class '[MyClass]