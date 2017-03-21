      // Create a new 'HttpWebRequest' Object.
      HttpWebRequest^ myHttpWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.contoso.com" ));
      HttpWebResponse^ myHttpWebResponse;
      
      // Display the 'HaveResponse' property of the 'HttpWebRequest' object to the console.
      Console::WriteLine( "\nThe value of 'HaveResponse' property before a response object is obtained : {0}", myHttpWebRequest->HaveResponse );
      
      // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      myHttpWebResponse = dynamic_cast<HttpWebResponse^>(myHttpWebRequest->GetResponse());
      if ( myHttpWebRequest->HaveResponse )
      {
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
         Console::WriteLine( "\nPress 'Enter' key to continue.........." );
         Console::Read();
      }
      else
      {
         Console::WriteLine( "\nThe response is not received " );
      }
   }
   catch ( WebException^ e ) 
   {
      Console::WriteLine( "\nWebException Caught" );
      Console::WriteLine( "\nSource  : {0}", e->Source );
      Console::WriteLine( "\nMessage : {0}", e->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception Caught" );
      Console::WriteLine( "Source  : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }

}
