// System.Web.Services.Description.SoapHeaderBinding

/* 
The following example demonstrates the class 'SoapHeaderBinding'.
It takes as input a wsdl file. By using the 'Read' method 
of 'ServiceDescription' class it gets a 'ServiceDescription' object. 
It uses the SOAP protocol related classes  and  creates 'Binding' element
of 'SOAP' protocol which are then added to the 'ServiceDescription' object.
An output wsdl file is generated from 'ServiceDescription' object which 
could be used for generating a proxy.
*/

// <Snippet1>
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
      SoapHeaderBinding mySoapHeaderBinding=new SoapHeaderBinding();
      mySoapHeaderBinding.Message=new XmlQualifiedName("s0:HelloMyHeader");
      mySoapHeaderBinding.Part="MyHeader";
      mySoapHeaderBinding.Use=SoapBindingUse.Literal;
      // Add mySoapHeaderBinding to 'myInputBinding' object. 
      myInputBinding.Extensions.Add(mySoapHeaderBinding);
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
// </Snippet1>
