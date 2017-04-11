// System.Web.Services.Description.SoapBinding.Namespace
// System.Web.Services.Description.SoapBodyBinding.Parts

/*
The following example demonstrates the 'Namespace' field of 'SoapBinding' class
and 'parts' property of 'SoapBodyBinding' class.
It takes a wsdl file which supports two protocols 'HttpGet' and 'HttpPost' as input. By
using the 'Read' method of 'ServiceDescription' class it gets the 'ServiceDescription'
object. It uses the SOAP protocol related classes to create 'Binding' elements of
'SOAP' protocol. It adds all the elements to the 'ServiceDescription' object. The
'ServiceDescription' object creates another wsdl file which supports 'SOAP' protocol
also. This wsdl file is used to generate a proxy which is used by the .aspx file.
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
         SoapBinding mySoapBinding = new SoapBinding();
         mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http";
         mySoapBinding.Style = SoapBindingStyle.Document;
         // Get the URI for XML namespace of the SoapBinding class.
         String myNameSpace = SoapBinding.Namespace;
         Console.WriteLine("The URI of the XML Namespace is :"+myNameSpace);
// </Snippet1>

         // Add the 'SoapBinding'  object to the 'Binding' object.
         myBinding.Extensions.Add(mySoapBinding);

         // Create the 'OperationBinding' object for the 'SOAP' protocol.
         OperationBinding myOperationBinding = new OperationBinding();
         myOperationBinding.Name = "AddNumbers";

         // Create the 'SoapOperationBinding' object for the 'SOAP' protocol.
         SoapOperationBinding mySoapOperationBinding =
                                          new SoapOperationBinding();
         mySoapOperationBinding.SoapAction  = "http://tempuri.org/AddNumbers";
         mySoapOperationBinding.Style = SoapBindingStyle.Document;
         // Add the 'SoapOperationBinding' object to 'OperationBinding' object.
         myOperationBinding.Extensions.Add(mySoapOperationBinding);

// <Snippet2>
         // Create the 'InputBinding' object for the 'SOAP' protocol.
         InputBinding myInput = new InputBinding();
         SoapBodyBinding mySoapBinding1 = new SoapBodyBinding();
         mySoapBinding1.Use= SoapBindingUse.Literal;

         String[] myParts = new String[1];
         myParts[0] = "parameters";
          // Set the names of the message parts to appear in the SOAP body.
         mySoapBinding1.Parts = myParts;
         myInput.Extensions.Add(mySoapBinding1);
         // Add the 'InputBinding' object to 'OperationBinding' object.
         myOperationBinding.Input = myInput;
         // Create the 'OutputBinding' object'.
         OutputBinding myOutput = new OutputBinding();
         myOutput.Extensions.Add(mySoapBinding1);
          // Add the 'OutPutBinding' to 'OperationBinding'.
         myOperationBinding.Output = myOutput;
// </Snippet2>
         // Add the 'OperationBinding' to 'Binding'.
         myBinding.Operations.Add(myOperationBinding);

          // Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
         myDescription.Bindings.Add(myBinding);

        // Write the 'ServiceDescription' as a WSDL file.
         myDescription.Write("AddNumbersOut_cs.wsdl");
         Console.WriteLine(" 'AddNumbersOut_cs.Wsdl' file was generated");
    }
}