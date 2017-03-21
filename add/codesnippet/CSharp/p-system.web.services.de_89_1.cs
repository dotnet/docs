         // Get an instance of 'MimeTextMatchCollection'.
         MimeTextMatchCollection myMimeTextMatchCollection1 = new MimeTextMatchCollection();
         MimeTextMatch[] myMimeTextMatch1 = new MimeTextMatch[5];
         myMimeTextMatchCollection1 = myMimeTextBinding1.Matches;
         for( myInt = 0 ; myInt < 4 ; myInt++ )
         {
            myMimeTextMatch1[ myInt ]  = new MimeTextMatch();
            myMimeTextMatch1[ myInt ].Name = "Title" + Convert.ToString( myInt );
            if( myInt != 0 )
            {
               myMimeTextMatch1[ myInt ].RepeatsString = "7";
            }
            myMimeTextMatchCollection1.Add( myMimeTextMatch1[ myInt ] );
         }
         myMimeTextMatch1[4] = new MimeTextMatch();
         // Remove 'MimeTextMatch' instance from collection.
         myMimeTextMatchCollection1.Remove( myMimeTextMatch1[ 1 ] );
         // Using MimeTextMatchCollection.Item indexer to comapre. 
         if( myMimeTextMatch1[ 2 ] == myMimeTextMatchCollection1[ 1 ] )
         {
            // Check whether 'MimeTextMatch' instance exists. 
            myInt = myMimeTextMatchCollection1.IndexOf( myMimeTextMatch1[ 2 ] );
            // Insert 'MimeTextMatch' instance at a desired position.
            myMimeTextMatchCollection1.Insert( 1, myMimeTextMatch1[ myInt ] );
            myMimeTextMatchCollection1[ 1 ].RepeatsString = "5";
            myMimeTextMatchCollection1.Insert( 4, myMimeTextMatch1[ myInt ] );
         }