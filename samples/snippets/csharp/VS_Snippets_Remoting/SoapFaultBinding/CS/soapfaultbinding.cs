// System.Web.Services.Description.SoapFaultBinding

/*
 The following example demonstrates 'SoapFaultBinding' class. 
 It creates an instance of 'ServiceDescription' class by reading  an existing 
 wsdl file. Then it creates an instance of 'SoapFaultBinding' and adds it to 
 the collection object of 'Binding' class. It generates a new wsdl file where 
 the properties of 'SoapFaultBinding' objects are reflected and which could be
 used for generating a proxy.
*/

// <Snippet1>
   using System;
   using System.Web.Services.Description;
   public class MySoapFaultBindingSample
   {
      public static void Main()
      {
         try
         {
            // Input wsdl file.
            string myInputWsdlFile="SoapFaultBindingInput_cs.wsdl";
            // Output wsdl file.
            string myOutputWsdlFile="SoapFaultBindingOutput_cs.wsdl";
            // Initialize an instance of a 'ServiceDescription' object.
            ServiceDescription myServiceDescription =
               ServiceDescription.Read(myInputWsdlFile);
            // Get a SOAP binding object with binding name "MyService1Soap". 
            Binding myBinding=myServiceDescription.Bindings["MyService1Soap"];
            // Create a new instance of 'SoapFaultBinding' class.
            SoapFaultBinding mySoapFaultBinding=new SoapFaultBinding();
            // Encode fault message using rules specified by 'Encoding' property.
            mySoapFaultBinding.Use=SoapBindingUse.Encoded;
            // Set the URI representing the encoding style.
            mySoapFaultBinding.Encoding="http://tempuri.org/stockquote";
            // Set the URI representing the location of the specification
            // for encoding of content not defined by 'Encoding' property'.
            mySoapFaultBinding.Namespace="http://tempuri.org/stockquote";
            // Create a new instance of 'FaultBinding'.
            FaultBinding myFaultBinding=new FaultBinding();
            myFaultBinding.Name="AddFaultbinding";
            myFaultBinding.Extensions.Add(mySoapFaultBinding);
            // Get existing 'OperationBinding' object.
            OperationBinding myOperationBinding=myBinding.Operations[0];
            myOperationBinding.Faults.Add(myFaultBinding);
            // Create a new wsdl file.
            myServiceDescription.Write(myOutputWsdlFile);
            Console.WriteLine("The new wsdl file created is :"
                              +myOutputWsdlFile);
            Console.WriteLine("Proxy could be created using command : wsdl "
                                + myOutputWsdlFile);
         }
         catch(Exception e)
         {
            Console.WriteLine("Error occured : "+e.Message);
         }
      }
   }
// </Snippet1>
