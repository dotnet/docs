   // Used to create OperationBinding instances within 'Binding'.
   static OperationBinding^ CreateOperationBinding( String^ operation, String^ targetNamespace )
   {
      // Create OperationBinding for operation.
      OperationBinding^ myOperationBinding = gcnew OperationBinding;
      myOperationBinding->Name = operation;

      // Create InputBinding for operation.
      InputBinding^ myInputBinding = gcnew InputBinding;
      SoapBodyBinding^ mySoapBodyBinding = gcnew SoapBodyBinding;
      mySoapBodyBinding->Use = SoapBindingUse::Literal;
      myInputBinding->Extensions->Add( mySoapBodyBinding );

      // Create OutputBinding for operation.
      OutputBinding^ myOutputBinding = gcnew OutputBinding;
      myOutputBinding->Extensions->Add( mySoapBodyBinding );

      // Add InputBinding and OutputBinding to OperationBinding.
      myOperationBinding->Input = myInputBinding;
      myOperationBinding->Output = myOutputBinding;

      // Create an extensibility element for SoapOperationBinding.
      SoapOperationBinding^ mySoapOperationBinding = gcnew SoapOperationBinding;
      mySoapOperationBinding->Style = SoapBindingStyle::Document;
      mySoapOperationBinding->SoapAction = String::Concat( targetNamespace, operation );

      // Add the extensibility element SoapOperationBinding to OperationBinding.
      myOperationBinding->Extensions->Add( mySoapOperationBinding );
      return myOperationBinding;
   }