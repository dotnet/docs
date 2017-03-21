      ServicePointManager::CertificatePolicy = gcnew MyCertificatePolicy;

      // Create the request and receive the response
      try
      {
         WebRequest^ myRequest = WebRequest::Create( myUri );
         WebResponse^ myResponse = myRequest->GetResponse();
         ProcessResponse( myResponse );
         myResponse->Close();
      }
      // Catch any exceptions
      catch ( WebException^ e ) 
      {
         if ( e->Status == WebExceptionStatus::TrustFailure )
         {
            // Code for handling security certificate problems goes here.
         }
         // Other exception handling goes here
      }