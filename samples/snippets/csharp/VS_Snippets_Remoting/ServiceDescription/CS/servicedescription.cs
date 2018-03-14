// System.Web.Services.Description.ServiceDescription


/* 
   The following example demonstrates the 'ServiceDescription' class.
   The input to the program is a WSDL file 'MyWsdl.wsdl'.
   This program removes one 'Binding' from the existing WSDL.
   A new Binding is defined and added to the ServiceDescription object.
   The program generates a new Web Service Description document.
*/

using System;
using System.Web.Services;
using System.Web.Services.Description;
using System.Xml;

namespace ServiceDescription1
{
   class MyService
   {
      static void Main()
      {
      try
      {
// <Snippet1>
         // Obtain the ServiceDescription of existing Wsdl.
         ServiceDescription myDescription = ServiceDescription.Read("MyWsdl_CS.wsdl");
         // Remove the Binding from the Binding Collection of ServiceDescription.
         BindingCollection myBindingCollection = myDescription.Bindings;
         myBindingCollection.Remove(myBindingCollection[0]);
         
         // Form a new Binding.
         Binding myBinding = new Binding();
         myBinding.Name = "Service1Soap";
         XmlQualifiedName myXmlQualifiedName = 
                              new XmlQualifiedName("s0:Service1Soap");
         myBinding.Type = myXmlQualifiedName;

         SoapBinding mySoapBinding = new SoapBinding();
         mySoapBinding.Transport = "http://schemas.xmlsoap.org/soap/http";
         mySoapBinding.Style = SoapBindingStyle.Document;

         OperationBinding addOperationBinding = 
                CreateOperationBinding("Add",myDescription.TargetNamespace);
         myBinding.Operations.Add(addOperationBinding);
         myBinding.Extensions.Add(mySoapBinding);

         // Add the Binding to the ServiceDescription.
         myDescription.Bindings.Add(myBinding);
         myDescription.Write("MyOutWsdl.wsdl");
// </Snippet1>
      }
      catch(Exception e)
      {
        Console.WriteLine("Exception :" + e.Message);
      }
      }
      // Used to create OperationBinding instances within 'Binding'.
      public static OperationBinding CreateOperationBinding(string operation, string targetNamespace)
      {
         // Create OperationBinding instance for operation.
         OperationBinding myOperationBinding = new OperationBinding();
         myOperationBinding.Name = operation;
         // Create InputBinding for operation.
         InputBinding myInputBinding = new InputBinding();
         SoapBodyBinding mySoapBodyBinding = new SoapBodyBinding();
         mySoapBodyBinding.Use = SoapBindingUse.Literal;
         myInputBinding.Extensions.Add(mySoapBodyBinding);
         // Create OutputBinding for operation.
         OutputBinding myOutputBinding = new OutputBinding();
         myOutputBinding.Extensions.Add(mySoapBodyBinding);
         // Add 'InputBinding' and 'OutputBinding' to 'OperationBinding'. 
         myOperationBinding.Input = myInputBinding;
         myOperationBinding.Output = myOutputBinding;
         // Create extensibility element for 'SoapOperationBinding'.
         SoapOperationBinding mySoapOperationBinding = new SoapOperationBinding();
         mySoapOperationBinding.Style = SoapBindingStyle.Document;
         mySoapOperationBinding.SoapAction = targetNamespace + operation;
         // Add extensibility element 'SoapOperationBinding' to 'OperationBinding'.
         myOperationBinding.Extensions.Add(mySoapOperationBinding);
         return myOperationBinding;
      }
   }
}

