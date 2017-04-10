'* The following example demonstrates the 'Add' method of the 'FaultBindingCollection' class
' * and constructor and 'Extensions' property of 'FaultBinding'class and 'Documentation' 
' * property of 'DocumentableItem' class.
' * 
' * This program generates a WSDL file for a service called StockQuote. The StockQuote service
' * provides one method called 'GetTradePrice'. The 'GetTradePrice' method takes two arguments, 
' * a 'tickerSymbol' and 'time' strings. The 'tickerSymbol' is a unique representation of a 
' * stock and 'time' is the time for which the trading price is to be returned for the stock 
' * specified. The WSDL file generated for the service supports the SOAP protocol only. 
'
Imports System
Imports System.Web.Services.Description
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization


Public Class FaultBindingCollection_Add
   
   
   Public Shared Sub Main()
      Dim myServiceDescription As New ServiceDescription()
      myServiceDescription.Name = "StockQuote"
      myServiceDescription.TargetNamespace = "http://www.contoso.com/stockquote.wsdl"
      
      ' Generate the 'Types' element.	
      Dim myXmlSchema As New XmlSchema()
      myXmlSchema.AttributeFormDefault = XmlSchemaForm.Qualified
      myXmlSchema.ElementFormDefault = XmlSchemaForm.Qualified
      myXmlSchema.TargetNamespace = "http://www.contoso.com/stockquote.wsdl"
      
      'XmlSchemaElement myXmlSchemaElement;
      Dim myXmlSchemaComplexType As New XmlSchemaComplexType()
      myXmlSchemaComplexType.Name = "GetTradePriceInputType"
      Dim myXmlSchemaSequence As New XmlSchemaSequence()
      myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement("1", "1", "tickerSymbol", True, New XmlQualifiedName("s:string")))
      myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement("1", "1", "time", True, New XmlQualifiedName("s:string")))
      myXmlSchemaComplexType.Particle = myXmlSchemaSequence
      myXmlSchema.Items.Add(myXmlSchemaComplexType)
      
      myXmlSchemaComplexType = New XmlSchemaComplexType()
      myXmlSchemaComplexType.Name = "GetTradePriceOutputType"
      myXmlSchemaSequence = New XmlSchemaSequence()
      myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement("1", "1", "result", True, New XmlQualifiedName("s:string")))
      myXmlSchemaComplexType.Particle = myXmlSchemaSequence
      myXmlSchema.Items.Add(myXmlSchemaComplexType)
      
      myXmlSchemaComplexType = New XmlSchemaComplexType()
      myXmlSchemaComplexType.Name = "GetTradePriceStringFaultType"
      myXmlSchemaSequence = New XmlSchemaSequence()
      myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement("1", "1", "error", True, New XmlQualifiedName("s:string")))
      myXmlSchemaComplexType.Particle = myXmlSchemaSequence
      myXmlSchema.Items.Add(myXmlSchemaComplexType)
      
      myXmlSchemaComplexType = New XmlSchemaComplexType()
      myXmlSchemaComplexType.Name = "GetTradePriceStringIntType"
      myXmlSchemaSequence = New XmlSchemaSequence()
      myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement("1", "1", "error", True, New XmlQualifiedName("s:int")))
      myXmlSchemaComplexType.Particle = myXmlSchemaSequence
      myXmlSchema.Items.Add(myXmlSchemaComplexType)
      
      myXmlSchema.Items.Add(CreateOtherXmlElement("GetTradePriceSoapIn", New XmlQualifiedName("s0:GetTradePriceInputType")))
      myXmlSchema.Items.Add(CreateOtherXmlElement("GetTradePriceSoapOut", New XmlQualifiedName("s0:GetTradePriceOutputType")))
      myXmlSchema.Items.Add(CreateOtherXmlElement("GetTradePriceSoapStringFault", New XmlQualifiedName("s0:GetTradePriceStringFaultType")))
      myXmlSchema.Items.Add(CreateOtherXmlElement("GetTradePriceSoapIntFault", New XmlQualifiedName("s0:GetTradePriceIntFaultType")))
      
      myServiceDescription.Types.Schemas.Add(myXmlSchema)
      
      ' Generate the 'Message' element.
      Dim myMessageCollection As MessageCollection = myServiceDescription.Messages
      myMessageCollection.Add(CreateMessage("GetTradePriceInput", "parameters", "GetTradePriceSoapIn", myServiceDescription.TargetNamespace))
      myMessageCollection.Add(CreateMessage("GetTradePriceOutput", "parameters", "GetTradePriceSoapOut", myServiceDescription.TargetNamespace))
      myMessageCollection.Add(CreateMessage("GetTradePriceStringFault", "parameters", "GetTradePriceStringSoapFault", myServiceDescription.TargetNamespace))
      myMessageCollection.Add(CreateMessage("GetTradePriceIntFault", "parameters", "GetTradePriceIntSoapFault", myServiceDescription.TargetNamespace))
      
      ' Generate the 'Port Type' element.
      Dim myPortTypeCollection As PortTypeCollection = myServiceDescription.PortTypes
      Dim myPortType As New PortType()
      myPortType.Name = "StockQuotePortType"
      Dim myOperationCollection As OperationCollection = myPortType.Operations
      Dim myOperation As New Operation()
      myOperation.Name = "GetTradePrice"
      Dim myOperationMessage As OperationMessage
      Dim myOperationMessageCollection As OperationMessageCollection = myOperation.Messages
      myOperationMessage = CType(New OperationInput(), OperationMessage)
      myOperationMessage.Message = New XmlQualifiedName("s0:GetTradePriceInput")
      myOperationMessageCollection.Add(myOperationMessage)
      myOperationMessage = CType(New OperationOutput(), OperationMessage)
      myOperationMessage.Message = New XmlQualifiedName("s0:GetTradePriceOutput")
      myOperationMessageCollection.Add(myOperationMessage)
      Dim myOperationFault As New OperationFault()
      myOperationFault.Name = "ErrorString"
      myOperationFault.Message = New XmlQualifiedName("s0:GetTradePriceStringFault")
      myOperation.Faults.Add(myOperationFault)
      myOperationFault = New OperationFault()
      myOperationFault.Name = "ErrorInt"
      myOperationFault.Message = New XmlQualifiedName("s0:GetTradePriceIntFault")
      myOperation.Faults.Add(myOperationFault)
      myOperationCollection.Add(myOperation)
      myPortTypeCollection.Add(myPortType)
      
      ' Generate the 'Binding' element.
      Dim myExtensions As ServiceDescriptionFormatExtensionCollection
      Dim myBindingCollection As BindingCollection = myServiceDescription.Bindings
      Dim myBinding As New Binding()
      myBinding.Name = "StockQuoteSoapBinding"
      myBinding.Type = New XmlQualifiedName("s0:StockQuotePortType")
      myExtensions = myBinding.Extensions
      Dim mySoapBinding As New SoapBinding()
      mySoapBinding.Style = SoapBindingStyle.Document
      mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http"
      myExtensions.Add(mySoapBinding)
      Dim myOperationBindingCollection As OperationBindingCollection = myBinding.Operations
      Dim myOperationBinding As New OperationBinding()
      myExtensions = myOperationBinding.Extensions
      Dim mySoapBindingOperation As New SoapOperationBinding()
      mySoapBindingOperation.SoapAction = "http://www.contoso.com/GetTradePrice"
      myExtensions.Add(mySoapBindingOperation)
      myOperationBinding.Name = "GetTradePrice"
      myOperationBinding.Input = New InputBinding()
      myExtensions = myOperationBinding.Input.Extensions
      Dim mySoapBodyBinding As New SoapBodyBinding()
      mySoapBodyBinding.Use = SoapBindingUse.Literal
      mySoapBodyBinding.Namespace = "http://www.contoso.com/stockquote"
      myExtensions.Add(mySoapBodyBinding)
      myOperationBinding.Output = New OutputBinding()
      myExtensions = myOperationBinding.Output.Extensions
      mySoapBodyBinding = New SoapBodyBinding()
      mySoapBodyBinding.Use = SoapBindingUse.Literal
      mySoapBodyBinding.Namespace = "http://www.contoso.com/stockquote"
      myExtensions.Add(mySoapBodyBinding)
      ' <Snippet1>
      ' <Snippet2>
      ' <Snippet3>
      Dim myFaultBindingCollection As FaultBindingCollection = myOperationBinding.Faults
      Dim myFaultBinding As New FaultBinding()
      myFaultBinding.Name = "ErrorString"
      ' Associate SOAP fault binding to the fault binding of the operation.
      myExtensions = myFaultBinding.Extensions
      Dim mySoapFaultBinding As New SoapFaultBinding()
      mySoapFaultBinding.Use = SoapBindingUse.Literal
      mySoapFaultBinding.Namespace = "http://www.contoso.com/stockquote"
      myExtensions.Add(mySoapFaultBinding)
      myFaultBindingCollection.Add(myFaultBinding)
      ' </Snippet3>
      ' </Snippet2>
      ' </Snippet1>
      myFaultBinding = New FaultBinding()
      myFaultBinding.Name = "ErrorInt"
      ' Associate SOAP fault binding to the fault binding of the operation.
      myExtensions = myFaultBinding.Extensions
      mySoapFaultBinding = New SoapFaultBinding()
      mySoapFaultBinding.Use = SoapBindingUse.Literal
      mySoapFaultBinding.Namespace = "http://www.contoso.com/stockquote"
      myExtensions.Add(mySoapFaultBinding)
      myFaultBindingCollection.Add(myFaultBinding)
      myOperationBindingCollection.Add(myOperationBinding)
      myBindingCollection.Add(myBinding)
      
      ' Generate the 'Service' element.
      Dim myServiceCollection As ServiceCollection = myServiceDescription.Services
      ' <Snippet4>
      Dim myService As New Service()
      ' Add a simple documentation for the service to ease the readability of the generated WSDL file.
      myService.Documentation = "A Simple Stock Quote Service"
      myService.Name = "StockQuoteService"
      Dim myPortCollection As PortCollection = myService.Ports
      Dim myPort As New Port()
      myPort.Name = "StockQuotePort"
      myPort.Binding = New XmlQualifiedName("s0:StockQuoteSoapBinding")
      myExtensions = myPort.Extensions
      Dim mySoapAddressBinding As New SoapAddressBinding()
      mySoapAddressBinding.Location = "http://www.contoso.com/stockquote"
      myExtensions.Add(mySoapAddressBinding)
      myPortCollection.Add(myPort)
      ' </Snippet4>
      myServiceCollection.Add(myService)
      
      ' Display the WSDL generated to the console.
      myServiceDescription.Write(Console.Out)
   End Sub 'Main
   
   
   Public Shared Function CreateComplexTypeXmlElement(minoccurs As String, maxoccurs As String, name As String, isNillable As Boolean, schemaTypeName As XmlQualifiedName) As XmlSchemaElement
      Dim myXmlSchemaElement As New XmlSchemaElement()
      myXmlSchemaElement.MinOccursString = minoccurs
      myXmlSchemaElement.MaxOccursString = maxoccurs
      myXmlSchemaElement.Name = name
      myXmlSchemaElement.IsNillable = True
      myXmlSchemaElement.SchemaTypeName = schemaTypeName
      Return myXmlSchemaElement
   End Function 'CreateComplexTypeXmlElement
   
   Public Shared Function CreateOtherXmlElement(name As String, SchemaTypeName As XmlQualifiedName) As XmlSchemaElement
      Dim myXmlSchemaElement As New XmlSchemaElement()
      myXmlSchemaElement.Name = name
      myXmlSchemaElement.SchemaTypeName = SchemaTypeName
      Return myXmlSchemaElement
   End Function 'CreateOtherXmlElement
   
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
End Class 'FaultBindingCollection_Add