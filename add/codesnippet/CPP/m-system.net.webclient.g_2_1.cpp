   virtual WebRequest^ GetWebRequest ( Uri^ address ) override
   {
      WebRequest^ request = dynamic_cast<WebRequest^>(WebClient::GetWebRequest( address ));

      // Perform any customizations on the request.
      // This version of WebClient always preauthenticates.
      request->PreAuthenticate = true;
      return request;
   }