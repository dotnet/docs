// System.Web.Services.Description.SoapBindingStyle.Rpc
// System.Web.Services.Description.SoapBindingUse.Encoded
// System.Web.Services.Description.SoapBodyBinding.Encoding
// System.Web.Services.Description.SoapBodyBinding.Namespace
// System.Web.Services.Description.SoapHeaderBinding.Encoding
// System.Web.Services.Description.SoapHeaderBinding.Namespace

/*
The following example demonstrates the 'Rpc' member of 'SoapBindingStyle' 
enumeration ,'Encoded' member of 'SoapBindingUse' enumeration ,'Encoding'
and 'Namespace' properties of 'SoapBodyBinding' class and 'Encoding'
and 'Namespace' properties of 'SoapHeaderBinding' class.   
It takes as input a wsdl file which does not contain a binding for SOAP.
By using the 'Read' method of 'ServiceDescription' class it gets a 'ServiceDescription' object.
It uses the SOAP protocol related classes  and  creates 'Binding' element
of 'SOAP' protocol which are then added to the 'ServiceDescription' object.
An output wsdl file is generated from 'ServiceDescription' object which 
could be used for generating a proxy.
*/

using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;
      public class MySoapBindingClass
      {
         public static void Main()
         {
            ServiceDescription myServiceDescription = 
                   ServiceDescription.Read("SoapBindingStyleInput_cs.wsdl");
            Binding myBinding = new Binding();
            myBinding.Name = "SOAPSvrMgr_SOAPBinding";
            myBinding.Type =new XmlQualifiedName("tns:SOAPSvrMgr_portType");

// <Snippet1>
            SoapBinding mySoapBinding =new SoapBinding();
            mySoapBinding.Transport="http://schemas.xmlsoap.org/soap/http";
            // Message to be transmitted contains parameters to call a procedure.
            mySoapBinding.Style=SoapBindingStyle.Rpc;
            myBinding.Extensions.Add(mySoapBinding);
// </Snippet1>

            OperationBinding myOperationBinding = new OperationBinding();
            myOperationBinding.Name = "GetServerStats";

            SoapOperationBinding mySoapOperationBinding = 
                           new SoapOperationBinding();
            mySoapOperationBinding.SoapAction = 
                     "http://tempuri.org/soapsvcmgr/GetServerStats";
            myOperationBinding.Extensions.Add(mySoapOperationBinding);

            // Create InputBinding for operation for the 'SOAP' protocol.
            InputBinding myInputBinding = new InputBinding();
// <Snippet2>
// <Snippet3>
// <Snippet4>
            SoapBodyBinding mySoapBodyBinding = new SoapBodyBinding();
            // Encode SOAP body using rules specified by the 'Encoding' property.
            mySoapBodyBinding.Use = SoapBindingUse.Encoded;
            // Set URI representing the encoding style for encoding the body.
            mySoapBodyBinding.Encoding="http://schemas.xmlsoap.org/soap/encoding/";
            // Set the Uri representing the location of the specification 
            // for encoding of content not defined by 'Encoding' property'.
            mySoapBodyBinding.Namespace="http://tempuri.org/soapsvcmgr/";
            myInputBinding.Extensions.Add(mySoapBodyBinding);
// </Snippet4>
// </Snippet3>
// </Snippet2>

// <Snippet5>
// <Snippet6>
            SoapHeaderBinding mySoapHeaderBinding=new SoapHeaderBinding();
            mySoapHeaderBinding.Message=
                         new XmlQualifiedName("tns:Soapsvcmgr_Headers_Request");
            mySoapHeaderBinding.Part="AuthCS";   
            // Encode SOAP header using rules specified by the 'Encoding' property.
            mySoapHeaderBinding.Use=SoapBindingUse.Encoded;
            // Set URI representing the encoding style for encoding the header.
            mySoapHeaderBinding.Encoding = "http://schemas.xmlsoap.org/soap/encoding/";
            // Set the Uri representing the location of the specification 
            // for encoding of content not defined by 'Encoding' property'.
            mySoapHeaderBinding.Namespace = "http://tempuri.org/SOAPSvr/soapsvcmgr/headers.xsd";
            // Add mySoapHeaderBinding to the 'myInputBinding' object.
            myInputBinding.Extensions.Add(mySoapHeaderBinding);
// </Snippet5>
// </Snippet6>
            // Create OutputBinding for operation.
            OutputBinding myOutputBinding = new OutputBinding();
            myOutputBinding.Extensions.Add(mySoapBodyBinding);
            mySoapHeaderBinding.Part="AuthSC";
            mySoapHeaderBinding.Message=
                     new XmlQualifiedName("tns:Soapsvcmgr_Headers_Response");
            myOutputBinding.Extensions.Add(mySoapHeaderBinding);

            // Add 'InputBinding' and 'OutputBinding' to 'OperationBinding'. 
            myOperationBinding.Input = myInputBinding;
            myOperationBinding.Output = myOutputBinding;
            myBinding.Operations.Add(myOperationBinding);

            myServiceDescription.Bindings.Add(myBinding);
            myServiceDescription.Write("SoapBindingStyleOutput_cs.wsdl");
            Console.WriteLine("'SoapBindingStyleOutput_cs.wsdl' file is generated.");
            Console.WriteLine("Proxy could be created using command"+ 
                              " 'wsdl SoapBindingStyleOutput_cs.wsdl'");
         }
      }