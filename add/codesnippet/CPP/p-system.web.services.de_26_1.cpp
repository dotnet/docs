      // Create a new instance of 'SoapFaultBinding' class.
      SoapFaultBinding^ mySoapFaultBinding = gcnew SoapFaultBinding;

      // Encode fault message using rules specified by 'Encoding' property.
      mySoapFaultBinding->Use = SoapBindingUse::Encoded;

      // Set the URI representing the encoding style.
      mySoapFaultBinding->Encoding = "http://tempuri.org/stockquote";

      // Set the URI representing the location of the specification
      // for encoding of content not defined by 'Encoding' property'.
      mySoapFaultBinding->Namespace = "http://tempuri.org/stockquote";

      // Create a new instance of 'FaultBinding'.
      FaultBinding^ myFaultBinding = gcnew FaultBinding;
      myFaultBinding->Name = "AddFaultbinding";
      myFaultBinding->Extensions->Add( mySoapFaultBinding );

      // Get existing 'OperationBinding' object.
      myOperationBinding->Faults->Add( myFaultBinding );
      myBinding->Operations->Add( myOperationBinding );
      