      // Check element of type 'SoapAddressBinding' in collection.
      Object^ myObj = myCollection->Find( mySoapAddressBinding->GetType() );
      if ( myObj == nullptr )
            Console::WriteLine( "Element of type ' {0}' not found in collection.", mySoapAddressBinding->GetType() );
      else
            Console::WriteLine( "Element of type ' {0}' found in collection.", mySoapAddressBinding->GetType() );