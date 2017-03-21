      // Check to see whether the collection contains mySecondSoapHeader.
      if ( mySoapHeaderCollection->Contains( mySecondSoapHeader ) )
      {
         // Get the index of mySecondSoapHeader from the collection.
         Console::WriteLine( "Index of mySecondSoapHeader: {0}", mySoapHeaderCollection->IndexOf( mySecondSoapHeader ) );

         // Get the SoapHeader from the collection.
         MySoapHeader^ mySoapHeader1 = dynamic_cast<MySoapHeader^>(mySoapHeaderCollection[ mySoapHeaderCollection->IndexOf( mySecondSoapHeader ) ]);
         Console::WriteLine( "SoapHeader retrieved from the collection: {0}", mySoapHeader1 );

         // Remove a SoapHeader from the collection.
         mySoapHeaderCollection->Remove( mySoapHeader1 );
         Console::WriteLine( "Number of items after removal: {0}", mySoapHeaderCollection->Count );
      }
      else
            Console::WriteLine( "mySoapHeaderCollection does not contain mySecondSoapHeader." );