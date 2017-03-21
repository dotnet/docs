   virtual WebResponse^ GetWebResponse( WebRequest^ request, IAsyncResult^ result ) override
   {
      WebResponse^ response = WebClient::GetWebResponse( request, result );

      // Perform any custom actions with the response ...
      return response;
   }