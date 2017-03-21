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
     
     // Value isInputBinding = true ---> return type = InputBinding.  
     // Value isInputBinding = false --> return type = OutputBinding.
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
      myMessageBinding.Name = myBindName;
      SoapBodyBinding mySoapBodyBinding = new SoapBodyBinding();
      mySoapBodyBinding.Use = SoapBindingUse.Literal;
      myMessageBinding.Extensions.Add(mySoapBodyBinding);
      Console.WriteLine("Added extensibility element of type : " + 
         mySoapBodyBinding.GetType());
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