// System.Web.Services.Description.SoapHeaderBinding.ctor
// System.Web.Services.Description.SoapHeaderBinding.Message
// System.Web.Services.Description.SoapHeaderBinding.Part
// System.Web.Services.Description.SoapHeaderBinding.Use

/* 
The following example demonstrates the constructor, 'Message' , 'Part'
and 'Use' properties of the class 'SoapHeaderBinding'.
It takes as input a wsdl file. The binding element corresponding to 
SOAP protocol is removed from the input file. By using the 'Read' method 
of 'ServiceDescription' class it gets a 'ServiceDescription' object. 
It uses the SOAP protocol related classes  and  creates 'Binding' element
of 'SOAP' protocol which are then added to the 'ServiceDescription' object.
An output wsdl file is generated from 'ServiceDescription' object which 
could be used for generating a proxy.
*/
   
using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;
      public class MySampleClass
      {
         public static void Main()
         {
            ServiceDescription myServiceDescription = 
                           ServiceDescription.Read("SoapHeaderBindingInput_cs.wsdl");
            Binding myBinding = new Binding();
            myBinding.Name = "MyWebServiceSoap";
            myBinding.Type =new XmlQualifiedName("s0:MyWebServiceSoap");

            SoapBinding mySoapBinding =new SoapBinding();
            mySoapBinding.Transport="http://schemas.xmlsoap.org/soap/http";
            mySoapBinding.Style=SoapBindingStyle.Document;
            myBinding.Extensions.Add(mySoapBinding);

            OperationBinding myOperationBinding = new OperationBinding();
            myOperationBinding.Name = "Hello";

            SoapOperationBinding mySoapOperationBinding = 
                           new SoapOperationBinding();
            mySoapOperationBinding.SoapAction = "http://tempuri.org/Hello";
            mySoapOperationBinding.Style=SoapBindingStyle.Document;
            myOperationBinding.Extensions.Add(mySoapOperationBinding);

            // Create InputBinding for operation for the 'SOAP' protocol.
            InputBinding myInputBinding = new InputBinding();
            SoapBodyBinding mySoapBodyBinding = new SoapBodyBinding();
            mySoapBodyBinding.Use = SoapBindingUse.Literal;
            myInputBinding.Extensions.Add(mySoapBodyBinding);
// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>
            SoapHeaderBinding mySoapHeaderBinding=new SoapHeaderBinding();
            // Set the Message within the XML Web service to which the 
            // 'SoapHeaderBinding' applies.
            mySoapHeaderBinding.Message=
                           new XmlQualifiedName("s0:HelloMyHeader");
            mySoapHeaderBinding.Part="MyHeader";
            mySoapHeaderBinding.Use=SoapBindingUse.Literal;
            // Add mySoapHeaderBinding to the 'myInputBinding' object. 
            myInputBinding.Extensions.Add(mySoapHeaderBinding);
// </Snippet4>
// </Snippet3>
// </Snippet2>
// </Snippet1>
            // Create OutputBinding for operation for the 'SOAP' protocol.
            OutputBinding myOutputBinding = new OutputBinding();
            myOutputBinding.Extensions.Add(mySoapBodyBinding);

            // Add 'InputBinding' and 'OutputBinding' to 'OperationBinding'. 
            myOperationBinding.Input = myInputBinding;
            myOperationBinding.Output = myOutputBinding;
            myBinding.Operations.Add(myOperationBinding);

            myServiceDescription.Bindings.Add(myBinding);
            myServiceDescription.Write("SoapHeaderBindingOut_cs.wsdl");
            Console.WriteLine("'SoapHeaderBindingOut_cs.wsdl' file is generated.");
            Console.WriteLine("Proxy could be created using "
                        +"'wsdl SoapHeaderBindingOut_cs.wsdl'.");
         }
      }