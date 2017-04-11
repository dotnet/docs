' System.Web.Services.Description.InputBinding.InputBinding();
' System.Web.Services.Description.InputBinding.Extensions
' System.Web.Services.Description.InputBinding
' System.Web.Services.Description.Message.Message();
' System.Web.Services.Description.Message.Name;
' System.Web.Services.Description.Message.Parts;
' System.Web.Services.Description.MessageCollection.Add;
' System.Web.Services.Description.MessageCollection.Insert;
' System.Web.Services.Description.MessageCollection;
' System.Web.Services.Description.MessagePart.MessagePart();
' System.Web.Services.Description.MessagePart.Element;
' System.Web.Services.Description.MessagePart.Name;
' System.Web.Services.Description.MessagePart;
' System.Web.Services.Description.MessagePartCollection.Add;
' System.Web.Services.Description.MessagePartCollection.Insert;

' The following program takes input a WSDL file 'MathService_input.wsdl' with all information related to 
' SOAP protocol removed from it.In a way it tries to simulate a scenario wherein a service 
' initially did not support a protocol, however later on happen to support it. 

' IN this example the WSDL file is modified to insert a new Binding for SOAP. The binding is 
' populated based on WSDL document structure defined in WSDL specification. The ServiceDescription
' instance is loaded with values for 'Messages', 'PortTypes','Bindings' and 'Port'.The instance is 
' then written to an external file 'MathService_new.wsdl'.

Imports System
Imports System.Web.Services.Description
Imports System.Collections
Imports System.Xml
Imports Microsoft.VisualBasic

Class MyClass1
   
   Public Shared Sub Main()
' <Snippet9>
      Dim myServiceDescription As ServiceDescription = _
         ServiceDescription.Read ("MathService_input_vb.wsdl")

      ' Create SOAP messages.
' <Snippet7>
      Dim myMessage As New Message()
      myMessage.Name = "AddSoapOut"
' <Snippet14>
      Dim myMessagePart As New MessagePart()
      myMessagePart.Name = "parameters"
      myMessagePart.Element = New XmlQualifiedName("AddResponse", _
         myServiceDescription.TargetNamespace)
      myMessage.Parts.Add(myMessagePart)
' </Snippet14>
      myServiceDescription.Messages.Add(myMessage)
' </Snippet9>
' </Snippet7>
' <Snippet8>
      Dim myMessage1 As New Message()
      myMessage1.Name = "AddSoapIn"
' <Snippet15>     
      Dim myMessagePart1 As New MessagePart()
      myMessagePart1.Name = "parameters"
      myMessagePart1.Element = New XmlQualifiedName("Add", _
         myServiceDescription.TargetNamespace)
      myMessage1.Parts.Insert(0, myMessagePart1)
' </Snippet15>
      myServiceDescription.Messages.Insert(16, myMessage1)
' </Snippet8>
      myServiceDescription.Messages.Add(CreateMessage("SubtractSoapIn", _
         "parameters", "Subtract", myServiceDescription.TargetNamespace))
      myServiceDescription.Messages.Add(CreateMessage("SubtractSoapOut", _
         "parameters", "SubtractResponse", _
         myServiceDescription.TargetNamespace))
      myServiceDescription.Messages.Add(CreateMessage("MultiplySoapIn", _
         "parameters", "Multiply", myServiceDescription.TargetNamespace))
      myServiceDescription.Messages.Add(CreateMessage("MultiplySoapOut", _
         "parameters", "MultiplyResponse", _
         myServiceDescription.TargetNamespace))
      myServiceDescription.Messages.Add(CreateMessage("DivideSoapIn", _
         "parameters", "Divide", myServiceDescription.TargetNamespace))
      myServiceDescription.Messages.Add(CreateMessage("DivideSoapOut", _
         "parameters", "DivideResponse", _
         myServiceDescription.TargetNamespace))
      
      ' Create a new PortType.
      Dim soapPortType As New PortType()
      soapPortType.Name = "MathServiceSoap"
      soapPortType.Operations.Add(CreateOperation("Add", "AddSoapIn", _
         "AddSoapOut",  myServiceDescription.TargetNamespace))
      soapPortType.Operations.Add(CreateOperation("Subtract", "SubtractSoapIn", _
         "SubtractSoapOut", myServiceDescription.TargetNamespace))
      soapPortType.Operations.Add(CreateOperation("Multiply", "MultiplySoapIn", _
         "MultiplySoapOut", myServiceDescription.TargetNamespace))
      soapPortType.Operations.Add(CreateOperation("Divide", "DivideSoapIn", _
         "DivideSoapOut", myServiceDescription.TargetNamespace))
      myServiceDescription.PortTypes.Add(soapPortType)

      ' Create a new Binding for SOAP protocol.
      Dim myBinding As New Binding()
      myBinding.Name = myServiceDescription.Services(0).Name & "Soap"

      ' Pass the name of the existing PortType MathServiceSoap and the 
      ' Xml targetNamespace attribute of the Descriptions tag.
      myBinding.Type = New XmlQualifiedName("MathServiceSoap", _
         myServiceDescription.TargetNamespace)

      ' Create a SOAP extensibility element.
      Dim mySoapBinding As New SoapBinding()
      mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http"
      mySoapBinding.Style = SoapBindingStyle.Document

      ' Add tag soap:binding as an extensibility element.
      myBinding.Extensions.Add(mySoapBinding)
      ' Create OperationBindings for each of the operations defined 
      ' in the .asmx file.
      Dim addOperationBinding As OperationBinding = CreateOperationBinding( _
         "Add", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(addOperationBinding)
      Dim subtractOperationBinding As OperationBinding = CreateOperationBinding( _
         "Subtract", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(subtractOperationBinding)
      Dim multiplyOperationBinding As OperationBinding = CreateOperationBinding( _
         "Multiply", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(multiplyOperationBinding)
      Dim divideOperationBinding As OperationBinding = CreateOperationBinding( _
         "Divide", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(divideOperationBinding)
      myServiceDescription.Bindings.Insert(0, myBinding)

      Console.WriteLine(ControlChars.NewLine & "Target namespace of the " _
         & "service description to which the binding was added is: " & _
         myServiceDescription.Bindings(0).ServiceDescription.TargetNamespace)

      ' Create a Port.
      Dim soapPort As New Port()
      soapPort.Name = "MathServiceSoap"
      soapPort.Binding = New XmlQualifiedName(myBinding.Name, _
         myServiceDescription.TargetNamespace)

      ' Create a SoapAddress extensibility element to add to the port.
      Dim mySoapAddressBinding As New SoapAddressBinding()
      mySoapAddressBinding.Location = "http://localhost/MathService.vb.asmx"
      soapPort.Extensions.Add(mySoapAddressBinding)

      ' Add the port to the MathService, which is the first service in 
      ' the service collection.
      myServiceDescription.Services(0).Ports.Add(soapPort)

      ' Save the ServiceDescripition to an external file.
      myServiceDescription.Write("MathService_new.wsdl")
        Console.WriteLine(ControlChars.NewLine & "Successfully added bindings " _
           & "for SOAP protocol and saved results in the file " _
           & "MathService_new.wsdl")
      Console.WriteLine(ControlChars.NewLine & " This file should be passed " _
         & "to the WSDL tool as input to generate the proxy")
   End Sub 'Main
    
' <Snippet13>
   ' Creates a Message with name = messageName having one MessagePart 
   ' with name = partName.
   Public Shared Function CreateMessage(messageName As String, _
      partName As String, element As String, targetNamespace As String) _
      As Message
' <Snippet4>
' <Snippet5>      
      Dim myMessage As New Message()
      myMessage.Name = messageName
' </Snippet5>
' <Snippet6>
' <Snippet10>
' <Snippet11>
' <Snippet12>
      Dim myMessagePart As New MessagePart()
      myMessagePart.Name = partName
      myMessagePart.Element = New XmlQualifiedName(element, targetNamespace)
      myMessage.Parts.Add(myMessagePart)
' </Snippet10>
' </Snippet11>
' </Snippet12>
' </Snippet6>
' </Snippet4>
      Return myMessage
   End Function 'CreateMessage
   
' </Snippet13>
' <Snippet3>
   ' Used to create OperationBinding instances within 'Binding'.
   Public Shared Function CreateOperationBinding(operation As String, _
      targetNamespace As String) As OperationBinding

      ' Create OperationBinding for operation.
      Dim myOperationBinding As New OperationBinding()
      myOperationBinding.Name = operation

' <Snippet1>
' <Snippet2>      
      ' Create InputBinding for operation.
      Dim myInputBinding As New InputBinding()
      Dim mySoapBodyBinding As New SoapBodyBinding()
      mySoapBodyBinding.Use = SoapBindingUse.Literal
      myInputBinding.Extensions.Add(mySoapBodyBinding)
' </Snippet2>
' </Snippet1>
      ' Create OutputBinding for operation.
      Dim myOutputBinding As New OutputBinding()
      myOutputBinding.Extensions.Add(mySoapBodyBinding)

      ' Add InputBinding and OutputBinding to OperationBinding. 
      myOperationBinding.Input = myInputBinding
      myOperationBinding.Output = myOutputBinding

      ' Create an extensibility element for SoapOperationBinding.
      Dim mySoapOperationBinding As New SoapOperationBinding()
      mySoapOperationBinding.Style = SoapBindingStyle.Document
      mySoapOperationBinding.SoapAction = targetNamespace & operation

      ' Add the extensibility element SoapOperationBinding to OperationBinding.
      myOperationBinding.Extensions.Add(mySoapOperationBinding)
      Return myOperationBinding
   End Function 'CreateOperationBinding
   
' </Snippet3>
   ' Used to create Operations under PortType.
   Public Shared Function CreateOperation(operationName As String, _ 
      inputMessage As String, outputMessage As String, targetNamespace _
      As String) As Operation
      Dim myOperation As New Operation()
      myOperation.Name = operationName
      Dim input As OperationMessage = _
         CType(New OperationInput(), OperationMessage)
      input.Message = New XmlQualifiedName(inputMessage, targetNamespace)
      Dim output As OperationMessage = _
         CType(New OperationOutput(), OperationMessage)
      output.Message = New XmlQualifiedName(outputMessage, targetNamespace)
      myOperation.Messages.Add(input)
      myOperation.Messages.Add(output)
      Return myOperation
   End Function 'CreateOperation
End Class 'MyClass1
