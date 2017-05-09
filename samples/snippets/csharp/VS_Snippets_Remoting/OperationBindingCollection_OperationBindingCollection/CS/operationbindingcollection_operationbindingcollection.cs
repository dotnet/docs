// System.Web.Services.Description.OperationBindingCollection
// System.Web.Services.Description.OperationBindingCollection.Contains
// System.Web.Services.Description.OperationBindingCollection.Add
// System.Web.Services.Description.OperationBindingCollection.Item
// System.Web.Services.Description.OperationBindingCollection.Remove
// System.Web.Services.Description.OperationBindingCollection.Insert
// System.Web.Services.Description.OperationBindingCollection.IndexOf
// System.Web.Services.Description.OperationBindingCollection.CopyTo

/* 
   The following example demonstrates the usage of the
   'OperationBindingCollection' class, the 'Item' property and various methods of the
   class. The input to the program is a WSDL file 'MathService_input_cs.wsdl' without 
   the add operation binding of SOAP protocol. In this example the WSDL file
   is modified to insert a new 'OperationBinding' for SOAP. The 
   'OperationBindingCollection' is populated based on WSDL document
   structure defined in WSDL specification. The updated instance is then
   written to 'MathService_new_cs.wsdl'.
*/

// <Snippet1>
using System;
using System.Web.Services.Description;

class MyOperationBindingCollectionSample
{
   static void Main()
   {
      try
      {
         ServiceDescription myServiceDescription =
            ServiceDescription.Read("MathService_input_cs.wsdl");

         // Add the OperationBinding for the Add operation.
         OperationBinding addOperationBinding = new OperationBinding();
         string addOperation = "Add";
         string myTargetNamespace = myServiceDescription.TargetNamespace;
         addOperationBinding.Name = addOperation;

         // Add the InputBinding for the operation.
         InputBinding myInputBinding = new InputBinding();
         SoapBodyBinding mySoapBodyBinding = new SoapBodyBinding();
         mySoapBodyBinding.Use = SoapBindingUse.Literal;
         myInputBinding.Extensions.Add(mySoapBodyBinding);
         addOperationBinding.Input = myInputBinding;

         // Add the OutputBinding for the operation.
         OutputBinding myOutputBinding = new OutputBinding();
         myOutputBinding.Extensions.Add(mySoapBodyBinding);
         addOperationBinding.Output = myOutputBinding;

         // Add the extensibility element for the SoapOperationBinding.
         SoapOperationBinding mySoapOperationBinding = 
            new SoapOperationBinding();
         mySoapOperationBinding.Style = SoapBindingStyle.Document;
         mySoapOperationBinding.SoapAction = myTargetNamespace + addOperation;
         addOperationBinding.Extensions.Add(mySoapOperationBinding);

         // Get the BindingCollection from the ServiceDescription.
         BindingCollection myBindingCollection = 
            myServiceDescription.Bindings;

         // Get the OperationBindingCollection of SOAP binding from 
         // the BindingCollection.
         OperationBindingCollection myOperationBindingCollection = 
            myBindingCollection[0].Operations;

// <Snippet2> 
         // Check for the Add OperationBinding in the collection.
         bool contains = myOperationBindingCollection.Contains
            (addOperationBinding);
         Console.WriteLine("\nWhether the collection contains the Add " +
            "OperationBinding : " + contains);
// </Snippet2>

// <Snippet3>
         // Add the Add OperationBinding to the collection.
         myOperationBindingCollection.Add(addOperationBinding);
         Console.WriteLine("\nAdded the OperationBinding of the Add" +
            " operation to the collection.");
// </Snippet3>

// <Snippet4>
// <Snippet5>
         // Get the OperationBinding of the Add operation from the collection.
         OperationBinding myOperationBinding = 
            myOperationBindingCollection[3];

         // Remove the OperationBinding of the Add operation from 
         // the collection.
         myOperationBindingCollection.Remove(myOperationBinding);
         Console.WriteLine("\nRemoved the OperationBinding of the " +
            "Add operation from the collection.");
// </Snippet5>
// </Snippet4> 

// <Snippet6>
// <Snippet7>
         // Insert the OperationBinding of the Add operation at index 0.
         myOperationBindingCollection.Insert(0, addOperationBinding);
         Console.WriteLine("\nInserted the OperationBinding of the " +
            "Add operation in the collection.");

         // Get the index of the OperationBinding of the Add
         // operation from the collection.
         int index = myOperationBindingCollection.IndexOf(addOperationBinding);
         Console.WriteLine("\nThe index of the OperationBinding of the " +
            "Add operation : " + index);
// </Snippet7>
// </Snippet6>
         Console.WriteLine("");

// <Snippet8>
         OperationBinding[] operationBindingArray = new
            OperationBinding[myOperationBindingCollection.Count];

         // Copy this collection to the OperationBinding array.
         myOperationBindingCollection.CopyTo(operationBindingArray, 0);
         Console.WriteLine("The operations supported by this service " +
            "are :");
         foreach(OperationBinding myOperationBinding1 in 
            operationBindingArray)
         {
            Binding myBinding = myOperationBinding1.Binding;
            Console.WriteLine(" Binding : "+ myBinding.Name + " Name of " +
               "operation : " + myOperationBinding1.Name);
         }
// </Snippet8>

         // Save the ServiceDescription to an external file.
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
