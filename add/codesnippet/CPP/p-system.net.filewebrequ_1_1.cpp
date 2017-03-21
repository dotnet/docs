         // Create a Uri object.
         Uri^ myUrl = gcnew Uri( String::Format( "file://{0}", fileName ) );
         
         // Create a FileWebRequest object.
         myFileWebRequest = dynamic_cast<FileWebRequest^>(WebRequest::CreateDefault( myUrl ));
         
         // Set the timeout to the value selected by the user.
         myFileWebRequest->Timeout = timeout;
         
         // Set the Method property to POST
         myFileWebRequest->Method = "POST";
         