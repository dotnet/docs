    // Create a new 'Uri' object with the mentioned string.
    Uri^ myUri = gcnew Uri( "http://www.contoso.com" );
      
    // Create a new 'HttpWebRequest' object with the above 'Uri' object.
    HttpWebRequest^ myHttpWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( myUri ));
      
    // Create a new 'DateTime' object.
    DateTime targetDate = DateTime::Now;
    // Set a target date of a week ago
    targetDate.AddDays(-7.0);
    myHttpWebRequest->IfModifiedSince = targetDate;

    try
    {
         
      // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      HttpWebResponse^ myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());
      Console::WriteLine( "Response headers \n {0}\n", myHttpWebResponse->Headers );
      Stream^ streamResponse = myHttpWebResponse->GetResponseStream();
      StreamReader^ streamRead = gcnew StreamReader( streamResponse );
      array<Char>^readBuff = gcnew array<Char>(256);
      int count = streamRead->Read( readBuff, 0, 256 );
      Console::WriteLine( "\nThe contents of Html Page are :  \n" );
      while ( count > 0 )
      {
        String^ outputData = gcnew String( readBuff,0,count );
        Console::Write( outputData );
        count = streamRead->Read( readBuff, 0, 256 );
      }
      streamResponse->Close();
      streamRead->Close();
         
      // Release the HttpWebResponse Resource.
      myHttpWebResponse->Close();
      Console::WriteLine( "\nPress 'Enter' key to continue................." );
      Console::Read();
    }
    catch ( WebException^ e )
    {
      if (e->Response)
      {
        if ( ((HttpWebResponse ^)e->Response)->StatusCode == HttpStatusCode::NotModified)
          Console::WriteLine("\nThe page has not been modified since {0}", targetDate);
        else
          Console::WriteLine("\nUnexpected status code = {0}", ((HttpWebResponse ^)e->Response)->StatusCode);  
      }
      else
        Console::WriteLine("\nUnexpected Web Exception {0}" + e->Message); 
    }