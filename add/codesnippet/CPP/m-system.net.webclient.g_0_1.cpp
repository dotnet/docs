   virtual WebResponse^ GetWebResponse( WebRequest^ request ) override
   {
      WebResponse^ response = WebClient::GetWebResponse( request );

      // Perform any custom actions with the response ...
      return response;
   }