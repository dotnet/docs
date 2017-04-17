// System.Web.Services.Description.SoapBinding.ctor
// System.Web.Services.Description.SoapBinding.Transport
// System.Web.Services.Description.SoapBinding.Style
// System.Web.Services.Description.SoapBindingStyle.Document
// System.Web.Services.Description.SoapOperationBinding.ctor
// System.Web.Services.Description.SoapOperationBinding.SoapAction
// System.Web.Services.Description.SoapOperationBinding.Style
// System.Web.Services.Description.SoapBodyBinding.ctor
// System.Web.Services.Description.SoapBodyBinding.Use
// System.Web.Services.Description.SoapBindingUse.Literal
// System.Web.Services.Description.SoapAddressBinding.ctor
// System.Web.Services.Description.SoapAddressBinding.Location

/*
The following example demonstrates the 'SoapBinding' constructor,'Transport','Style'
properties of 'SoapBinding' class,'Document' member of 'SoapBindingStyle' enum,
'SoapOperationBinding' constructor,'SoapAction','Style' properties of 'SoapOperationBinding'
class, 'SoapBodyBinding' contructor,'Use' property of 'SoapBodyBinding' class,
'Literal' member of 'SoapBindingUse' enum and 'SoapAddressBinding' constructor, 'Location' 
property  of class 'SoapAddressBinding'.

It takes as input a wsdl file which supports two protocols 'HttpGet' and 'HttpPost' .
By using the 'Read' method of 'ServiceDescription' class it gets a 'ServiceDescription'
object. It uses the SOAP protocol related classes  and  creates 'Binding','Port',
'PortType' and 'Message' elements of 'SOAP' protocol. It adds all these elements to 
the 'ServiceDescription' object. The 'ServiceDescription' object creates another 
wsdl file which supports 'SOAP' also. This wsdl file is used to generate a proxy
which is used by the .aspx file.
Note: To run the example run the makefile provided and open the '.aspx' file in browser.
*/

using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

   class MySoapClass
   {
      public static void Main()
      {
         ServiceDescription myDescription =
                     ServiceDescription.Read("AddNumbersInput_cs.wsdl");
         // Create a 'Binding' object for the 'SOAP' protocol.
         Binding myBinding = new Binding();
         myBinding.Name = "Service1Soap";
         XmlQualifiedName qualifiedName =
                     new XmlQualifiedName("s0:Service1Soap");
         myBinding.Type = qualifiedName;

// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>
         SoapBinding mySoapBinding = new SoapBinding();
         mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http";
         mySoapBinding.Style = SoapBindingStyle.Document;
         // Add the 'SoapBinding' object to the 'Binding' object.
         myBinding.Extensions.Add(mySoapBinding);
// </Snippet4>
// </Snippet3>
// </Snippet2>
// </Snippet1>

         // Create the 'OperationBinding' object for the 'SOAP' protocol.
         OperationBinding myOperationBinding = new OperationBinding();
         myOperationBinding.Name = "AddNumbers";

// <Snippet5>
// <Snippet6>
// <Snippet7>
         // Create the 'SoapOperationBinding' object for the 'SOAP' protocol.
         SoapOperationBinding mySoapOperationBinding =
                                          new SoapOperationBinding();
         mySoapOperationBinding.SoapAction  = "http://tempuri.org/AddNumbers";
         mySoapOperationBinding.Style = SoapBindingStyle.Document;
         // Add the 'SoapOperationBinding' object to 'OperationBinding' object.
         myOperationBinding.Extensions.Add(mySoapOperationBinding);
// </Snippet7>
// </Snippet6>
// </Snippet5>

// <Snippet8>
// <Snippet9>
// <Snippet10>
         // Create the 'InputBinding' object for the 'SOAP' protocol.
         InputBinding myInput = new InputBinding();
         SoapBodyBinding mySoapBinding1 = new SoapBodyBinding();
         mySoapBinding1.Use= SoapBindingUse.Literal;
         myInput.Extensions.Add(mySoapBinding1);
         // Add the 'InputBinding' object to 'OperationBinding' object.
         myOperationBinding.Input = myInput;
         // Create the 'OutputBinding' object'.
         OutputBinding myOutput = new OutputBinding();
         myOutput.Extensions.Add(mySoapBinding1);
         // Add the 'OutputBinding' object to 'OperationBinding' object.
         myOperationBinding.Output = myOutput; 
         // Add the 'OperationBinding' object to 'Binding' object.
         myBinding.Operations.Add(myOperationBinding);
         // Add the 'Binding' object to the ServiceDescription instance.
         myDescription.Bindings.Add(myBinding);
// </Snippet10>
// </Snippet9>
// </Snippet8>

// <Snippet11>
// <Snippet12>
         Port soapPort = new Port();
         soapPort.Name = "Service1Soap";
         soapPort.Binding = new XmlQualifiedName("s0:Service1Soap");
         // Create a 'SoapAddressBinding' object for the 'SOAP' protocol.
         SoapAddressBinding mySoapAddressBinding = 
                                       new SoapAddressBinding();
         mySoapAddressBinding.Location = "http://localhost/Service1_cs.asmx";
         // Add the 'SoapAddressBinding' object to the 'Port'.
         soapPort.Extensions.Add(mySoapAddressBinding);
         // Add the 'Port' object to the ServiceDescription instance.
         myDescription.Services[0].Ports.Add(soapPort);
// </Snippet12>
// </Snippet11>

         // Create a 'PortType' object. for SOAP protocol.
         PortType soapPortType = new PortType();
         soapPortType.Name = "Service1Soap";
         Operation soapOperation = new Operation();
         soapOperation.Name = "AddNumbers";

         OperationMessage soapInput =(OperationMessage)new OperationInput();
         soapInput.Message =new XmlQualifiedName("s0:AddNumbersSoapIn");
         OperationMessage soapOutput =(OperationMessage)new OperationOutput();
         soapOutput.Message =new XmlQualifiedName("s0:AddNumbersSoapOut");

         soapOperation.Messages.Add(soapInput);
         soapOperation.Messages.Add(soapOutput);

         // Add the 'Operation' object to 'PortType' object.
         soapPortType.Operations.Add(soapOperation);

         // Add the 'PortType' object first to 'PortTypeCollection' object
         // and then to 'ServiceDescription' object.
         myDescription.PortTypes.Add(soapPortType);

         // Create the 'Message' object.
         Message soapMessage1 = new Message();
         soapMessage1.Name="AddNumbersSoapIn";
         // Create the 'MessageParts' object.
         MessagePart soapMessagePart1 = new MessagePart();
         soapMessagePart1.Name = "parameters";
         soapMessagePart1.Element = new XmlQualifiedName("s0:AddNumbers");

         // Add the 'MessagePart' object to 'Messages' object.
         soapMessage1.Parts.Add(soapMessagePart1);

         // Create another 'Message' object.
         Message soapMessage2 = new Message();
         soapMessage2.Name = "AddNumbersSoapOut";

         MessagePart soapMessagePart2 = new MessagePart();
         soapMessagePart2.Name = "parameters";
         soapMessagePart2.Element =
                  new XmlQualifiedName("s0:AddNumbersResponse");
         // Add the 'MessagePart' object to second 'Message' object.
         soapMessage2.Parts.Add(soapMessagePart2); 

         // Add the 'Message' objects to 'ServiceDescription'. 
         myDescription.Messages.Add(soapMessage1);
         myDescription.Messages.Add(soapMessage2);

         // Write the 'ServiceDescription' object as a WSDL file.
         myDescription.Write("AddNumbersOut_cs.wsdl");
         Console.WriteLine(" 'AddNumbersOut_cs.Wsdl' file was generated");
    }
}