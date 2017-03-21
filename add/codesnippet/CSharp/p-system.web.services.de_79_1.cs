         // Create an InputBinding.
         InputBinding myInputBinding = new InputBinding();
         MimeTextBinding myMimeTextBinding = new MimeTextBinding();
         MimeTextMatchCollection myMimeTextMatchCollection1 = 
            new MimeTextMatchCollection();
         MimeTextMatch[] myMimeTextMatch = new MimeTextMatch[3];        
         myMimeTextMatchCollection1 = myMimeTextBinding.Matches;

         // Intialize the MimeTextMatch. 
         for( myInt = 0 ; myInt < 3 ; myInt++ )
         {
            // Get a new MimeTextMatch.
            myMimeTextMatch[ myInt ] = new MimeTextMatch();

            // Assign values to properties of the MimeTextMatch.
            myMimeTextMatch[ myInt ].Name = "Title" + Convert.ToString( myInt );
            myMimeTextMatch[ myInt ].Type = "*/*";
            myMimeTextMatch[ myInt ].Pattern = "TITLE&gt;(.*?)&lt;";
            myMimeTextMatch[ myInt ].IgnoreCase = true;
            myMimeTextMatch[ myInt ].Capture = 2;
            myMimeTextMatch[ myInt ].Group = 2;     
            if( myInt != 0 )
            {
               // Assign the Repeats property if the index is not 0.
               myMimeTextMatch[ myInt ].Repeats = 2;
            }
            else
            {
               // Assign the RepeatsString property if the index is 0.
               myMimeTextMatch[ myInt ].RepeatsString = "4";
            }
            // Add the MimeTextMatch to the collection.
            myMimeTextMatchCollection1.Add( myMimeTextMatch[ myInt ] );
         }