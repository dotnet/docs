      // Create an extensibility element for a SoapOperationBinding.
      SoapOperationBinding^ mySoapOperationBinding = gcnew SoapOperationBinding;
      mySoapOperationBinding->Style = SoapBindingStyle::Document;
      mySoapOperationBinding->SoapAction = String::Concat( myTargetNamespace, addOperation );

      // Add the extensibility element SoapOperationBinding to 
      // the OperationBinding.
      addOperationBinding->Extensions->Add( mySoapOperationBinding );