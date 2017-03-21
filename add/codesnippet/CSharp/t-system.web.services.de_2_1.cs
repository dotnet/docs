   // Used to create OperationBinding instances within 'Binding'.
   public static OperationBinding CreateOperationBinding(string operation,
      string targetNamespace)
   {
      // Create OperationBinding for operation.
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

      // Add InputBinding and OutputBinding to OperationBinding.
      myOperationBinding.Input = myInputBinding;
      myOperationBinding.Output = myOutputBinding;

      // Create an extensibility element for SoapOperationBinding.
      SoapOperationBinding mySoapOperationBinding = new SoapOperationBinding();
      mySoapOperationBinding.Style = SoapBindingStyle.Document;
      mySoapOperationBinding.SoapAction = targetNamespace + operation;

      // Add the extensibility element SoapOperationBinding to OperationBinding.
      myOperationBinding.Extensions.Add(mySoapOperationBinding);
      return myOperationBinding;
   }