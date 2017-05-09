// System.Web.Services.Description.Operation.IsBoundBy

/* The following program demonstrates the 'IsBoundBy' method of 
   'Operation' class. It takes "Operation_IsBoundBy_Input_CS.wsdl"
   as input which does not contain 'PortType' and 'Binding' objects
   supporting 'HttpPost'.It then adds those objects and writes into
   'Operation_IsBoundBy_Output_CS.wsdl'.
*/

using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

class MyOperationClass 
{
   public static void Main()
   {
      ServiceDescription myServiceDescription = ServiceDescription.Read("Operation_IsBoundBy_Input_CS.wsdl");
      // Create the 'Binding' object.
      Binding myBinding = new Binding();
      myBinding.Name = "MyOperationIsBoundByServiceHttpPost";
      XmlQualifiedName myXmlQualifiedName = new XmlQualifiedName("s0:OperationServiceHttpPost");
      myBinding.Type = myXmlQualifiedName;
      // Create the 'HttpBinding' object.
      HttpBinding myHttpBinding = new HttpBinding();
      myHttpBinding.Verb="POST";
      // Add the 'HttpBinding' to the 'Binding'.
      myBinding.Extensions.Add(myHttpBinding);
      // Create the 'OperationBinding' object.
      OperationBinding myOperationBinding = new OperationBinding();
      myOperationBinding.Name = "AddNumbers";

      HttpOperationBinding myHttpOperationBinding = new HttpOperationBinding();
      myHttpOperationBinding.Location="/AddNumbers";
      // Add the 'HttpOperationBinding' to 'OperationBinding'.
      myOperationBinding.Extensions.Add(myHttpOperationBinding);
            
      // Create the 'InputBinding' object.
      InputBinding myInputBinding = new InputBinding();
      MimeContentBinding myPostMimeContentBinding = new MimeContentBinding();
      myPostMimeContentBinding.Type="application/x-www-form-urlencoded";
      myInputBinding.Extensions.Add(myPostMimeContentBinding);
      // Add the 'InputBinding' to 'OperationBinding'.
      myOperationBinding.Input = myInputBinding;
      // Create the 'OutputBinding' object.
      OutputBinding myOutputBinding = new OutputBinding();
      MimeXmlBinding myPostMimeXmlBinding = new MimeXmlBinding();
      myPostMimeXmlBinding .Part="Body";
      myOutputBinding.Extensions.Add(myPostMimeXmlBinding);

      // Add the 'OutPutBinding' to 'OperationBinding'.
      myOperationBinding.Output = myOutputBinding; 

      // Add the 'OperationBinding' to 'Binding'.
      myBinding.Operations.Add(myOperationBinding);
         
      // Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
      myServiceDescription.Bindings.Add(myBinding);

      // Create a a 'PortType' object.
      PortType myPostPortType = new PortType();
      myPostPortType.Name = "OperationServiceHttpPost";
// <Snippet1>
      Operation myPostOperation = new Operation();
      myPostOperation.Name = myOperationBinding.Name;
      Console.WriteLine("'Operation' instance uses 'OperationBinding': " 
         +myPostOperation.IsBoundBy(myOperationBinding));
// </Snippet1>
      OperationMessage myOperationMessage = (OperationMessage)new OperationInput();
      myOperationMessage.Message =  new XmlQualifiedName("s0:AddNumbersHttpPostIn");
      OperationMessage myOperationMessage1 = (OperationMessage)new OperationOutput();
      myOperationMessage1.Message = new XmlQualifiedName("s0:AddNumbersHttpPostOut");

      myPostOperation.Messages.Add(myOperationMessage);
      myPostOperation.Messages.Add(myOperationMessage1);

      // Add the 'Operation' to 'PortType'.
      myPostPortType.Operations.Add(myPostOperation);

      // Adds the 'PortType' to 'PortTypeCollection' of 'ServiceDescription'.
      myServiceDescription.PortTypes.Add(myPostPortType);
      
      // Write the 'ServiceDescription' as a WSDL file.
      myServiceDescription.Write("Operation_IsBoundBy_Output_CS.wsdl");
      Console.WriteLine("WSDL file with name 'Operation_IsBoundBy_Output_CS.wsdl' created Successfully");
   }
}