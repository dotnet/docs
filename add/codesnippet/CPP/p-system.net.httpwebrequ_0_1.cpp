void makeWebRequest( int hashCode, String^ Uri )
{
   HttpWebResponse^ res = nullptr;
   
   // Make sure that the idle time has elapsed, so that a new 
   // ServicePoint instance is created.
   Console::WriteLine( "Sleeping for 2 sec." );
   Thread::Sleep( 2000 );
   try
   {
      
      // Create a request to the passed URI.
      HttpWebRequest^ req = dynamic_cast<HttpWebRequest^>(WebRequest::Create( Uri ));
      Console::WriteLine( "\nConnecting to {0} ............", Uri );
      
      // Get the response object.
      res = dynamic_cast<HttpWebResponse^>(req->GetResponse());
      Console::WriteLine( "Connected.\n" );
      ServicePoint^ currentServicePoint = req->ServicePoint;
      
      // Display new service point properties.
      int currentHashCode = currentServicePoint->GetHashCode();
      Console::WriteLine( "New service point hashcode: {0}", currentHashCode );
      Console::WriteLine( "New service point max idle time: {0}", currentServicePoint->MaxIdleTime );
      Console::WriteLine( "New service point is idle since {0}", currentServicePoint->IdleSince );
      
      // Check that a new ServicePoint instance has been created.
      if ( hashCode == currentHashCode )
            Console::WriteLine( "Service point reused." );
      else
            Console::WriteLine( "A new service point created." );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Source : {0}", e->Source );
      Console::WriteLine( "Message : {0}", e->Message );
   }
   finally
   {
      if ( res != nullptr )
            res->Close();
   }

}

