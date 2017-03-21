      // Create an InputBinding for the Add operation.
      InputBinding^ myInputBinding = gcnew InputBinding;
      SoapBodyBinding^ mySoapBodyBinding = gcnew SoapBodyBinding;
      mySoapBodyBinding->Use = SoapBindingUse::Literal;
      myInputBinding->Extensions->Add( mySoapBodyBinding );

      // Add the InputBinding to the OperationBinding.
      addOperationBinding->Input = myInputBinding;