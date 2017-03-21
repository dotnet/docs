      // Get an instance of 'MimeTextMatchCollection'.
      MimeTextMatchCollection^ myMimeTextMatchCollection1 = gcnew MimeTextMatchCollection;
      array<MimeTextMatch^>^myMimeTextMatch1 = gcnew array<MimeTextMatch^>(5);
      myMimeTextMatchCollection1 = myMimeTextBinding1->Matches;
      for ( myInt = 0; myInt < 4; myInt++ )
      {
         myMimeTextMatch1[ myInt ] = gcnew MimeTextMatch;
         myMimeTextMatch1[ myInt ]->Name = String::Format( "Title{0}", Convert::ToString( myInt ) );
         if ( myInt != 0 )
         {
            myMimeTextMatch1[ myInt ]->RepeatsString = "7";
         }
         myMimeTextMatchCollection1->Add( myMimeTextMatch1[ myInt ] );
      }
      myMimeTextMatch1[ 4 ] = gcnew MimeTextMatch;
      
      // Remove 'MimeTextMatch' instance from collection.
      myMimeTextMatchCollection1->Remove( myMimeTextMatch1[ 1 ] );
      
      // Using MimeTextMatchCollection.Item indexer to comapre. 
      if ( myMimeTextMatch1[ 2 ] == myMimeTextMatchCollection1[ 1 ] )
      {
         // Check whether 'MimeTextMatch' instance exists. 
         myInt = myMimeTextMatchCollection1->IndexOf( myMimeTextMatch1[ 2 ] );

         // Insert 'MimeTextMatch' instance at a desired position.
         myMimeTextMatchCollection1->Insert( 1, myMimeTextMatch1[ myInt ] );
         myMimeTextMatchCollection1[ 1 ]->RepeatsString = "5";
         myMimeTextMatchCollection1->Insert( 4, myMimeTextMatch1[ myInt ] );
      }