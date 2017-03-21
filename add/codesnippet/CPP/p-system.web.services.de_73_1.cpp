   // Create the 'SoapOperationBinding' object for the 'SOAP' protocol.
   SoapOperationBinding^ mySoapOperationBinding = gcnew SoapOperationBinding;
   mySoapOperationBinding->SoapAction = "http://tempuri.org/AddNumbers";
   mySoapOperationBinding->Style = SoapBindingStyle::Document;

   // Add the 'SoapOperationBinding' object to 'OperationBinding' object.
   myOperationBinding->Extensions->Add( mySoapOperationBinding );