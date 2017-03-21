   virtual void ProcessMessage( IMessage^ message, ITransportHeaders^ requestHeaders, Stream^ requestStream, [Out]ITransportHeaders^% responseHeaders, [Out]Stream^% responseStream )
   {
      // Print the request message properties.
      Console::WriteLine( "---- Message from the client ----" );
      IDictionary^ dictionary = message->Properties;
      IEnumerator^ myEnum = dictionary->Keys->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Object^ key = safe_cast<Object^>(myEnum->Current);
         Console::WriteLine( "{0} = {1}", key, dictionary[ key ] );
      }

      Console::WriteLine( "---------------------------------" );

      // Hand off to the next sink in the chain.
      nextSink->ProcessMessage( message, requestHeaders, requestStream, responseHeaders, responseStream );
   }