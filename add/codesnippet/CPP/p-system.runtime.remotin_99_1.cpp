      Console::WriteLine( "Message Properties" );
      IDictionary^ myDictionary = myMesg->Properties;
      IDictionaryEnumerator^ myEnum = dynamic_cast<IDictionaryEnumerator^>(myDictionary->GetEnumerator());
      while ( myEnum->MoveNext() )
      {
         Object^ myKey = myEnum->Key;
         String^ myKeyName = myKey->ToString();
         Object^ myValue = myEnum->Value;
         Console::WriteLine( "{0} : {1}", myKeyName, myEnum->Value );
         if ( myKeyName->Equals( "__Args" ) )
         {
            array<Object^>^myArgs = (array<Object^>^)myValue;
            for ( int myInt = 0; myInt < myArgs->Length; myInt++ )
               Console::WriteLine( "arg: {0} myValue: {1}", myInt, myArgs[ myInt ] );
         }

         if ( (myKeyName->Equals( "__MethodSignature" )) && (nullptr != myValue) )
         {
            array<Object^>^myArgs = (array<Object^>^)myValue;
            for ( int myInt = 0; myInt < myArgs->Length; myInt++ )
               Console::WriteLine( "arg: {0} myValue: {1}", myInt, myArgs[ myInt ] );
         }
      }

      Console::WriteLine( "myUrl1 {0} object URI{1}", myUrl, myObjectURI );
      myDictionary->default[ "__Uri" ] = myUrl;
      Console::WriteLine( "URI {0}", myDictionary->default[ "__URI" ] );
      