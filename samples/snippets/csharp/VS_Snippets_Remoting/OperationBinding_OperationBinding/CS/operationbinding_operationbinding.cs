// System.Web.Services.Description.OperationBinding
// System.Web.Services.Description.OperationBinding.OperationBinding
// System.Web.Services.Description.OperationBinding.Name
// System.Web.Services.Description.OperationBinding.Input
// System.Web.Services.Description.OperationBinding.Output
// System.Web.Services.Description.OperationBinding.Extensions
// System.Web.Services.Description.OperationBinding.Faults
// System.Web.Services.Description.OperationBinding.Binding

/*
   The following example demonstrates the usage of the 'OperationBinding'
   class, constructor 'OperationBinding()' and various properties of the class. The
   input to the program is a WSDL file 'MathService_input_cs.wsdl' without the
   add operation binding for SOAP protocol. In the example the WSDL file is modified to insert 
   a new 'OperationBinding' instance for SOAP. The 'OperationBinding' instance 
   is populated based on WSDL document structure defined in WSDL specification.The updated 
   instance is then written to 'MathService_new_cs.wsdl'.
*/

// <Snippet1>
using System;
using System.Web.Services.Description;

class MyOperationBindingSample
{
   static void Main()
   {
      try
      {
         ServiceDescription myServiceDescription =
            ServiceDescription.Read("MathService_input_cs.wsdl");
         string myTargetNamespace = myServiceDescription.TargetNamespace;

// <Snippet2>
// <Snippet3>
         // Create an OperationBinding for the Add operation.
         OperationBinding addOperationBinding = new OperationBinding();
         string addOperation = "Add";
         addOperationBinding.Name = addOperation;
// </Snippet3>

// <Snippet4>
         // Create an InputBinding for the Add operation.
         InputBinding myInputBinding = new InputBinding();
         SoapBodyBinding mySoapBodyBinding = new SoapBodyBinding();
         mySoapBodyBinding.Use = SoapBindingUse.Literal;
         myInputBinding.Extensions.Add(mySoapBodyBinding);

         // Add the InputBinding to the OperationBinding.
         addOperationBinding.Input = myInputBinding;
// </Snippet4>

// <Snippet5>
         // Create an OutputBinding for the Add operation.
         OutputBinding myOutputBinding = new OutputBinding();
         myOutputBinding.Extensions.Add(mySoapBodyBinding);

         // Add the OutputBinding to the OperationBinding. 
         addOperationBinding.Output = myOutputBinding;
// </Snippet5>

// <Snippet6>
         // Create an extensibility element for a SoapOperationBinding.
         SoapOperationBinding mySoapOperationBinding = 
            new SoapOperationBinding();
         mySoapOperationBinding.Style = SoapBindingStyle.Document;
         mySoapOperationBinding.SoapAction = myTargetNamespace + addOperation;

         // Add the extensibility element SoapOperationBinding to 
         // the OperationBinding.
         addOperationBinding.Extensions.Add(mySoapOperationBinding);
// </Snippet6>
// </Snippet2>

// <Snippet7>
         ServiceDescriptionFormatExtensionCollection myExtensions;

         // Get the FaultBindingCollection from the OperationBinding.
         FaultBindingCollection myFaultBindingCollection =
            addOperationBinding.Faults;
         FaultBinding myFaultBinding = new FaultBinding();
         myFaultBinding.Name = "ErrorFloat";

         // Associate SOAP fault binding to the fault binding of the operation.
         myExtensions = myFaultBinding.Extensions;
         SoapFaultBinding mySoapFaultBinding = new SoapFaultBinding();
         mySoapFaultBinding.Use = SoapBindingUse.Literal;
         mySoapFaultBinding.Namespace = myTargetNamespace;
         myExtensions.Add(mySoapFaultBinding);
         myFaultBindingCollection.Add(myFaultBinding);
// </Snippet7>

         // Get the BindingCollection from the ServiceDescription.
         BindingCollection myBindingCollection = 
            myServiceDescription.Bindings;

         // Get the OperationBindingCollection of SOAP binding 
         // from the BindingCollection.
         OperationBindingCollection myOperationBindingCollection = 
            myBindingCollection[0].Operations;
         myOperationBindingCollection.Add(addOperationBinding);

         Console.WriteLine(
            "The operations supported by this service are:");
         foreach(OperationBinding myOperationBinding in 
            myOperationBindingCollection)
         {
// <Snippet8>
            Binding myBinding = myOperationBinding.Binding;
            Console.WriteLine(" Binding : " + myBinding.Name +
               " :: Name of operation : " + myOperationBinding.Name);
// </Snippet8>
            FaultBindingCollection myFaultBindingCollection1 = 
               myOperationBinding.Faults;
            foreach(FaultBinding myFaultBinding1 in 
               myFaultBindingCollection1)
            {
                 Console.WriteLine("    Fault : " + myFaultBinding1.Name);
            }
         }
         // Save the ServiceDescripition to an external file.
         myServiceDescription.Write("MathService_new_cs.wsdl");
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
