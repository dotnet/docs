
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

         SoapBinding mySoapBinding = new SoapBinding();
         mySoapBinding.Transport = SoapBinding.HttpTransport;
         mySoapBinding.Style = SoapBindingStyle.Document;
         // Add the 'SoapBinding' object to the 'Binding' object.
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

         // Create the 'InputBinding' object for the 'SOAP' protocol.
         InputBinding myInput = new InputBinding();
         SoapBodyBinding mySoapBinding1 = new SoapBodyBinding();
         mySoapBinding1.Use= SoapBindingUse.Literal;
         myInput.Extensions.Add(mySoapBinding1);
         // Assign the 'InputBinding' to 'OperationBinding'.
         myOperationBinding.Input = myInput;
         // Create the 'OutputBinding' object' for the 'SOAP' protocol..
         OutputBinding myOutput = new OutputBinding();
         myOutput.Extensions.Add(mySoapBinding1);
          // Assign the 'OutPutBinding' to 'OperationBinding'.
         myOperationBinding.Output = myOutput; 

         // Add the 'OperationBinding' to 'Binding'.
         myBinding.Operations.Add(myOperationBinding);

          // Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
         myDescription.Bindings.Add(myBinding);

         Port soapPort = new Port();
         soapPort.Name = "Service1Soap";
         soapPort.Binding = new XmlQualifiedName("s0:Service1Soap");

         // Create a 'SoapAddressBinding' object for the 'SOAP' protocol.
         SoapAddressBinding mySoapAddressBinding = 
                                       new SoapAddressBinding();
         mySoapAddressBinding.Location = "http://localhost/AddNumbers.cs.asmx";

         // Add the 'SoapAddressBinding' to the 'Port'.
         soapPort.Extensions.Add(mySoapAddressBinding);

         // Add the 'Port' to 'PortCollection' of 'ServiceDescription'.
         myDescription.Services[0].Ports.Add(soapPort);

         // Write the 'ServiceDescription' as a WSDL file.
         myDescription.Write("AddNumbersOut_cs.wsdl");
         Console.WriteLine(" 'AddNumbersOut_cs.Wsdl' file was generated");
    }
}