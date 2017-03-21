      // Check whether the ErrorInfo property of the RegistrationException object is null. 
      // If there is no extended error information about 
      // methods related to multiple COM+ objects ErrorInfo will be null.
      if ( e->ErrorInfo != nullptr )
      {
         // Gets an array of RegistrationErrorInfo objects describing registration errors
         array<RegistrationErrorInfo^>^ registrationErrorInfos = e->ErrorInfo;
         
         // Iterate through the array of RegistrationErrorInfo objects and disply the 
         // ErrorString for each object.
         System::Collections::IEnumerator^ myEnum = registrationErrorInfos->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            RegistrationErrorInfo^ registrationErrorInfo = (RegistrationErrorInfo^)( myEnum->Current );
            Console::WriteLine( registrationErrorInfo->ErrorString );
         }
      }