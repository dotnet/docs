      SoapBinding^ mySoapBinding1 = gcnew SoapBinding;
      SoapBinding^ mySoapBinding2 = gcnew SoapBinding;
      SoapAddressBinding^ mySoapAddressBinding = gcnew SoapAddressBinding;
      MyFormatExtension^ myFormatExtensionObject = gcnew MyFormatExtension;

      // Add elements to collection.
      myCollection->Add( mySoapBinding1 );
      myCollection->Add( mySoapAddressBinding );
      myCollection->Add( mySoapBinding2 );
      myCollection->Add( myFormatExtensionObject );