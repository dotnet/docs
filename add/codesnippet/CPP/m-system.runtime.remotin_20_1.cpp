   // Create and send the object URL.
   virtual array<String^>^ GetUrlsForUri( String^ objectURI )
   {
      array<String^>^myString = gcnew array<String^>(1);
      myString[ 0 ] = String::Concat( Dns::Resolve( Dns::GetHostName() )->AddressList[ 0 ], "/", objectURI );
      return myString;
   }