         // Create an extensibility element for a SoapOperationBinding.
         SoapOperationBinding mySoapOperationBinding = 
            new SoapOperationBinding();
         mySoapOperationBinding.Style = SoapBindingStyle.Document;
         mySoapOperationBinding.SoapAction = myTargetNamespace + addOperation;

         // Add the extensibility element SoapOperationBinding to 
         // the OperationBinding.
         addOperationBinding.Extensions.Add(mySoapOperationBinding);