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

#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Xml;
using namespace System::Xml::Schema;
using namespace System::Xml::Serialization;

XmlSchemaElement^ CreateComplexTypeXmlElement( String^ minoccurs, String^ maxoccurs, String^ name, bool isNillable, XmlQualifiedName^ schemaTypeName )
{
   XmlSchemaElement^ myXmlSchemaElement = gcnew XmlSchemaElement;
   myXmlSchemaElement->MinOccursString = minoccurs;
   myXmlSchemaElement->MaxOccursString = maxoccurs;
   myXmlSchemaElement->Name = name;
   myXmlSchemaElement->IsNillable = true;
   myXmlSchemaElement->SchemaTypeName = schemaTypeName;
   return myXmlSchemaElement;
}

XmlSchemaElement^ CreateOtherXmlElement( String^ name, XmlQualifiedName^ SchemaTypeName )
{
   XmlSchemaElement^ myXmlSchemaElement = gcnew XmlSchemaElement;
   myXmlSchemaElement->Name = name;
   myXmlSchemaElement->SchemaTypeName = SchemaTypeName;
   return myXmlSchemaElement;
}

// Creates a Message with name =S"messageName" having one MessagePart with name = S"partName".
Message^ CreateMessage( String^ messageName, String^ partName, String^ element, String^ targetNamespace )
{
   Message^ myMessage = gcnew Message;
   myMessage->Name = messageName;
   MessagePart^ myMessagePart = gcnew MessagePart;
   myMessagePart->Name = partName;
   myMessagePart->Element = gcnew XmlQualifiedName( element,targetNamespace );
   myMessage->Parts->Add( myMessagePart );
   return myMessage;
}

int main()
{
   ServiceDescription^ myServiceDescription = gcnew ServiceDescription;
   myServiceDescription->Name = "StockQuote";
   myServiceDescription->TargetNamespace = "http://www.contoso.com/stockquote.wsdl";
   
   // Generate the 'Types' element. 
   XmlSchema^ myXmlSchema = gcnew XmlSchema;
   myXmlSchema->AttributeFormDefault = XmlSchemaForm::Qualified;
   myXmlSchema->ElementFormDefault = XmlSchemaForm::Qualified;
   myXmlSchema->TargetNamespace = "http://www.contoso.com/stockquote.wsdl";
   
   //XmlSchemaElement myXmlSchemaElement;
   XmlSchemaComplexType^ myXmlSchemaComplexType = gcnew XmlSchemaComplexType;
   myXmlSchemaComplexType->Name = "GetTradePriceInputType";
   XmlSchemaSequence^ myXmlSchemaSequence = gcnew XmlSchemaSequence;
   myXmlSchemaSequence->Items->Add( CreateComplexTypeXmlElement( "1", "1", "tickerSymbol", true, gcnew XmlQualifiedName( "s:string" ) ) );
   myXmlSchemaSequence->Items->Add( CreateComplexTypeXmlElement( "1", "1", "time", true, gcnew XmlQualifiedName( "s:string" ) ) );
   myXmlSchemaComplexType->Particle = myXmlSchemaSequence;
   myXmlSchema->Items->Add( myXmlSchemaComplexType );

   myXmlSchemaComplexType = gcnew XmlSchemaComplexType;
   myXmlSchemaComplexType->Name = "GetTradePriceOutputType";
   myXmlSchemaSequence = gcnew XmlSchemaSequence;
   myXmlSchemaSequence->Items->Add( CreateComplexTypeXmlElement( "1", "1", "result", true, gcnew XmlQualifiedName( "s:string" ) ) );
   myXmlSchemaComplexType->Particle = myXmlSchemaSequence;
   myXmlSchema->Items->Add( myXmlSchemaComplexType );

   myXmlSchemaComplexType = gcnew XmlSchemaComplexType;
   myXmlSchemaComplexType->Name = "GetTradePriceStringFaultType";
   myXmlSchemaSequence = gcnew XmlSchemaSequence;
   myXmlSchemaSequence->Items->Add( CreateComplexTypeXmlElement( "1", "1", "error", true, gcnew XmlQualifiedName( "s:string" ) ) );
   myXmlSchemaComplexType->Particle = myXmlSchemaSequence;
   myXmlSchema->Items->Add( myXmlSchemaComplexType );

   myXmlSchemaComplexType = gcnew XmlSchemaComplexType;
   myXmlSchemaComplexType->Name = "GetTradePriceStringIntType";
   myXmlSchemaSequence = gcnew XmlSchemaSequence;
   myXmlSchemaSequence->Items->Add( CreateComplexTypeXmlElement( "1", "1", "error", true, gcnew XmlQualifiedName( "s:int" ) ) );
   myXmlSchemaComplexType->Particle = myXmlSchemaSequence;
   myXmlSchema->Items->Add( myXmlSchemaComplexType );

   myXmlSchema->Items->Add( CreateOtherXmlElement( "GetTradePriceSoapIn", gcnew XmlQualifiedName( "s0:GetTradePriceInputType" ) ) );
   myXmlSchema->Items->Add( CreateOtherXmlElement( "GetTradePriceSoapOut", gcnew XmlQualifiedName( "s0:GetTradePriceOutputType" ) ) );
   myXmlSchema->Items->Add( CreateOtherXmlElement( "GetTradePriceSoapStringFault", gcnew XmlQualifiedName( "s0:GetTradePriceStringFaultType" ) ) );
   myXmlSchema->Items->Add( CreateOtherXmlElement( "GetTradePriceSoapIntFault", gcnew XmlQualifiedName( "s0:GetTradePriceIntFaultType" ) ) );

   myServiceDescription->Types->Schemas->Add( myXmlSchema );
   
   // Generate the 'Message' element.
   MessageCollection^ myMessageCollection = myServiceDescription->Messages;
   myMessageCollection->Add( CreateMessage( "GetTradePriceInput", "parameters", "GetTradePriceSoapIn", myServiceDescription->TargetNamespace ) );
   myMessageCollection->Add( CreateMessage( "GetTradePriceOutput", "parameters", "GetTradePriceSoapOut", myServiceDescription->TargetNamespace ) );
   myMessageCollection->Add( CreateMessage( "GetTradePriceStringFault", "parameters", "GetTradePriceStringSoapFault", myServiceDescription->TargetNamespace ) );
   myMessageCollection->Add( CreateMessage( "GetTradePriceIntFault", "parameters", "GetTradePriceIntSoapFault", myServiceDescription->TargetNamespace ) );
   
   // Generate the 'Port Type' element.
   PortTypeCollection^ myPortTypeCollection = myServiceDescription->PortTypes;
   PortType^ myPortType = gcnew PortType;
   myPortType->Name = "StockQuotePortType";
   OperationCollection^ myOperationCollection = myPortType->Operations;
   Operation^ myOperation = gcnew Operation;
   myOperation->Name = "GetTradePrice";
   OperationMessage^ myOperationMessage;
   OperationMessageCollection^ myOperationMessageCollection = myOperation->Messages;
   myOperationMessage = dynamic_cast<OperationMessage^>(gcnew OperationInput);
   myOperationMessage->Message = gcnew XmlQualifiedName( "s0:GetTradePriceInput" );
   myOperationMessageCollection->Add( myOperationMessage );
   myOperationMessage = dynamic_cast<OperationMessage^>(gcnew OperationOutput);
   myOperationMessage->Message = gcnew XmlQualifiedName( "s0:GetTradePriceOutput" );
   myOperationMessageCollection->Add( myOperationMessage );
   OperationFault^ myOperationFault = gcnew OperationFault;
   myOperationFault->Name = "ErrorString";
   myOperationFault->Message = gcnew XmlQualifiedName( "s0:GetTradePriceStringFault" );
   myOperation->Faults->Add( myOperationFault );
   myOperationFault = gcnew OperationFault;
   myOperationFault->Name = "ErrorInt";
   myOperationFault->Message = gcnew XmlQualifiedName( "s0:GetTradePriceIntFault" );
   myOperation->Faults->Add( myOperationFault );
   myOperationCollection->Add( myOperation );
   myPortTypeCollection->Add( myPortType );
   
   // Generate the 'Binding' element.
   ServiceDescriptionFormatExtensionCollection^ myExtensions;
   BindingCollection^ myBindingCollection = myServiceDescription->Bindings;
   Binding^ myBinding = gcnew Binding;
   myBinding->Name = "StockQuoteSoapBinding";
   myBinding->Type = gcnew XmlQualifiedName( "s0:StockQuotePortType" );
   myExtensions = myBinding->Extensions;
   SoapBinding^ mySoapBinding = gcnew SoapBinding;
   mySoapBinding->Style = SoapBindingStyle::Document;
   mySoapBinding->Transport = "http://schemas.xmlsoap.org/soap/http";
   myExtensions->Add( mySoapBinding );
   OperationBindingCollection^ myOperationBindingCollection = myBinding->Operations;
   OperationBinding^ myOperationBinding = gcnew OperationBinding;
   myExtensions = myOperationBinding->Extensions;
   SoapOperationBinding^ mySoapBindingOperation = gcnew SoapOperationBinding;
   mySoapBindingOperation->SoapAction = "http://www.contoso.com/GetTradePrice";
   myExtensions->Add( mySoapBindingOperation );
   myOperationBinding->Name = "GetTradePrice";
   myOperationBinding->Input = gcnew InputBinding;
   myExtensions = myOperationBinding->Input->Extensions;
   SoapBodyBinding^ mySoapBodyBinding = gcnew SoapBodyBinding;
   mySoapBodyBinding->Use = SoapBindingUse::Literal;
   mySoapBodyBinding->Namespace = "http://www.contoso.com/stockquote";
   myExtensions->Add( mySoapBodyBinding );
   myOperationBinding->Output = gcnew OutputBinding;
   myExtensions = myOperationBinding->Output->Extensions;
   mySoapBodyBinding = gcnew SoapBodyBinding;
   mySoapBodyBinding->Use = SoapBindingUse::Literal;
   mySoapBodyBinding->Namespace = "http://www.contoso.com/stockquote";
   myExtensions->Add( mySoapBodyBinding );
   
// <Snippet1>
// <Snippet2>
// <Snippet3>
   FaultBindingCollection^ myFaultBindingCollection = myOperationBinding->Faults;
   FaultBinding^ myFaultBinding = gcnew FaultBinding;
   myFaultBinding->Name = "ErrorString";
   // Associate SOAP fault binding to the fault binding of the operation.
   myExtensions = myFaultBinding->Extensions;
   SoapFaultBinding^ mySoapFaultBinding = gcnew SoapFaultBinding;
   mySoapFaultBinding->Use = SoapBindingUse::Literal;
   mySoapFaultBinding->Namespace = "http://www.contoso.com/stockquote";
   myExtensions->Add( mySoapFaultBinding );
   myFaultBindingCollection->Add( myFaultBinding );
// </Snippet3>
// </Snippet2>
// </Snippet1>

   myFaultBinding = gcnew FaultBinding;
   myFaultBinding->Name = "ErrorInt";
   // Associate SOAP fault binding to the fault binding of the operation.
   myExtensions = myFaultBinding->Extensions;
   mySoapFaultBinding = gcnew SoapFaultBinding;
   mySoapFaultBinding->Use = SoapBindingUse::Literal;
   mySoapFaultBinding->Namespace = "http://www.contoso.com/stockquote";
   myExtensions->Add( mySoapFaultBinding );
   myFaultBindingCollection->Add( myFaultBinding );
   myOperationBindingCollection->Add( myOperationBinding );
   myBindingCollection->Add( myBinding );
   
   // Generate the 'Service' element.
   ServiceCollection^ myServiceCollection = myServiceDescription->Services;
   
// <Snippet4>
   Service^ myService = gcnew Service;
   // Add a simple documentation for the service to ease the readability of the generated WSDL file.
   myService->Documentation = "A Simple Stock Quote Service";
   myService->Name = "StockQuoteService";
   PortCollection^ myPortCollection = myService->Ports;
   Port^ myPort = gcnew Port;
   myPort->Name = "StockQuotePort";
   myPort->Binding = gcnew XmlQualifiedName( "s0:StockQuoteSoapBinding" );
   myExtensions = myPort->Extensions;
   SoapAddressBinding^ mySoapAddressBinding = gcnew SoapAddressBinding;
   mySoapAddressBinding->Location = "http://www.contoso.com/stockquote";
   myExtensions->Add( mySoapAddressBinding );
   myPortCollection->Add( myPort );
   // </Snippet4>
   myServiceCollection->Add( myService );
   
   // Display the WSDL generated to the console.
   myServiceDescription->Write( Console::Out );
}
