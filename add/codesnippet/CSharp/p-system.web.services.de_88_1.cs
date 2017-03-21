               // Create an OutputBinding.
               OutputBinding myOutputBinding = new OutputBinding();

               // Create a MimeTextBinding.
               MimeTextBinding myMimeTextBinding = new MimeTextBinding();

               // Create a MimeTextMatch.
               MimeTextMatch myMimeTextMatch = new MimeTextMatch();
               MimeTextMatchCollection myMimeTextMatchCollection ;

               // Initialize properties of the MimeTextMatch.
               myMimeTextMatch.Name = "Title";
               myMimeTextMatch.Type = "*/*";
               myMimeTextMatch.Pattern = "'TITLE&gt;(.*?)&lt;";
               myMimeTextMatch.IgnoreCase = true;

               // Initialize a MimeTextMatchCollection.
               myMimeTextMatchCollection = myMimeTextBinding.Matches;

               // Add the MimeTextMatch to the MimeTextMatchCollection.
               myMimeTextMatchCollection.Add( myMimeTextMatch );
               myOutputBinding.Extensions.Add( myMimeTextBinding );

               // Add the OutputBinding to the OperationBinding.
               myOperationBinding.Output = myOutputBinding; 