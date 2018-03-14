// System.Web.Services.Description.MessageBinding
// System.Web.Services.Description.MessageBinding.MessageBinding();
// System.Web.Services.Description.MessageBinding.Extensions;
// System.Web.Services.Description.MessageBinding.Name;

/* The following program demonstrates the abstract class 'MessageBinding', it's constructor MessageBinding()
  and properties 'Extensions' and 'Name'.
  'MessageBinding' is an abstract class from which 'InputBinding' , 'OutputBinding' are derived.
  The program contains a utility function which could be used to create either an InputBinding or OutputBinding.
  This generic nature is achieved by returning an instance of 'MessageBinding'. 
 */
// <Snippet1>
using System;
using System.Web.Services.Description;
class MyClass
{
   public static void Main()
   {
   OperationBinding addOperationBinding = 
      CreateOperationBinding("Add","http://tempuri.org/");
   }

   public static MessageBinding CreateInputOutputBinding(string myBindName,
      bool isInputBinding)
   {
// <Snippet2>     
     
     // Value isInputBinding = true ---> return type = InputBinding.  
     // Value isInputBinding = false --> return type = OutputBinding.
// <Snippet3>
// <Snippet4>
     MessageBinding myMessageBinding = null;
      switch(isInputBinding)
      {
         case true:
            myMessageBinding = new InputBinding();
            Console.WriteLine("Added an InputBinding");
            break;
         case false:
            myMessageBinding = new OutputBinding();
            Console.WriteLine("Added an OutputBinding");
            break;
      }
// </Snippet2>
      myMessageBinding.Name = myBindName;
      SoapBodyBinding mySoapBodyBinding = new SoapBodyBinding();
      mySoapBodyBinding.Use = SoapBindingUse.Literal;
      myMessageBinding.Extensions.Add(mySoapBodyBinding);
      Console.WriteLine("Added extensibility element of type : " + 
         mySoapBodyBinding.GetType());
// </Snippet3>
// </Snippet4>
      return myMessageBinding;
   }

   // Used to create OperationBinding instances within Binding.
   public static OperationBinding CreateOperationBinding(
      string myOperation,string targetNamespace)
   {
      // Create OperationBinding for Operation.
      OperationBinding myOperationBinding = new OperationBinding();
      myOperationBinding.Name = myOperation;

      // Create InputBinding for operation.
      InputBinding myInputBinding = 
        (InputBinding)CreateInputOutputBinding(null,true);

      // Create OutputBinding for operation.
      OutputBinding myOutputBinding = 
         (OutputBinding)CreateInputOutputBinding(null,false);
      
      // Add InputBinding and OutputBinding to OperationBinding. 
      myOperationBinding.Input = myInputBinding;
      myOperationBinding.Output = myOutputBinding;
      
      // Create an extensibility element for SoapOperationBinding.
      SoapOperationBinding mySoapOperationBinding = new SoapOperationBinding();
      mySoapOperationBinding.Style = SoapBindingStyle.Document;
      mySoapOperationBinding.SoapAction = targetNamespace + myOperation;

      // Add the extensibility element SoapOperationBinding to OperationBinding.
      myOperationBinding.Extensions.Add(mySoapOperationBinding);
      return myOperationBinding;
   }
}
// </Snippet1>
