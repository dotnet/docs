// System.Web.Services.Description.OperationInput
// System.Web.Services.Description.OperationInput.OperationInput

/*
   The following example demonstrates the usage of the 'OperationInput'
   class and its constructor 'OperationInput'. It instantiates the
   'ServiceDescription' object by reading a file 'AddNumbersIn_cs.wsdl'
   and then creates 'AddNumbersOut_cs.wsdl' file which corresponds to
   added attributes in the 'ServiceDescription' instance.
*/

// <Snippet1>
using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

class MyOperationInputSample
{
   public static void Main()
   {
      try
      {
         ServiceDescription myDescription = 
            ServiceDescription.Read("AddNumbersIn_cs.wsdl");

         // Add the ServiceHttpPost binding.
         Binding myBinding = new Binding();
         myBinding.Name = "ServiceHttpPost";
         XmlQualifiedName myXmlQualifiedName = 
            new XmlQualifiedName ("s0:ServiceHttpPost");
         myBinding.Type = myXmlQualifiedName;
         HttpBinding myHttpBinding = new HttpBinding();
         myHttpBinding.Verb = "POST";
         myBinding.Extensions.Add(myHttpBinding);

         // Add the operation name AddNumbers.
         OperationBinding myOperationBinding = new OperationBinding();
         myOperationBinding.Name = "AddNumbers";
         HttpOperationBinding myOperation = new HttpOperationBinding();
         myOperation.Location = "/AddNumbers";
         myOperationBinding.Extensions.Add(myOperation);

         // Add the input binding.
         InputBinding myInput = new InputBinding();
         MimeContentBinding postMimeContentbinding = 
           new MimeContentBinding();
         postMimeContentbinding.Type= "application/x-www-form-urlencoded";
         myInput.Extensions.Add(postMimeContentbinding);

         // Add the InputBinding to the OperationBinding.
         myOperationBinding.Input = myInput;

         // Add the ouput binding.
         OutputBinding myOutput = new OutputBinding();
         MimeXmlBinding postMimeXmlBinding = new MimeXmlBinding();
         postMimeXmlBinding.Part= "Body";
         myOutput.Extensions.Add(postMimeXmlBinding);

         // Add the OutputBinding to the OperationBinding.
         myOperationBinding.Output = myOutput; 

         myBinding.Operations.Add(myOperationBinding);
         myDescription.Bindings.Add(myBinding);

         // Add the port definition.
         Port postPort = new Port();
         postPort.Name = "ServiceHttpPost";
         postPort.Binding = new XmlQualifiedName("s0:ServiceHttpPost");
         HttpAddressBinding postAddressBinding = new HttpAddressBinding();
         postAddressBinding.Location = "http://localhost/Service.cs.asmx";
         postPort.Extensions.Add(postAddressBinding);
         myDescription.Services[0].Ports.Add(postPort);

         // Add the post port type definition.
         PortType postPortType = new PortType();
         postPortType.Name = "ServiceHttpPost";
         Operation postOperation = new Operation();
         postOperation.Name = "AddNumbers";
         OperationMessage postOutput = 
            (OperationMessage)new OperationOutput();
         postOutput.Message = 
            new XmlQualifiedName ("s0:AddNumbersHttpPostOut");
// <Snippet2>
         OperationInput postInput = new OperationInput();
         postInput.Message = 
            new XmlQualifiedName ("s0:AddNumbersHttpPostIn");

         postOperation.Messages.Add(postInput);
         postOperation.Messages.Add(postOutput);
         postPortType.Operations.Add(postOperation);
// </Snippet2>
         myDescription.PortTypes.Add(postPortType);

         // Add the first message information.
         Message postMessage1 = new Message();
         postMessage1.Name="AddNumbersHttpPostIn";
         MessagePart postMessagePart1 = new MessagePart();
         postMessagePart1.Name = "firstnumber";
         postMessagePart1.Type = new XmlQualifiedName("s:string");

         // Add the second message information.
         MessagePart postMessagePart2 = new MessagePart();
         postMessagePart2.Name = "secondnumber";
         postMessagePart2.Type = new XmlQualifiedName("s:string");
         postMessage1.Parts.Add(postMessagePart1);
         postMessage1.Parts.Add(postMessagePart2);
         Message postMessage2 = new Message();
         postMessage2.Name = "AddNumbersHttpPostOut";

         // Add the third message information.
         MessagePart postMessagePart3 = new MessagePart();
         postMessagePart3.Name = "Body";
         postMessagePart3.Element = new XmlQualifiedName("s0:int");
         postMessage2.Parts.Add(postMessagePart3); 

         myDescription.Messages.Add(postMessage1);
         myDescription.Messages.Add(postMessage2);

         // Write the ServiceDescription as a WSDL file.
         myDescription.Write("AddNumbersOut_cs.wsdl");
         Console.WriteLine("WSDL file named AddNumberOut_cs.Wsdl" +
            " created successfully.");
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception caught!!!");
         Console.WriteLine("Source : " + e.Source);
         Console.WriteLine("Message : " + e.Message);
      }
   }
}
// </Snippet1>
