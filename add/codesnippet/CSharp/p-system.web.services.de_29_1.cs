         // Create an InputBinding for the Add operation.
         InputBinding myInputBinding = new InputBinding();
         SoapBodyBinding mySoapBodyBinding = new SoapBodyBinding();
         mySoapBodyBinding.Use = SoapBindingUse.Literal;
         myInputBinding.Extensions.Add(mySoapBodyBinding);

         // Add the InputBinding to the OperationBinding.
         addOperationBinding.Input = myInputBinding;