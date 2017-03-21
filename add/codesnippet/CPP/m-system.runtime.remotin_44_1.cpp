   // Array of Headers with name and values initialized.
   array<Header^>^ myArrSetHeader = { gcnew Header( "Header0","CallContextHeader0" ),
      gcnew Header( "Header1","CallContextHeader1" ) };

   // Pass the Header Array with method call.
   // Header will be set in the method by'CallContext::SetHeaders' method in remote Object*.
   Console::WriteLine( "Remote HeaderMethod output is {0}",
      myService->HeaderMethod( "CallContextHeader", myArrSetHeader ) );

   array<Header^>^ myArrGetHeader;
   // Get Header Array.
   myArrGetHeader = CallContext::GetHeaders();
   if ( nullptr == myArrGetHeader )
   {
      Console::WriteLine( "CallContext::GetHeaders Failed" );
   }
   else
   {
      Console::WriteLine( "Headers:" );
   }

   for each ( Header^ myHeader in myArrGetHeader )
   {
      Console::WriteLine( "Value in Header '{0}' is '{1}'.",
         myHeader->Name, myHeader->Value );
   }