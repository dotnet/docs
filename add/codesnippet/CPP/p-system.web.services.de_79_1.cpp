      // Create an InputBinding.
      InputBinding^ myInputBinding = gcnew InputBinding;
      MimeTextBinding^ myMimeTextBinding = gcnew MimeTextBinding;
      MimeTextMatchCollection^ myMimeTextMatchCollection1 = gcnew MimeTextMatchCollection;
      array<MimeTextMatch^>^myMimeTextMatch = gcnew array<MimeTextMatch^>(3);
      myMimeTextMatchCollection1 = myMimeTextBinding->Matches;

      // Intialize the MimeTextMatch.
      for ( myInt = 0; myInt < 3; myInt++ )
      {
         // Get a new MimeTextMatch.
         myMimeTextMatch[ myInt ] = gcnew MimeTextMatch;

         // Assign values to properties of the MimeTextMatch.
         myMimeTextMatch[ myInt ]->Name = String::Format( "Title{0}", Convert::ToString( myInt ) );
         myMimeTextMatch[ myInt ]->Type = "*/*";
         myMimeTextMatch[ myInt ]->Pattern = "TITLE&gt;(.*?)&lt;";
         myMimeTextMatch[ myInt ]->IgnoreCase = true;
         myMimeTextMatch[ myInt ]->Capture = 2;
         myMimeTextMatch[ myInt ]->Group = 2;
         if ( myInt != 0 )
         {
            
            // Assign the Repeats property if the index is not 0.
            myMimeTextMatch[ myInt ]->Repeats = 2;
         }
         else
         {
            
            // Assign the RepeatsString property if the index is 0.
            myMimeTextMatch[ myInt ]->RepeatsString = "4";
         }
         myMimeTextMatchCollection1->Add( myMimeTextMatch[ myInt ] );

      }