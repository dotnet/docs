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

         // Create an OperationBinding for the Add operation.
         OperationBinding addOperationBinding = new OperationBinding();
         string addOperation = "Add";
         addOperationBinding.Name = addOperation;

         // Create an InputBinding for the Add operation.
         InputBinding myInputBinding = new InputBinding();
         SoapBodyBinding mySoapBodyBinding = new SoapBodyBinding();
         mySoapBodyBinding.Use = SoapBindingUse.Literal;
         myInputBinding.Extensions.Add(mySoapBodyBinding);

         // Add the InputBinding to the OperationBinding.
         addOperationBinding.Input = myInputBinding;

         // Create an OutputBinding for the Add operation.
         OutputBinding myOutputBinding = new OutputBinding();
         myOutputBinding.Extensions.Add(mySoapBodyBinding);

         // Add the OutputBinding to the OperationBinding. 
         addOperationBinding.Output = myOutputBinding;

         // Create an extensibility element for a SoapOperationBinding.
         SoapOperationBinding mySoapOperationBinding = 
            new SoapOperationBinding();
         mySoapOperationBinding.Style = SoapBindingStyle.Document;
         mySoapOperationBinding.SoapAction = myTargetNamespace + addOperation;

         // Add the extensibility element SoapOperationBinding to 
         // the OperationBinding.
         addOperationBinding.Extensions.Add(mySoapOperationBinding);

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
            Binding myBinding = myOperationBinding.Binding;
            Console.WriteLine(" Binding : " + myBinding.Name +
               " :: Name of operation : " + myOperationBinding.Name);
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