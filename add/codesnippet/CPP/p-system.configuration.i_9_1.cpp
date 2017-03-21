      StringDictionary^ myStringDictionary = Context->Parameters;
      if ( Context->Parameters->Count > 0 )
      {
         Console::WriteLine( "Context Property : " );
         IEnumerator^ myEnum = Context->Parameters->Keys->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            String^ myString = safe_cast<String^>(myEnum->Current);
            Console::WriteLine( Context->Parameters[ myString ] );
         }
      }