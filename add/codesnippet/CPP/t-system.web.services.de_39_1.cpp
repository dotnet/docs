   // Create the 'HttpAddressBinding' object.
   HttpAddressBinding^ postAddressBinding = gcnew HttpAddressBinding;
   postAddressBinding->Location = "http://localhost/Service1.asmx";

   // Add the 'HttpAddressBinding' to the 'Port'.
   postPort->Extensions->Add( postAddressBinding );