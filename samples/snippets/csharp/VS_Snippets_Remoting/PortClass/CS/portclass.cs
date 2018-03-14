// System.Web.Services.Description.Port.ctor().
// System.Web.Services.Description.Port.Binding().
// System.Web.Services.Description.Portt.Extensions.
// System.Web.Services.Description.Port.Name.
// System.Web.Services.Description.Port.Service.

/* The following example demonstrates the constructor and the properties 'Binding',
  'Extensions','Name', and 'Service' of the 'Port' class.
  The input to the program is a WSDL file 'AddNumbers_cs.wsdl'.
  It creates a 'ServiceDescription' instance by using the static read method
  of 'ServiceDescription' by passing the  'AddNumbers.wsdl' name as an argument.
  It creates  a 'Binding' object and adds that binding object to
  'ServiceDescription'. It adds the 'PortType',Messages to the 'ServiceDescription'
  object. Finally it writes the 'ServiceDescrption' as a WSDL file with
  name 'AddNumbersOne.wsdl.
 */

using System;
using System.Web.Services.Description;
using System.Web;
using System.Collections;
using System.Xml;

class PortClass
{
   public static void Main()
   {
    try
    {
     ServiceDescription myDescription = ServiceDescription.Read("AddNumbers_cs.wsdl");
     // Create the 'Binding' object.
     Binding myBinding = new Binding();
     myBinding.Name = "PortServiceHttpPost";
     XmlQualifiedName qualifiedName = new XmlQualifiedName("s0:PortServiceHttpPost");
     myBinding.Type = qualifiedName;

     // Create the 'HttpBinding' object.
     HttpBinding myHttpBinding = new HttpBinding();
     myHttpBinding.Verb="POST";
     // Add the 'HttpBinding' to the 'Binding'.
     myBinding.Extensions.Add(myHttpBinding);
     // Create the 'OperationBinding' object.
     OperationBinding myOperationBinding = new OperationBinding();
     myOperationBinding.Name = "AddNumbers";
     HttpOperationBinding myOperation = new HttpOperationBinding();
     myOperation.Location="/AddNumbers";
     // Add the 'HttpOperationBinding' to 'OperationBinding'.
     myOperationBinding.Extensions.Add(myOperation);

     // Create the 'InputBinding' object.
     InputBinding myInput = new InputBinding();
     MimeContentBinding postMimeContentbinding = new MimeContentBinding();
     postMimeContentbinding.Type="application/x-www-form-urlencoded";
     myInput.Extensions.Add(postMimeContentbinding);
     // Add the 'InputBinding' to 'OperationBinding'.
     myOperationBinding.Input = myInput;
     // Create the 'OutputBinding' object.
     OutputBinding myOutput = new OutputBinding();
     MimeXmlBinding postMimeXmlbinding = new MimeXmlBinding();
     postMimeXmlbinding .Part="Body";
     myOutput.Extensions.Add(postMimeXmlbinding);

     // Add the 'OutPutBinding' to 'OperationBinding'.
     myOperationBinding.Output = myOutput;
     // Add the 'OperationBinding' to 'Binding'.
     myBinding.Operations.Add(myOperationBinding);

     // Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
     myDescription.Bindings.Add(myBinding);
// <Snippet1>
// <Snippet2>
// <Snippet3>
// <Snippet4>
// <Snippet5>
     // Create a Port.
     Port postPort = new Port();
     postPort.Name = "PortServiceHttpPost";
     postPort.Binding = new XmlQualifiedName("s0:PortServiceHttpPost");
// </Snippet4>
// </Snippet2>

     // Create an HttpAddressBinding.
     HttpAddressBinding postAddressBinding = new HttpAddressBinding();
     postAddressBinding.Location = 
        "http://localhost/PortClass/PortService_cs.asmx";

     // Add the HttpAddressBinding to the Port.
     postPort.Extensions.Add(postAddressBinding);
// </Snippet3>

     // Get the Service of the postPort.
     Service myService = postPort.Service;

     // Print the service name for the port.
     Console.WriteLine("This is the service name of the postPort:*" +
        myDescription.Services[0].Ports[0].Service.Name + "*");

     // Add the Port to the PortCollection of the ServiceDescription.
     myDescription.Services[0].Ports.Add(postPort);
// </Snippet5>
// </Snippet1>
     // Create a 'PortType' object.
     PortType postPortType = new PortType();
     postPortType.Name = "PortServiceHttpPost";
     Operation postOperation = new Operation();
     postOperation.Name = "AddNumbers";
     OperationMessage postInput = (OperationMessage)new OperationInput();
     postInput.Message =  new XmlQualifiedName("s0:AddNumbersHttpPostIn");
     OperationMessage postOutput = (OperationMessage)new OperationOutput();
     postOutput.Message = new XmlQualifiedName("s0:AddNumbersHttpPostOut");
     postOperation.Messages.Add(postInput);
     postOperation.Messages.Add(postOutput);
     // Add the 'Operation' to 'PortType'.
     postPortType.Operations.Add(postOperation);
     // Adds the 'PortType' to 'PortTypeCollection' of 'ServiceDescription'.
     myDescription.PortTypes.Add(postPortType);
     // Create  the 'Message' object.
     Message postMessage1 = new Message();
     postMessage1.Name="AddNumbersHttpPostIn";
     // Create the 'MessageParts'.
     MessagePart postMessagePart1 = new MessagePart();
     postMessagePart1.Name = "firstnumber";
     postMessagePart1.Type = new XmlQualifiedName("s:string");
     MessagePart postMessagePart2 = new MessagePart();
     postMessagePart2.Name = "secondnumber";
     postMessagePart2.Type = new XmlQualifiedName("s:string");
     // Add the 'MessagePart' objects to 'Messages'.
     postMessage1.Parts.Add(postMessagePart1);
     postMessage1.Parts.Add(postMessagePart2);
     // Create another 'Message' object.
     Message postMessage2 = new Message();
     postMessage2.Name = "AddNumbersHttpPostOut";
     MessagePart postMessagePart3 = new MessagePart();
     postMessagePart3.Name = "Body";
     postMessagePart3.Element = new XmlQualifiedName("s0:int");
     // Add the 'MessagePart' to 'Message'
     postMessage2.Parts.Add(postMessagePart3);
     // Add the 'Message' objects to 'ServiceDescription'.
     myDescription.Messages.Add(postMessage1);
     myDescription.Messages.Add(postMessage2);
     // Write the 'ServiceDescription' as a WSDL file.
     myDescription.Write("AddNumbersOne.wsdl");
     Console.WriteLine("WSDL file with name 'AddNumbersOne.Wsdl' file created Successfully");
    }

    catch (Exception ex)
    {
     Console.WriteLine("Exception " + ex.Message + " occurred");
    }
   }
}

