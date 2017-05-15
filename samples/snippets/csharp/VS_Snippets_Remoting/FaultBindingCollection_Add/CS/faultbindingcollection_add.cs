/* The following example demonstrates the 'Add' method of the 'FaultBindingCollection' class
 * and constructor and 'Extensions' property of 'FaultBinding'class and 'Documentation' 
 * property of 'DocumentableItem' class.
 * 
 * This program generates a WSDL file for a service called StockQuote. The StockQuote service
 * provides one method called 'GetTradePrice'. The 'GetTradePrice' method takes two arguments, 
 * a 'tickerSymbol' and 'time' strings. The 'tickerSymbol' is a unique representation of a 
 * stock and 'time' is the time for which the trading price is to be returned for the stock 
 * specified. The WSDL file generated for the service supports the SOAP protocol only. 
 */

using System;
using System.Web.Services.Description;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

public class FaultBindingCollection_Add
{
     
   public static void Main()
   {
      ServiceDescription myServiceDescription = new ServiceDescription();
      myServiceDescription.Name = "StockQuote";
      myServiceDescription.TargetNamespace = "http://www.contoso.com/stockquote.wsdl";
    
      // Generate the 'Types' element. 
      XmlSchema myXmlSchema = new XmlSchema();
      myXmlSchema.AttributeFormDefault = XmlSchemaForm.Qualified;
      myXmlSchema.ElementFormDefault = XmlSchemaForm.Qualified;
      myXmlSchema.TargetNamespace = "http://www.contoso.com/stockquote.wsdl";
      
      //XmlSchemaElement myXmlSchemaElement;
      XmlSchemaComplexType myXmlSchemaComplexType = new XmlSchemaComplexType();
      myXmlSchemaComplexType.Name = "GetTradePriceInputType";
      XmlSchemaSequence myXmlSchemaSequence = new XmlSchemaSequence();
      myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement("1","1","tickerSymbol",true,new XmlQualifiedName("s:string")));
      myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement("1","1","time",true,new XmlQualifiedName("s:string")));
      myXmlSchemaComplexType.Particle = myXmlSchemaSequence;      
      myXmlSchema.Items.Add(myXmlSchemaComplexType);

      myXmlSchemaComplexType = new XmlSchemaComplexType();
      myXmlSchemaComplexType.Name = "GetTradePriceOutputType";
      myXmlSchemaSequence = new XmlSchemaSequence();
      myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement("1","1","result",true,new XmlQualifiedName("s:string")));
      myXmlSchemaComplexType.Particle = myXmlSchemaSequence;
      myXmlSchema.Items.Add(myXmlSchemaComplexType);

      myXmlSchemaComplexType = new XmlSchemaComplexType();
      myXmlSchemaComplexType.Name = "GetTradePriceStringFaultType";
      myXmlSchemaSequence = new XmlSchemaSequence();
      myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement("1","1","error",true,new XmlQualifiedName("s:string")));
      myXmlSchemaComplexType.Particle = myXmlSchemaSequence;
      myXmlSchema.Items.Add(myXmlSchemaComplexType);

      myXmlSchemaComplexType = new XmlSchemaComplexType();
      myXmlSchemaComplexType.Name = "GetTradePriceStringIntType";
      myXmlSchemaSequence = new XmlSchemaSequence();
      myXmlSchemaSequence.Items.Add(CreateComplexTypeXmlElement("1","1","error",true,new XmlQualifiedName("s:int")));
      myXmlSchemaComplexType.Particle = myXmlSchemaSequence;
      myXmlSchema.Items.Add(myXmlSchemaComplexType);

      myXmlSchema.Items.Add(CreateOtherXmlElement("GetTradePriceSoapIn",new XmlQualifiedName("s0:GetTradePriceInputType")));
      myXmlSchema.Items.Add(CreateOtherXmlElement("GetTradePriceSoapOut",new XmlQualifiedName("s0:GetTradePriceOutputType")));
      myXmlSchema.Items.Add(CreateOtherXmlElement("GetTradePriceSoapStringFault",new XmlQualifiedName("s0:GetTradePriceStringFaultType")));
      myXmlSchema.Items.Add(CreateOtherXmlElement("GetTradePriceSoapIntFault",new XmlQualifiedName("s0:GetTradePriceIntFaultType")));

      myServiceDescription.Types.Schemas.Add(myXmlSchema);

      // Generate the 'Message' element.
      MessageCollection myMessageCollection = myServiceDescription.Messages;
      myMessageCollection.Add(CreateMessage("GetTradePriceInput","parameters","GetTradePriceSoapIn",myServiceDescription.TargetNamespace));
      myMessageCollection.Add(CreateMessage("GetTradePriceOutput","parameters","GetTradePriceSoapOut",myServiceDescription.TargetNamespace));
      myMessageCollection.Add(CreateMessage("GetTradePriceStringFault","parameters","GetTradePriceStringSoapFault",myServiceDescription.TargetNamespace));
      myMessageCollection.Add(CreateMessage("GetTradePriceIntFault","parameters","GetTradePriceIntSoapFault",myServiceDescription.TargetNamespace));

      // Generate the 'Port Type' element.
      PortTypeCollection myPortTypeCollection = myServiceDescription.PortTypes;
      PortType myPortType = new PortType();
      myPortType.Name = "StockQuotePortType";
      OperationCollection myOperationCollection = myPortType.Operations;
      Operation myOperation = new Operation();
      myOperation.Name = "GetTradePrice";
      OperationMessage myOperationMessage;
      OperationMessageCollection myOperationMessageCollection = myOperation.Messages;
      myOperationMessage = (OperationMessage) new OperationInput();
      myOperationMessage.Message = new XmlQualifiedName("s0:GetTradePriceInput");
      myOperationMessageCollection.Add(myOperationMessage);
      myOperationMessage = (OperationMessage) new OperationOutput();
      myOperationMessage.Message = new XmlQualifiedName("s0:GetTradePriceOutput");
      myOperationMessageCollection.Add(myOperationMessage);
      OperationFault myOperationFault = new OperationFault();
      myOperationFault.Name = "ErrorString";
      myOperationFault.Message = new XmlQualifiedName("s0:GetTradePriceStringFault");
      myOperation.Faults.Add(myOperationFault);
      myOperationFault = new OperationFault();
      myOperationFault.Name = "ErrorInt";
      myOperationFault.Message = new XmlQualifiedName("s0:GetTradePriceIntFault");
      myOperation.Faults.Add(myOperationFault);
      myOperationCollection.Add(myOperation);
      myPortTypeCollection.Add(myPortType);

      // Generate the 'Binding' element.
      ServiceDescriptionFormatExtensionCollection myExtensions;
      BindingCollection myBindingCollection = myServiceDescription.Bindings;
      Binding myBinding = new Binding();
      myBinding.Name = "StockQuoteSoapBinding";
      myBinding.Type = new XmlQualifiedName("s0:StockQuotePortType");
      myExtensions = myBinding.Extensions;
      SoapBinding mySoapBinding = new SoapBinding();
      mySoapBinding.Style = SoapBindingStyle.Document;
      mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http";
      myExtensions.Add(mySoapBinding);
      OperationBindingCollection myOperationBindingCollection = myBinding.Operations;
      OperationBinding myOperationBinding = new OperationBinding();
      myExtensions = myOperationBinding.Extensions;
      SoapOperationBinding mySoapBindingOperation = new SoapOperationBinding();
      mySoapBindingOperation.SoapAction = "http://www.contoso.com/GetTradePrice";
      myExtensions.Add(mySoapBindingOperation);
      myOperationBinding.Name = "GetTradePrice";
      myOperationBinding.Input = new InputBinding();
      myExtensions = myOperationBinding.Input.Extensions;
      SoapBodyBinding mySoapBodyBinding = new SoapBodyBinding();
      mySoapBodyBinding.Use = SoapBindingUse.Literal;
      mySoapBodyBinding.Namespace = "http://www.contoso.com/stockquote";
      myExtensions.Add(mySoapBodyBinding);
      myOperationBinding.Output = new OutputBinding();
      myExtensions = myOperationBinding.Output.Extensions;
      mySoapBodyBinding = new SoapBodyBinding();
      mySoapBodyBinding.Use = SoapBindingUse.Literal;
      mySoapBodyBinding.Namespace = "http://www.contoso.com/stockquote";
      myExtensions.Add(mySoapBodyBinding);
// <Snippet1>
// <Snippet2>
// <Snippet3>
      FaultBindingCollection myFaultBindingCollection = myOperationBinding.Faults;
      FaultBinding myFaultBinding = new FaultBinding();
      myFaultBinding.Name = "ErrorString";
      // Associate SOAP fault binding to the fault binding of the operation.
      myExtensions = myFaultBinding.Extensions;
      SoapFaultBinding mySoapFaultBinding = new SoapFaultBinding();
      mySoapFaultBinding.Use = SoapBindingUse.Literal;
      mySoapFaultBinding.Namespace = "http://www.contoso.com/stockquote";
      myExtensions.Add(mySoapFaultBinding);
      myFaultBindingCollection.Add(myFaultBinding);
// </Snippet3>
// </Snippet2>
// </Snippet1>
       myFaultBinding = new FaultBinding();
      myFaultBinding.Name = "ErrorInt";
      // Associate SOAP fault binding to the fault binding of the operation.
      myExtensions = myFaultBinding.Extensions;
      mySoapFaultBinding = new SoapFaultBinding();
      mySoapFaultBinding.Use = SoapBindingUse.Literal;
      mySoapFaultBinding.Namespace = "http://www.contoso.com/stockquote";
      myExtensions.Add(mySoapFaultBinding);
      myFaultBindingCollection.Add(myFaultBinding);
      myOperationBindingCollection.Add(myOperationBinding);
      myBindingCollection.Add(myBinding);
   
      // Generate the 'Service' element.
      ServiceCollection myServiceCollection = myServiceDescription.Services;
// <Snippet4>
      Service myService = new Service();
      // Add a simple documentation for the service to ease the readability of the generated WSDL file.
      myService.Documentation = "A Simple Stock Quote Service";
      myService.Name = "StockQuoteService";
      PortCollection myPortCollection = myService.Ports;
      Port myPort = new Port();
      myPort.Name = "StockQuotePort";
      myPort.Binding = new XmlQualifiedName("s0:StockQuoteSoapBinding");
      myExtensions = myPort.Extensions;
      SoapAddressBinding mySoapAddressBinding = new SoapAddressBinding();
      mySoapAddressBinding.Location = "http://www.contoso.com/stockquote";
      myExtensions.Add(mySoapAddressBinding);
      myPortCollection.Add(myPort);
// </Snippet4>
      myServiceCollection.Add(myService);

      // Display the WSDL generated to the console.
      myServiceDescription.Write(Console.Out);
   }

    public static XmlSchemaElement CreateComplexTypeXmlElement(string minoccurs,string maxoccurs,string name,bool isNillable,XmlQualifiedName schemaTypeName)
   {
      XmlSchemaElement myXmlSchemaElement = new XmlSchemaElement(); 
      myXmlSchemaElement.MinOccursString = minoccurs;
      myXmlSchemaElement.MaxOccursString = maxoccurs;
      myXmlSchemaElement.Name = name;
      myXmlSchemaElement.IsNillable = true;
      myXmlSchemaElement.SchemaTypeName = schemaTypeName;
      return myXmlSchemaElement;
   }
   public static  XmlSchemaElement CreateOtherXmlElement(string name,XmlQualifiedName SchemaTypeName)
   {
      XmlSchemaElement myXmlSchemaElement = new XmlSchemaElement();
      myXmlSchemaElement.Name = name;
      myXmlSchemaElement.SchemaTypeName = SchemaTypeName;
      return myXmlSchemaElement;
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
}
