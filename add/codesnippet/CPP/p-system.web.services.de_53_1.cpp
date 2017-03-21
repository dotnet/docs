   SoapBodyBinding^ mySoapBodyBinding = gcnew SoapBodyBinding;
   // Encode SOAP body using rules specified by the 'Encoding' property.
   mySoapBodyBinding->Use = SoapBindingUse::Encoded;
   // Set URI representing the encoding style for encoding the body.
   mySoapBodyBinding->Encoding = "http://schemas.xmlsoap.org/soap/encoding/";
   // Set the Uri representing the location of the specification
   // for encoding of content not defined by 'Encoding' property'.
   mySoapBodyBinding->Namespace = "http://tempuri.org/soapsvcmgr/";
   myInputBinding->Extensions->Add( mySoapBodyBinding );